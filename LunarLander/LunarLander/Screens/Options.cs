using System;

using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

using MyLibrary;

namespace LunarLander.Screens
{
    public class Options : GameScreen
    {
        Play play = new Play();

        public Options()
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
            if (input.KeyboardState.WasKeyPressed(Keys.O) ||
                input.KeyboardState.WasKeyPressed(Keys.Escape) ||
                input.WasPressed(0, InputHandler.ButtonType.B, Keys.B))
            {
                screen.Pop();
            }
        }

        public override void Draw(GameTime gameTime)
        {
            Title(play.pb);
            OptionList(play.pb);
            Controls(play.pb);
            // Rules(play.pb)
        }

        public static void Title(PrimitiveBatch pb)
        {
            Color color = Color.White;

            string text = "Options";
            float x = 400.0f;
            float y = 150.0f;

            float textScale = 5f;

            Font.Text(pb, x, y, textScale, color, text);
        }

        public static void Controls(PrimitiveBatch pb)
        {
            Color color = Color.White;
            float textScale = 1f;

            string textI = "In Game:";
            float ix = 560.0f;
            float iy = 250.0f;

            string textP = ". Pause (P)";
            float px = 565.0f;
            float py = 280.0f;

            string textE = ". Exit  (Esc)";
            float ex = 565.0f;
            float ey = 310.0f;

            string textC = "Controls:";
            float cx = 400.0f;
            float cy = 390.0f;

            string textM = ". Movement: WASP or Arrow Keys";
            float mx = 400.0f;
            float my = 420.0f;

            string textT = ". Thrust: W, Space, or Up Arrow";
            float tx = 400.0f;
            float ty = 450.0f;

            Font.Text(pb, ix, iy, textScale, color, textI);
            Font.Text(pb, px, py, textScale, color, textP);
            Font.Text(pb, ex, ey, textScale, color, textE);
            Font.Text(pb, cx, cy, textScale, color, textC);
            Font.Text(pb, mx, my, textScale, color, textM);
            Font.Text(pb, tx, ty, textScale, color, textT);
        }

        public static void OptionList(PrimitiveBatch pb)
        {
            Color color = Color.White;
            float textScale = 1f;

            string text = "Extras: (Work in Progress)";
            float px = 400.0f;
            float py = 530.0f;

            string textV = ". Volume: Up(+) Down(-)";
            float vx = 400.0f;
            float vy = 560.0f;

            string textQ = ". Quality: Low(L) Medium(M) High(H)";
            float qx = 400.0f;
            float qy = 590.0f;

            Font.Text(pb, px, py, textScale, color, text);
            Font.Text(pb, vx, vy, textScale, color, textV);
            Font.Text(pb, qx, qy, textScale, color, textQ);
        }

        // public static void Rules() {}
    }
}
