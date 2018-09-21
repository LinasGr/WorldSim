using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WorldSim
{
  class BullShit : Actor
  {

    
    public BullShit(Color color,Coords coords,Coords speed)
    {
      this._color = color;
      this._coords = coords;
      this._speed = speed;
      this._isFood = true;
    }

    public BullShit(Coords coords)
    {
      this._color = Color.Brown;
      this._speed = new Coords(1, 1, 0);
      this.coords = coords;
      this._isFood = true;
    }

    public BullShit()
    {
      this._color = Color.Brown;
      this._speed = new Coords(1,1,0);
      Coords newCoords = new Coords(0);
      while (!GridCellEmpty(newCoords)) newCoords.rnd();
      this.coords = newCoords;
      this._isFood = true;
    }

    public override void Act()
    {
      return;
      Coords nextCoords = new Coords(this.coords);
      this.NextCoords(ref nextCoords);
      if (GridCellEmpty(nextCoords))
      {
        //this.Teleport(nextCoords);
        BullShit newCopy = new BullShit(nextCoords);
        this.AddNew(newCopy);
      }

    }

  }

}
