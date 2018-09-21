using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldSim
{
  public class Coords
  {


    public int x { get; set; }
    public int y { get; set; }
    public int z { get; set; }
    public Coords(int x, int y, int z)
    {
      this.x = x;
      this.y = y;
      this.z = z;
    }
    public Coords(int z)
    {
      this.x = World.instance.rnd.Next(World.instance.gridMax_X);
      this.y = World.instance.rnd.Next(World.instance.gridMax_Y);
      this.z = z;
    }
    public Coords(Coords copy)
    {
      this.x = copy.x;
      this.y = copy.y;
      this.z = copy.z;
    }
    public Coords()
    {
      this.x = World.instance.rnd.Next(World.instance.gridMax_X);
      this.y = World.instance.rnd.Next(World.instance.gridMax_Y);
      this.z = World.instance.rnd.Next(World.instance.gridMax_Z);
    }
    public void rnd()
    {
      this.x = World.instance.rnd.Next(World.instance.gridMax_X);
      this.y = World.instance.rnd.Next(World.instance.gridMax_Y);
      this.z = World.instance.rnd.Next(World.instance.gridMax_Z);
    }

  }

}
