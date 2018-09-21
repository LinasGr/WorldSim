using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorldSim
{
  public partial class Form1 : Form
  {
    Bitmap map;//Visual map reflecting Layers Fields
    World world;
    int mapWidth;
    int mapHigh;
    public Form1()
    {
      world = World.instance;
      world.populate();
      mapHigh = world.gridMax_Y;
      mapWidth = world.gridMax_X;
      map = new Bitmap(mapWidth, mapHigh);
      gridToMap();

      InitializeComponent();
      drawMap();
    }

    void gridToMap()
    {
      for (int z = 0; z < world.gridMax_Z; z++)//Coord Z
        for (int y = 0; y < mapHigh; y++)//Coord Y - Hight
          for (int x = 0; x < mapWidth; x++)
          {//Coord X - Width
            Coords coords = new Coords(x, y, z);
            if (world.grid[coords] == null)
              map.SetPixel(x, y, Color.White);
            if (world.grid[coords] != null)
              map.SetPixel(x, y, world.grid[coords].color);

          }
    }

    void drawMap()
    {
      this.panel_Map.CreateGraphics().DrawImage(ResizeImage(map, panel_Map.Width, panel_Map.Height), new Point(0, 0));
    }

    public static Bitmap ResizeImage(Image image, int width, int height)
    {
      var destRect = new Rectangle(0, 0, width, height);
      var destImage = new Bitmap(width, height);

      destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

      using (var graphics = Graphics.FromImage(destImage))
      {
        graphics.CompositingMode = CompositingMode.SourceCopy;
        graphics.CompositingQuality = CompositingQuality.HighQuality;
        graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
        graphics.SmoothingMode = SmoothingMode.None;
        graphics.PixelOffsetMode = PixelOffsetMode.None;

        using (var wrapMode = new ImageAttributes())
        {
          wrapMode.SetWrapMode(WrapMode.TileFlipXY);
          graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
        }
      }

      return destImage;
    }
    private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
    {
      e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
    }

    private void panel_Map_Paint(object sender, PaintEventArgs e)
    {
      drawMap();
    }

    private void button_Sim1_Click(object sender, EventArgs e)
    {
      world.Action();
      gridToMap();
      drawMap();
      this.label_Steps.Text = "" + (int.Parse(this.label_Steps.Text) + 1);
      this.label_Alive.Text=""+world.actors.Count;
    }

    private void button_StepMult_Click(object sender, EventArgs e)
    {
      if (int.Parse(this.textBox1.Text) > 0)
        for (int cik = 0; cik < int.Parse(this.textBox1.Text); cik++)
        {
          world.Action();
          gridToMap();
          drawMap();
          this.label_Steps.Text = "" + (int.Parse(this.label_Steps.Text) + 1);
          this.label_Alive.Text = "" + world.actors.Count;
          this.Invalidate();
          Application.DoEvents();
          if (world.actors.Count < 1) return;
        }
    }

    private void button_Reset_Click(object sender, EventArgs e)
    {
      for (int cik=world.actors.Count-1;cik>=0;cik--)
      {
        world.grid[world.actors[cik].coords] = null;
        world.actors.RemoveAt(cik);
     }
      world.populate();
      this.label_Alive.Text = "" + world.actors.Count;
      gridToMap();
      drawMap();
      this.Invalidate();
      Application.DoEvents();
    }
  }
}
