using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WorldSim
{
  class Snake : Actor
  {
    public Snake child;
    public Snake parent;
    public int length;

    public Snake(Color newColor, Coords coords, Coords speed, int length)
    {
      this._color = color;
      this._coords = coords;
      this._speed = speed;
      this.length = length;
      this._isFood = false;
    }

    public Snake(int length)
    {
      Coords newCoords = new Coords(0);
      while (!GridCellEmpty(newCoords)) newCoords.rnd();
      this._color = Color.Black;
      this._coords = newCoords;
      this._speed = new Coords(1, 1, 0);
      this.length = length;
      this._isFood = false;
    }

    public Snake()
    {
      Coords newCoords = new Coords(0);
      while (!GridCellEmpty(newCoords)) newCoords.rnd();
      this._color = Color.Black;
      this._coords = newCoords;
      this._speed = new Coords(1, 1, 0);
      this.length = 1;
      this._isFood = false;
    }

    ~Snake()
    {
      World.instance.grid[this.coords] = null;
      if (child != null) child = null;
    }

    public override void Act()
    {
      if (FirstInChane())
      {
        Coords nextCoords = new Coords(this.coords);
        this.NextCoords(ref nextCoords);
        if (GridCellIsFood(nextCoords)) EatFood(nextCoords);
        if (GridCellEmpty(nextCoords))
          if (this.length > 1)//Need to grow?
          {
            this.GrowTail();
            this.Teleport(nextCoords);
            World.instance.grid[this.child.coords] = this.child;
          }
          else if (this.child != null)
          {
            Coords followMe = new Coords(this.coords);
            this.Teleport(nextCoords);
            this.child.Follow(followMe);
          }
          else this.Teleport(nextCoords);
      }
    }

    public void Follow(Coords followCoords)
    {
      Coords followMe = new Coords(this.coords);
      //follows given coords
      this.Teleport(followCoords);

      //Grows tail if needs to
      if (this.length > 1)
      {
        this.GrowTail();
        this.Teleport(followCoords);
        World.instance.grid[this.child.coords] = this.child;
      }
      else
        //else Tells child to follow
        if (this.child != null) this.child.Follow(followMe);
    }

    public void GrowTail()
    {
      Snake tail = new Snake(this.color, this.coords, this.speed, --this.length);
      tail.parent = this;
      this.child = tail;
      this.length = 1;
      World.instance.actors.Add(tail);
    }

    public void GrowTail(int cells)
    {
      if (this.child != null) this.child.GrowTail(cells);
      else this.length += cells;
    }

    public void EatFood(Coords coords)
    {
      World.instance.actors.Remove(World.instance.grid[coords]);
      World.instance.grid[coords] = null;
      if (LastInChain()) this.length++;
      else GrowTail(1);
    }
    public bool LastInChain()
    {
      if (this.child == null) return true;
      return false;
    }
    public bool FirstInChane()
    {
      if (this.parent == null) return true;
      return false;
    }
    public bool IsMidChane()
    {
      if (this.parent != null && this.child != null) return true;
      return false;
    }
  }
}
