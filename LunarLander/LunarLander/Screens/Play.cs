using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using Color = Microsoft.Xna.Framework.Color;

using MyLibrary;
using Microsoft.Xna.Framework.Audio;
using System.Threading.Tasks.Sources;

namespace LunarLander.Screens
{
    public class Play : GameScreen
    {
        public PrimitiveBatch pb;
        FPSCounterComponent fps;

        Lander lander;
        Terrain terrain;
        Terrain pads;

        LinkedList<Line2D> xTerrain = new LinkedList<Line2D>();
        LinkedList<Vector2> tt;

        LinkedList<Line2D> xPads = new LinkedList<Line2D>();
        LinkedList<Vector2> pp;

        LinkedList<Line2D> xLander = new LinkedList<Line2D>();
        LinkedList<Vector2> ll;

        TimeSpan elapsedTime = TimeSpan.Zero;

        int frameRate;
        int frameCounter;
        private float angleLander;
        float score;
        int padcase;
        int pad;

        bool collision = false;
        bool Tcollision = false;
        bool Pcollision = false;
        bool[] collidedPad;

        public Play()
        {
            pb = new PrimitiveBatch(StateManager.graphicsDevice);

            Initialize();
            LoadContent();

            //lander.Fuel = previousFuel;
            //score = previousScore;
        }

        protected override void Initialize()
        {
            terrain = new Terrain(StateManager.game);
            Components.Add(terrain);

            pads = new Terrain(StateManager.game);
            Components.Add(pads);

            lander = new Lander(StateManager.game);
            Components.Add(lander);

            frameRate = 0;
            frameCounter = 0;
            score = 0;
            padcase = 0;
            pad = 1;
            collidedPad = new bool[10] {false, false, false, false, false,
                                        false, false, false, false, false};
        }

        public override void LoadContent()
        {
            StateManager.game.Window.Title = "Lunar Lander";

            LoadTerrain();
            LoadPads();
        }

        public override void Update(GameTime gameTime, StateManager screen,
            GamePadState gamePadState, MouseState mouseState,
            KeyboardState keyState, InputHandler input)
        {
            lander.Update(gameTime);
            FPS(gameTime);

            Inputs(input, screen);
            LoadLander();
            PadsCollisionCheck();
            TerrainCollisionCheck();

            
            RebuildPlayScreen(input, screen);

        }

        public override void Draw(GameTime gameTime)
        {
            StateManager.graphicsDevice.Clear(Color.Black);

            terrain.Draw(gameTime);
            lander.Draw(gameTime);

            DisplayTitle();
            DisplayFPS();
            DisplayScore();
            DisplayFuel();
            DisplayRotation();
            DisplayVelocity();

            DisplayLandings();
        }
        
        private void RebuildPlayScreen(InputHandler input, StateManager screen)
        {
            if (collision &&
                input.KeyboardState.WasKeyPressed(Keys.C))
            {
                Menu menu = new Menu();
                //menu.fuel = lander.Fuel;
                //menu.score = score;

                screen.Pop();
            }
        }

        private void LoadTerrain()
        {
            tt = terrain.terrain;
            for (int i = 1; i < tt.Count; i += 2)
            {
                float ex = tt.ElementAt(i).X;
                float ey = tt.ElementAt(i).Y;

                float sx = tt.ElementAt(i - 1).X;
                float sy = tt.ElementAt(i - 1).Y;

                Line2D node = new(sx, sy, ex, ey);

                xTerrain.AddLast(node);
            }
        }

        private void LoadPads()
        {
            pp = terrain.pads;
            for (int i = 1; i < pp.Count; i += 2)
            {
                float ex = pp.ElementAt(i).X;
                float ey = pp.ElementAt(i).Y;

                float sx = pp.ElementAt(i - 1).X;
                float sy = pp.ElementAt(i - 1).Y;

                Line2D node = new(sx, sy, ex, ey);

                xPads.AddLast(node);
            }
        }

        private void LoadLander()
        {
            ll = lander.lander;
            xLander.Clear();
            for (int i = 1; i < ll.Count; i += 2)
            {
                float ex = ll.ElementAt(i).X;
                float ey = ll.ElementAt(i).Y;

                float sx = ll.ElementAt(i - 1).X;
                float sy = ll.ElementAt(i - 1).Y;

                Line2D node = new(sx, sy, ex, ey);

                xLander.AddLast(node);
            }
        }

