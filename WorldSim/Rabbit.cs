using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WorldSim
{
  class Rabbit : Actor
  {
    public int age;
    private const int MAX_AGE = 20;
    private const int BREED_AGE = 5;
    private const int MAX_OFFSPRINGS = 2;
    private const double BIRTH_PROBABILITY = 0.15;



    public Rabbit(Color color, Coords coords, Coords speed)
    {
      this._color = color;
      this._coords = coords;
      this._speed = speed;
      this._isFood = true;
      this.age = 1;
    }


    public Rabbit()
    {
      Coords newCoords = new Coords(0);
      while (!GridCellEmpty(newCoords)) newCoords.rnd();
      this._color = Color.Gray;
      this._coords = newCoords;
      this._speed = new Coords(2, 2, 0);
      this._isFood = true;
      this.age = 1;
    }


    public override void Act()
    {
      this.age++;
      if (this.age < MAX_AGE)
      {

        if (this.age > BREED_AGE && World.instance.rnd.NextDouble() <= BIRTH_PROBABILITY) this.Breed();
        else
        {
          Coords nextCoords = new Coords(this.coords);
          if (this.FindeEmptyCell(ref nextCoords)) this.Teleport(nextCoords);
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
          Rabbit newBunny = new Rabbit(this.color, freeCoords, this.speed);
          World.instance.grid[newBunny.coords] = newBunny;
          World.instance.actors.Add(World.instance.grid[newBunny.coords]);
        }
      }
    }

  }
}
