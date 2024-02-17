using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;

using MyLibrary;

namespace LunarLander
{
    public class Lander : DrawableGameComponent
    {
        private PrimitiveBatch pb;

        private Vector2 position;
        private TimeSpan elapsedTime;

        public LinkedList<Vector2> lander;

        List<SoundEffect> soundEffects;
        public SoundEffectInstance thrust;
        public SoundEffectInstance explosion;
        public SoundEffectInstance success;

        private bool isVisible;
        internal bool physicsCheck;
        internal bool thrustCheck;
        internal bool rotCheck;

        public Vector2 velo;
        private int fuel;
        internal float rotAngle;
        internal float acc;
        internal float thrustMag;
        private float scale;

        internal const float EARTH_GRAVITY = 0.016f;
        internal const float MOON_GRAVITY = 0.0027f;
        internal const float JUPITER_GRAVITY = 0.0416f;

        internal const float EARTH_THRUST = 0f;
        internal const float MOON_THRUST = 0f;
        internal const float JUPITER_THRUST = 0f;

        public Lander(Game game) : base(game)
        {
            pb = new PrimitiveBatch(game.GraphicsDevice);

            game.Content.RootDirectory = "Content";

            lander = new LinkedList<Vector2>();

            position = new Vector2(15, 40);
            velo = new Vector2(0, 0);

            Fuel = 100;
            scale = 5.0f;
            rotAngle = 0.0f;
            acc = 0.0f;
            thrustMag = 0.0f;
            scale = 1.25f;

            soundEffects = new List<SoundEffect>
            {
                game.Content.Load<SoundEffect>("thrust"),
                game.Content.Load<SoundEffect>("explosion"),
                game.Content.Load<SoundEffect>("success")
            };

            thrust = soundEffects[0].CreateInstance();
            explosion = soundEffects[1].CreateInstance();
            success = soundEffects[2].CreateInstance();

            Ship();

            isVisible = true;
            physicsCheck = true;
            thrustCheck = true;
            rotCheck = true;
        }

        public int Fuel
        {
            get { return fuel; }
            set
            {
                if (value < 0) { fuel = 0; }
                else if (value > 100) { fuel = 100; }
                else { fuel = value; }
            }
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            // User inputs for movement
            Movement();
            // Decrements Fuel
            DecrementFuel(gameTime);

            // Reset Lander every Update
            lander.Clear();
            // Loads Ship
            Ship();
            // Loads current rotation
            if (rotCheck)
                Rotation();
            // Loads current thrust based on current angle
            if (thrustCheck)
                ThrustAngle();
            // Loads current physics
            if (physicsCheck)
                Physics();

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            if (isVisible)
            {
                pb.Begin(PrimitiveType.LineList);

                foreach (Vector2 v in lander)
                {
                    pb.AddVertex(v, Color.Green);
                }

                pb.End();
            }

            base.Draw(gameTime);
        }