        public void Inputs(InputHandler input, StateManager screen)
        {
            if (input.KeyboardState.WasKeyPressed(Keys.P) ||
                input.WasPressed(0, InputHandler.ButtonType.Start, Keys.P))
            {
                Pause pause = new Pause();
                screen.Push(pause);
            }

            if (input.KeyboardState.WasKeyPressed(Keys.O) ||
                input.WasPressed(0, InputHandler.ButtonType.LeftShoulder, Keys.O))
            {
                Options options = new Options();
                screen.Push(options);
            }

            if (input.KeyboardState.WasKeyPressed(Keys.Escape) ||
                input.WasPressed(0, InputHandler.ButtonType.B, Keys.B)) // Remove WasPressed "B"
            {
                screen.Pop();
            }
        }

        private void TerrainCollisionCheck()
        {
            foreach (Line2D terrainLine in xTerrain)
            {
                foreach (Line2D landerLine in xLander)
                {
                    if (Line2D.Intersects(terrainLine, landerLine) ||
                        Line2D.Intersects(new Line2D(0, 0, 0, 720), landerLine) ||
                        Line2D.Intersects(new Line2D(1280, 0, 1280, 720), landerLine))
                    {
                        collision = Tcollision = true;
                        lander.thrustCheck = false;
                        lander.physicsCheck = false;
                        lander.rotCheck = false;

                        break;
                    }
                }
            }        
        }

        private void PadsCollisionCheck()
        {
            pad = 1;
            foreach (Line2D padLine in xPads)
            {
                collision = false;
                foreach (Line2D landerLine in xLander)
                {
                    if (Line2D.Intersects(padLine, landerLine) &&
                        angleLander > -5 && angleLander < 5 &&
                        (lander.velo.Y * 60) <= 10)
                    {
                        collision = Pcollision = true;
                        lander.thrustCheck = false;
                        lander.physicsCheck = false;
                        lander.rotCheck = false;

                        padcase = 1;
                        break;
                    }
                    if (Line2D.Intersects(padLine, landerLine) &&
                        angleLander > -5 && angleLander < 5 &&
                        (lander.velo.Y * 60) <= 15)
                    {
                        collision = Pcollision = true;
                        lander.thrustCheck = false;
                        lander.physicsCheck = false;
                        lander.rotCheck = false;

                        padcase = 2;
                        break;
                    }
                    if (Line2D.Intersects(padLine, landerLine) &&
                        angleLander > -10 && angleLander < 10 &&
                        (lander.velo.Y * 60) <= 20)
                    {
                        collision = Pcollision = true;
                        lander.thrustCheck = false;
                        lander.physicsCheck = false;
                        lander.rotCheck = false;

                        padcase = 3;
                        break;
                    }
                    else if (Line2D.Intersects(padLine, landerLine) &&
                        angleLander > -10 && angleLander < 10 &&
                        (lander.velo.Y * 60) > 20)
                    {
                        collision = Pcollision = true;
                        lander.thrustCheck = false;
                        lander.physicsCheck = false;
                        lander.rotCheck = false;

                        padcase = 4;
                        break;
                    }
                }
                pad++;

                if (collision && collidedPad[pad - 2])
                    break;

                if (Pcollision && padcase <= 3)
                    lander.success.Play();
                else if (Pcollision && padcase == 4)
                    lander.explosion.Play();

                if (collision)
                {
                    collidedPad[pad - 2] = true;

                    switch (padcase)
                    {
                        case 1:
                            {
                                lander.Fuel += 40;
                                score += (pad * 50);

                                break;
                            }
                        case 2:
                            {
                                lander.Fuel += 25;
                                score += (pad * 20);

                                break;
                            }
                        case 3:
                            {
                                lander.Fuel += 10;
                                score += (pad * 10);

                                break;
                            }
                    }
                }
            }
        }

