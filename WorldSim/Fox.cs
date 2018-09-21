using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WorldSim
{
  class Fox : Actor
  {
    public int age;
    private int food;
    private const int MAX_AGE = 15;
    private const int BREED_AGE = 10;
    private const int DEFAULT_FOOD = 7;
    private const int MAX_OFFSPRINGS = 1;
    private const double BIRTH_PROBABILITY = 0.35;




    public Fox(Color color, Coords coords, Coords speed)
    {
      this._color = color;
      this._coords = coords;
      this._speed = speed;
      this._isFood = false;
      this.age = 1;
      this.food = DEFAULT_FOOD;
    }


    public Fox()
    {
      Coords newCoords = new Coords(0);
      while (!GridCellEmpty(newCoords)) newCoords.rnd();
      this._color = Color.Red;
      this._coords = newCoords;
      this._speed = new Coords(1, 1, 0);
      this._isFood = false;
      this.age = 1;
      this.food = DEFAULT_FOOD;
    }


    public override void Act()
    {
      this.age++;
      this.food--;
      if (this.age < MAX_AGE && this.food > 0)
      {
        if (this.age > BREED_AGE)
        {
          if (World.instance.rnd.NextDouble() <= BIRTH_PROBABILITY) this.Breed();
          else
          {
            Coords nextCoords = new Coords(this.coords);
            if ( this.FindeFoodCell(ref nextCoords)) this.Feed(nextCoords);
            else if (this.FindeEmptyCell(ref nextCoords)) this.Teleport(nextCoords);
          }
        }
        else
        {
          Coords nextCoords = new Coords(this.coords);
          if ( this.FindeFoodCell(ref nextCoords)) this.Feed(nextCoords);
          else if (this.FindeEmptyCell(ref nextCoords)) this.Teleport(nextCoords);
        }
      }
      else
      {
        World.instance.grid[this.coords] = null;
        World.instance.actors.Remove(this);
      }
    }

    public void Breed()
    {
      for (int cik = World.instance.rnd.Next(MAX_OFFSPRINGS) + 1; cik > 0; cik--)
      {
        Coords freeCoords = new Coords(this.coords);
        if (FindeEmptyCell(ref freeCoords))
        {
          Fox newFox = new Fox(this.color, freeCoords, this.speed);
          World.instance.grid[newFox.coords] = newFox;
          World.instance.actors.Add(World.instance.grid[newFox.coords]);
        }
      }
    }
    public void Feed(Coords foodCoords)
    {
      this.food += DEFAULT_FOOD;
      World.instance.actors.Remove(World.instance.grid[foodCoords]);
      World.instance.grid[foodCoords] = null;
      this.Teleport(foodCoords);
    }
  }
}
