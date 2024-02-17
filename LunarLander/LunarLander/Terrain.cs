using System;
using System.Collections.Generic;
using System.IO;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MyLibrary;



namespace LunarLander
{
    public class Terrain : DrawableGameComponent
    {
        public LinkedList<Vector2> terrain;
        public LinkedList<Vector2> pads;

        PrimitiveBatch pb;

        public Terrain(Game game) : base(game)
        {
            pb = new PrimitiveBatch(game.GraphicsDevice);

            terrain = new LinkedList<Vector2>();
            pads = new LinkedList<Vector2>();

            ReadTerrain();
            ReadPads();
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Draw(GameTime gameTime)
        {
            pb.Begin(PrimitiveType.LineList);

            foreach (Vector2 v in terrain)
            {
                pb.AddVertex(v, Color.White);
            }

            foreach (Vector2 v in pads)
            {
                pb.AddVertex(v, Color.GreenYellow);
            }

            pb.End();

            base.Draw(gameTime);
        }

        public void ReadTerrain()
        {
            StreamReader reader = File.OpenText(@".\Content\terrain.txt");
           
            string line = null;

            //using (). A way to use the reader so it can close when errors occur
            while ((line = reader.ReadLine()) != null)
            {
                line = line.Trim();

                if (!line.StartsWith("#")) // # is our commenting
                {
                    string[] s = line.Split(',');

                    Vector2 p1 = new Vector2(int.Parse(s[0]), int.Parse(s[1]));
                    terrain.AddLast(p1);

                    Vector2 p2 = new Vector2(int.Parse(s[2]), int.Parse(s[3]));
                    terrain.AddLast(p2);
                }
            }

            reader.Close();
        }

        public void ReadPads()
        {
            StreamReader reader = File.OpenText(@".\Content\pads.txt");

            string line = null;

            //using (). A way to use the reader so it can close when errors occur
            while ((line = reader.ReadLine()) != null)
            {
                line = line.Trim();

                if (!line.StartsWith("#")) // # is our commenting
                {
                    string[] s = line.Split(',');

                    Vector2 p1 = new Vector2(int.Parse(s[0]), int.Parse(s[1]));
                    pads.AddLast(p1);

                    Vector2 p2 = new Vector2(int.Parse(s[2]), int.Parse(s[3]));
                    pads.AddLast(p2);
                }
            }

            reader.Close();
        }
    }
}
