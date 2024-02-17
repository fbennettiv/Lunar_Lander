using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using MyLibrary;

namespace LunarLander.Screens
{
    public class Pause : GameScreen
    {
        Play play = new Play();

        public Pause()
        {
            LoadContent();
        }

        public override void LoadContent()
        {
            StateManager.game.Window.Title = "Lunar Lander";
        }

        public override void Update(GameTime gameTime, StateManager screen,
            GamePadState gamePadState, MouseState mouseState,
            KeyboardState keyState, InputHandler input)
        {
            if (input.KeyboardState.WasKeyPressed(Keys.P) ||
                input.KeyboardState.WasKeyPressed(Keys.Escape) ||
                input.WasPressed(0, InputHandler.ButtonType.B, Keys.B))
            {
                screen.Pop();
            }
        }

        public override void Draw(GameTime gameTime)
        {
            Title(play.pb);
            Controls(play.pb);
        }

        public static void Title(PrimitiveBatch pb)
        {
            Color color = Color.White;

            string text = "Paused";
            float x = 420.0f;
            float y = 150.0f;

            float textScale = 5f;

            Font.Text(pb, x, y, textScale, color, text);
        }

        public static void Controls(PrimitiveBatch pb)
        {
            Color color = Color.White;
            float textScale = 1f;

            string textU = "Unpause: (P) or (Esc)";
            float ux = 460.0f;
            float uy = 300.0f;

            string textC = "Controls:";
            float cx = 420.0f;
            float cy = 390.0f;

            string textM = ". Movement: WASP or Arrow Keys";
            float mx = 420.0f;
            float my = 420.0f;

            string textT = ". Thrust: W, Space, or Up Arrow";
            float tx = 420.0f;
            float ty = 450.0f;

            Font.Text(pb, ux, uy, textScale, color, textU);
            Font.Text(pb, cx, cy, textScale, color, textC);
            Font.Text(pb, mx, my, textScale, color, textM);
            Font.Text(pb, tx, ty, textScale, color, textT);
        }
    }
}