        private void Movement()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.W) ||
                Keyboard.GetState().IsKeyDown(Keys.Space) ||
                Keyboard.GetState().IsKeyDown(Keys.Up) &&
                Fuel > 0)
            {
                thrustMag = 0.0085f;
            }
            else
            {
                thrustMag = 0.0f;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.D) ||
                Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                rotAngle += 0.027f;

                // Limit the max rotation
                //rotAngle = MathF.Min(MathF.PI/2, rotAngle);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.A) ||
                Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                rotAngle -= 0.027f;

                // Limit the max rotation
                //rotAngle = MathF.Max(-MathF.PI/2, rotAngle);
            }
        }

        private void DecrementFuel(GameTime gameTime)
        {
            KeyboardState newKeyboardState = Keyboard.GetState();

            if (newKeyboardState.IsKeyDown(Keys.W) ||
                newKeyboardState.IsKeyDown(Keys.Space) ||
                newKeyboardState.IsKeyDown(Keys.Up) &&
                Fuel > 0)
            {
                thrust.Play();

                if (thrust.State == SoundState.Playing)
                {
                    thrust.IsLooped = true;
                    thrust.Play();
                }
            }
            else if (Fuel <= 0)
            {
                newKeyboardState = Keyboard.GetState();

                thrust.Volume = 0;
                thrust.Stop();
            }

            if (thrust.State == SoundState.Playing)
            {
                elapsedTime += gameTime.ElapsedGameTime;

                if (elapsedTime > TimeSpan.FromSeconds(0.1))
                {
                    elapsedTime -= TimeSpan.FromSeconds(0.1);

                    Fuel -= 1;
                }
            }

            if (newKeyboardState.IsKeyUp(Keys.W) &&
                newKeyboardState.IsKeyUp(Keys.Space) &&
                newKeyboardState.IsKeyUp(Keys.Up))
            {
                thrust.Stop();
                elapsedTime = TimeSpan.Zero;
            }
        }

        private void Ship()
        {
            // Landing Gear with Scale
            // Hub
            lander.AddLast(new Vector2(position.X * scale, position.Y * scale));
            lander.AddLast(new Vector2((position.X + 5) * scale, position.Y * scale));

            lander.AddLast(new Vector2((position.X + 5) * scale, position.Y * scale));
            lander.AddLast(new Vector2((position.X + 8) * scale, (position.Y + 5) * scale));

            lander.AddLast(new Vector2((position.X + 8) * scale, (position.Y + 5) * scale));
            lander.AddLast(new Vector2((position.X - 3) * scale, (position.Y + 5) * scale));

            lander.AddLast(new Vector2((position.X - 3) * scale, (position.Y + 5) * scale));
            lander.AddLast(new Vector2(position.X * scale, position.Y * scale));

            // Thruster
            lander.AddLast(new Vector2(position.X * scale, (position.Y + 5) * scale));
            lander.AddLast(new Vector2((position.X + 1) * scale, (position.Y + 7) * scale));

            lander.AddLast(new Vector2((position.X + 1) * scale, (position.Y + 7) * scale));
            lander.AddLast(new Vector2((position.X + 4) * scale, (position.Y + 7) * scale));

            lander.AddLast(new Vector2((position.X + 4) * scale, (position.Y + 7) * scale));
            lander.AddLast(new Vector2((position.X + 5) * scale, (position.Y + 5) * scale));

            // Landing Gear
            lander.AddLast(new Vector2((position.X - 1.5f) * scale, (position.Y + 5) * scale));
            lander.AddLast(new Vector2((position.X - 3) * scale, (position.Y + 10) * scale));

            lander.AddLast(new Vector2((position.X + 6.5f) * scale, (position.Y + 5) * scale));
            lander.AddLast(new Vector2((position.X + 8) * scale, (position.Y + 10) * scale));

            // Left Landing Gear
            lander.AddLast(new Vector2((position.X - 5) * scale, (position.Y + 10) * scale));
            lander.AddLast(new Vector2((position.X - 1) * scale, (position.Y + 10) * scale));

            // Right Landing Gear
            lander.AddLast(new Vector2((position.X + 6) * scale, (position.Y + 10) * scale));
            lander.AddLast(new Vector2((position.X + 10) * scale, (position.Y + 10) * scale));

            
            // Landing Gear without Scale
            /*// Hub
            lander.AddLast(new Vector2(position.X, position.Y));
            lander.AddLast(new Vector2(position.X + 5, position.Y));

            lander.AddLast(new Vector2(position.X + 5, position.Y));
            lander.AddLast(new Vector2(position.X + 8, position.Y + 5));

            lander.AddLast(new Vector2(position.X + 8, position.Y + 5));
            lander.AddLast(new Vector2(position.X - 3, position.Y + 5));

            lander.AddLast(new Vector2(position.X - 3, position.Y + 5));
            lander.AddLast(new Vector2(position.X, position.Y));

            // Thruster
            lander.AddLast(new Vector2(position.X, position.Y + 5));
            lander.AddLast(new Vector2(position.X + 1, position.Y + 7));

            lander.AddLast(new Vector2(position.X + 1, position.Y + 7));
            lander.AddLast(new Vector2(position.X + 4, position.Y + 7));

            lander.AddLast(new Vector2(position.X + 4, position.Y + 7));
            lander.AddLast(new Vector2(position.X + 5, position.Y + 5));

            // Landing Gear
            lander.AddLast(new Vector2(position.X - 1.5f, position.Y + 5));
            lander.AddLast(new Vector2(position.X - 3, position.Y + 10));

            lander.AddLast(new Vector2(position.X + 7.5f, position.Y + 5));
            lander.AddLast(new Vector2(position.X + 9, position.Y + 10));

            // Left Landing Gear
            lander.AddLast(new Vector2(position.X - 5, position.Y + 10));
            lander.AddLast(new Vector2(position.X - 1, position.Y + 10));

            // Right Landing Gear
            lander.AddLast(new Vector2(position.X + 7, position.Y + 10));
            lander.AddLast(new Vector2(position.X + 11, position.Y + 10));*/
        }

        private void Rotation()
        {
            // Axis point on Lander: xo and yo
            float xa = (lander.First.Value.X + lander.First.Next.Value.X) / 2;
            float ya = (lander.First.Value.Y + lander.First.Next.Value.Y) / 2;

            LinkedList<Vector2> rotatedShip = new LinkedList<Vector2>();

            for (int i = 0; i < lander.Count; i++)
            {
                Vector2 v = lander.ElementAt(i);

                // Origin point: xo and yo
                float xo = v.X;
                float yo = v.Y;
                // Prime point: xp and yp
                float xp = xa + (xo - xa) * MathF.Cos(rotAngle) - (yo - ya) * MathF.Sin(rotAngle);
                float yp = ya + (xo - xa) * MathF.Sin(rotAngle) + (yo - ya) * MathF.Cos(rotAngle);

                rotatedShip.AddLast(new Vector2(xp, yp));
            }

            lander = rotatedShip;
        }

        private void ThrustAngle()
        {
            // Swapped Sin and Cos because I it would not work otherwise
            velo.X += MathF.Sin(rotAngle) * thrustMag;
            velo.Y -= MathF.Cos(rotAngle) * thrustMag;
        }

        private void Physics()
        {
            // Gravity: Earth - 9.80 m/s^2 = 0.016ms, Jupiter - 25.0 m/s^2 = 0.43, Moon - 1.62 m/s^2 = 0.0027ms
            acc = MOON_GRAVITY;
            velo.Y += acc;
            position += velo;
        }
    }
}