        public void FPS(GameTime gameTime)
        {
            elapsedTime += gameTime.ElapsedGameTime;

            if (elapsedTime > TimeSpan.FromSeconds(1))
            {
                elapsedTime -= TimeSpan.FromSeconds(1);
                frameRate = frameCounter;
                frameCounter = 0;
            }
        }

        private void DisplayTitle()
        {
            Color color = Color.White;

            string text = "Lunar Lander";
            float px = 450.0f;
            float py = 5.0f;

            float textScale = 2f;

            Font.Text(pb, px, py, textScale, color, text);
        }

        private void DisplayFPS()
        {
            Color color = Color.White;
            string fpsText = frameRate.ToString("000");

            string text = "FPS: " + fpsText;
            float px = 5.0f;
            float py = 700.0f;

            float textScale = 1f;

            Font.Text(pb, px, py, textScale, color, text);
        }

        private void DisplayScore()
        {
            Color color = Color.White;
            string scoreText = score.ToString("000");

            string text = "Score: " + scoreText;
            float px = 15.0f;
            float py = 30.0f;

            float textScale = 1f;

            Font.Text(pb, px, py, textScale, color, text);
        }

        private void DisplayFuel()
        {
            Color color = Color.White;
            string fuel = lander.Fuel.ToString("000");

            string text = "FUEL: " + fuel;
            float px = 15.0f;
            float py = 15.0f;

            float textScale = 1f;

            Font.Text(pb, px, py, textScale, color, text);
        }

        private void DisplayRotation()
        {
            angleLander = (lander.rotAngle * (180/MathF.PI)); 

            if (angleLander < -360 || angleLander > 360)
                angleLander -= 360;

            Color color = Color.White;
            string rotation = angleLander.ToString("00");

            string text = "Rotation: " + rotation;
            float px = 930.0f;
            float py = 45.0f;

            float textScale = 1f;

            Font.Text(pb, px, py, textScale, color, text);
        }

        private void DisplayVelocity()
        {
            Color color = Color.White;

            // Velocity multiplied by 60 because it was divided by 60 to apply to milliseconds
            Vector2 velocity = new Vector2(MathF.Round(lander.velo.X * 60), -MathF.Round(lander.velo.Y * 60));
            string veloX = velocity.X.ToString("00");
            string veloY = velocity.Y.ToString("00");

            string textx = "Horizontal Velocity:" + veloX;
            float px = 930.0f;
            float py = 15.0f;

            float textScaleH = 1f;

            Font.Text(pb, px, py, textScaleH, color, textx);

            // Velocity was negated to represent Y value as normal
            string texty = "Vertical Velocity: " + veloY;
            float mx = 930.0f;
            float my = 30.0f;

            float textScaleV = 1f;

            Font.Text(pb, mx, my, textScaleV, color, texty);
        }

        private void DisplayLandings()
        {
            if (Pcollision)
            {
                // padcase keeps track of quality of landing
                switch (padcase)
                {
                    case 1:
                        {
                            Font.Text(pb, 450, 300, 1.5f, Color.Green,
                            "Great Landing!");

                            Font.Text(pb, 475, 250, 1f, Color.White,
                            "Press (C) to Continue");

                            break;
                        }
                    case 2:
                        {
                            Font.Text(pb, 450, 300, 1.5f, Color.Green,
                            "Nice Landing!");

                            Font.Text(pb, 475, 250, 1f, Color.White,
                            "Press (C) to Continue");

                            break;
                        }
                    case 3:
                        {
                            Font.Text(pb, 420, 300, 1.5f, Color.Green,
                            "It was okay I guess...");

                            Font.Text(pb, 475, 250, 1f, Color.White,
                            "Press (C) to Continue");

                            break;
                        }
                    case 4:
                        {
                            Font.Text(pb, 300, 300, 1.5f, Color.Red,
                                "Going alittle too fast there buckeroo!");

                            Font.Text(pb, 475, 250, 1f, Color.White,
                            "Press (C) to Continue");

                            break;
                        }
                }
            }
            else if (Tcollision)
            {
                Font.Text(pb, 450, 300, 1.5f, Color.Red,
                    "Crash Landing!");

                Font.Text(pb, 475, 250, 1f, Color.White,
                            "Press (C) to Continue");
            }
        }
    }
}