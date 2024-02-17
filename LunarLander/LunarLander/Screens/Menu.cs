using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using MyLibrary;


namespace LunarLander.Screens
{
    public class Menu : GameScreen
    {
        SpriteBatch spriteBatch;

        Texture2D menuPNG;

        Play play = new Play();

        //public float score;
        //public int fuel;

        public Menu()
        {
            LoadContent();
        }

        public override void LoadContent()
        {
            spriteBatch = new SpriteBatch(StateManager.graphicsDevice);

            StateManager.game.Window.Title = "Lunar Lander";

            menuPNG = StateManager.Content.Load<Texture2D>("MenuBackground (Darkened)");
        }
        protected override void UnloadContent()
        {
            menuPNG.Dispose();

            base.UnloadContent();
        }


        public override void Update(GameTime gameTime, StateManager screen,
            GamePadState gamePadState, MouseState mouseState,
            KeyboardState keyState, InputHandler input)
        {
            if (input.KeyboardState.WasKeyPressed(Keys.P) ||
                input.WasPressed(0, InputHandler.ButtonType.A, Keys.A))
            {
                //Play play = new Play(fuel, score);
                Play play = new Play();
                screen.Push(play);
            }

            if (input.KeyboardState.WasKeyPressed(Keys.C) ||
                input.WasPressed(0, InputHandler.ButtonType.Y, Keys.Y))
            {
                Credits credits = new Credits();
                screen.Push(credits);
            }

            if (input.KeyboardState.WasKeyPressed(Keys.O) ||
                input.WasPressed(0, InputHandler.ButtonType.Start, Keys.O))
            {
                Options options = new Options();
                screen.Push(options);
            }

            if (input.KeyboardState.WasKeyPressed(Keys.Escape) ||
                input.WasPressed(0, InputHandler.ButtonType.B, Keys.B))
            {
                StateManager.game.Exit();
            }
        }

        public override void Draw(GameTime gameTime)
        {
            // Faded Background of Playscreen
            spriteBatch.Begin();

            spriteBatch.Draw(menuPNG, new Vector2(0, 0), Color.White);

            spriteBatch.End();

            Title(play.pb);
            MenuOptions(play.pb);
        }

        static void Title(PrimitiveBatch pb)
        {
            Color color = Color.White;

            string text = "Lunar Lander";
            float x = 220.0f;
            float y = 150.0f;

            float textScale = 5f;

            Font.Text(pb, x, y, textScale, color, text);
        }

        static void MenuOptions(PrimitiveBatch pb)
        {
            Color color = Color.White;

            string textPlay = "Play    (P)";
            float px = 500.0f;
            float py = 350.0f;

            float textScale = 1f;

            Font.Text(pb, px, py, textScale, color, textPlay);

            string textOptions = "Options (O)";
            float ox = 500.0f;
            float oy = 380.0f;

            Font.Text(pb, ox, oy, textScale, color, textOptions);

            string textCredits = "Credits (C)";
            float cx = 500.0f;
            float cy = 410.0f;

            Font.Text(pb, cx, cy, textScale, color, textCredits);

            string textEscape = "Exit    (Esc)";
            float ex = 500.0f;
            float ey = 440.0f;

            Font.Text(pb, ex, ey, textScale, color, textEscape);
        }
    }
}