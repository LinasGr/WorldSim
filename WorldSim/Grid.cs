using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldSim
{
  //Field of grids
  //Stores properties of field and all grids
  class Grid
  {
    const int DEFAULT_X = 100;
    const int DEFAULT_Y = 100;
    const int DEFAULT_Z = 1;
    private Random rnd = new Random();
    int max_X { get; }
    int max_Y { get; }
    int max_Z { get; }
    public Actor[,,] actors { get; }

    public Actor this[Coords c]
    {
      get { return actors[c.z, c.y, c.x]; }
      set { actors[c.z, c.y, c.x] = value; }
    }

    public Grid(int x, int y, int z)
    {
      this.max_Z = z;
      this.max_Y = y;
      this.max_X = x;
      actors = new Actor[max_Z, max_Y, max_X];
    }
    public Grid()
    {
      this.max_X = DEFAULT_X;
      this.max_Y = DEFAULT_Y;
      this.max_Z = DEFAULT_Z;
      actors = new Actor[max_Z, max_Y, max_X];
    }
  }
}
