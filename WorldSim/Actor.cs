using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WorldSim
{
  abstract class Actor
  {
    protected Coords _coords;
    public Coords coords
    {
      get
      {

        return _coords;
      }
      set
      {
        _coords = value;
      }
    }

    protected Coords _speed;
    public Coords speed => _speed;

    protected bool _isFood;
    public bool isFood => _isFood;

    protected Color _color;
    public Color color => _color;

    public abstract void Act();

    public bool GridCellEmpty(Coords coords)//True if Cell is empty
    {
      if (World.instance.grid[coords] != null) return false;
      return true;
    }
    public bool GridCellIsFood(Coords coords)//True if Cell have food
    {
      if (World.instance.grid[coords] != null) return World.instance.grid[coords].isFood;
      else return false;
    }

    public void Teleport(Coords coords)//Moves to new cell at coords
    {
      World.instance.grid[this.coords] = null;
      this.coords = coords;
      World.instance.grid[coords] = this;
    }

    public void AddNew(Actor newActor)//CCreates copy to new cell at coords
    {
      World.instance.actors.Add(newActor);
      World.instance.grid[newActor.coords] = newActor;
    }

    public void Replicate(Coords coords)//Registering in another cell at coords
    {
      World.instance.grid[coords] = this;
    }

    public void NextCoords(ref Coords nextCoords)//Calculates new random coords acording speed within grid
    {
      Random rnd = World.instance.rnd;
      int nr;

      do
      {
        nr = nextCoords.x + rnd.Next(-this.speed.x, this.speed.x + 1);
      } while (nr < 0 || nr >= World.instance.gridMax_X);
      nextCoords.x = nr;

      do
      {
        nr = nextCoords.y + rnd.Next(-this.speed.y, this.speed.y + 1);
      } while (nr < 0 || nr >= World.instance.gridMax_Y);
      nextCoords.y = nr;

      do
      {
        nr = nextCoords.z + rnd.Next(-this.speed.z, this.speed.z + 1);
      } while (nr < 0 || nr >= World.instance.gridMax_Z);
      nextCoords.z = nr;
    }

    public bool FindeEmptyCell(ref Coords startCoords)
    {

      List<Coords> freeCells;
      freeCells = new List<Coords>();
      for (int z = -this.speed.z; z <= this.speed.z; z++)
        for (int y = -this.speed.y; y <= this.speed.y; y++)
          for (int x = -this.speed.x; x <= this.speed.x; x++)
          {
            Coords cellCoords = new Coords(startCoords);
            cellCoords.x += x;
            cellCoords.y += y;
            cellCoords.z += z;
            if (cellCoords.x >= 0 && cellCoords.x < World.instance.gridMax_X)
              if (cellCoords.y >= 0 && cellCoords.y < World.instance.gridMax_Y)
                if (cellCoords.z >= 0 && cellCoords.z < World.instance.gridMax_Z)
                {
                  if (World.instance.grid[cellCoords] == null)
                      freeCells.Add(cellCoords);
                }
          }
      if (freeCells.Count > 0)
      {
        startCoords = freeCells[World.instance.rnd.Next(freeCells.Count)];
        return true;
      }
      return false;


      int giveup = 27;
      do
      {
        this.NextCoords(ref startCoords);
        giveup--;
      } while (!GridCellEmpty(startCoords) && giveup > 0);
      if (GridCellEmpty(startCoords)) return true;
      return false;
    }
    public bool FindeFoodCell(ref Coords startCoords)
    {
      List<Coords> allFood;
      allFood = new List<Coords>();
      for (int z = -this.speed.z; z <= this.speed.z; z++)
        for (int y = -this.speed.y; y <= this.speed.y; y++)
          for (int x = -this.speed.x; x <= this.speed.x; x++)
          {
            Coords foodCoords = new Coords(startCoords);
            foodCoords.x += x;
            foodCoords.y += y;
            foodCoords.z += z;
            if (foodCoords.x >= 0 && foodCoords.x < World.instance.gridMax_X)
              if (foodCoords.y >= 0 && foodCoords.y < World.instance.gridMax_Y)
                if (foodCoords.z >= 0 && foodCoords.z < World.instance.gridMax_Z)
                {
                  if (World.instance.grid[foodCoords] != null)
                    if (World.instance.grid[foodCoords].isFood)
                    {
                     allFood.Add(foodCoords);
                    }
                }
          }
      if (allFood.Count > 0)
      {
        startCoords = allFood[World.instance.rnd.Next(allFood.Count)];
        return true;
      }
      return false;
    }
  }


  enum Actors
  {
    BullShit,
    Snake,
    Rabbit,
    Fox
  }
}
