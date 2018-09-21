using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WorldSim
{

  class World
  {
    public static readonly World instance = new World();

    public Random rnd = new Random();

    public Grid grid;
    public int gridMax_X = 100;
    public int gridMax_Y = 100;
    public int gridMax_Z = 1;
    public List<Actor> actors { get; } //List of actors objects
    private World()//3d World grid. Eatch cell is link to actors objects
    {
      grid = new Grid(gridMax_X, gridMax_Y, gridMax_Z);
      actors = new List<Actor>();

    }
    public void populate()//App starting or Reseting population setup
    {
      CreateActors(Actors.BullShit, 0);
      CreateActors(Actors.Snake, 1);
      CreateActors(Actors.Rabbit, 200);
      CreateActors(Actors.Fox, 100);
    }

    public void CreateActors(Actors actorType, int count)//Adding actors to List and linking on Grid
    {
      int created = 0;
      while (created < count)
      {
        {
          Actor actor = null;
          switch (actorType)
          {
            case Actors.Snake:
              actor = new Snake(1);
              break;
            case Actors.BullShit:
              actor = new BullShit();
              break;
            case Actors.Rabbit:
              actor = new Rabbit();
              break;
            case Actors.Fox:
              actor = new Fox();
              break;
          }
          actors.Add(actor);
          grid[actor.coords] = actor;
          created++;
        }
      }
    }

    public void Action()//Calculation of all actors move and reflection on grid
    {
      int count = actors.Count;
      for (int cik = count - 1; cik >= 0; cik--) actors[cik].Act();
    }

    public void Reset()//
    {
      for (int cik = actors.Count - 1; cik >= 0; cik--) actors[cik] = null;
    }
  }
}
