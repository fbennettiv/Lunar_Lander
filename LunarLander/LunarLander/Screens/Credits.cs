using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using MyLibrary;

namespace LunarLander.Screens
{
    public class Credits : GameScreen
    {
        Play play;

        public Credits()
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
            if (input.KeyboardState.WasKeyPressed(Keys.Space) || 
                input.KeyboardState.WasKeyPressed(Keys.Escape) ||
                input.KeyboardState.WasKeyPressed(Keys.C) ||
                input.WasPressed(0, InputHandler.ButtonType.A, Keys.A))
            {
                screen.Pop();
            }
        }

        public override void Draw(GameTime gameTime)
        {
            CreditScreen(play.pb);
        }

        public static void CreditScreen(PrimitiveBatch pb)
        {
            Color colorWhite = Color.White;

            string text = "Credits";
            float x = 410.0f;
            float y = 150.0f;

            float textScaleTitle = 5f;

            Font.Text(pb, x, y, textScaleTitle, colorWhite, text);

            Color colorSCredit = Color.White;

            string textS = "Studio: Blank Inc.";
            float sx = 250.0f;
            float sy = 340.0f;

            float textScale = 1f;

            Font.Text(pb, sx, sy, textScale, colorWhite, textS);

            Color colorAssetCredit = Color.White;

            string textA = "Assets: Blank Inc. and David Kroggman";
            float ax = 250.0f;
            float ay = 370.0f;

            Font.Text(pb, ax, ay, textScale, colorWhite, textA);

            string textSplash = "Splash Image: ChatGPT";
            float splashx = 250.0f;
            float splashy = 400.0f;

            Font.Text(pb, splashx, splashy, textScale, colorWhite, textSplash);

            Color colorTCredit = Color.White;

            string textT = "To David Kroggman:";

            float tx = 200.0f;
            float ty = 450.0f;

            string textT1 = "Thank you for teaching me how to make this game.";

            float tx1 = 200.0f;
            float ty1 = 475.0f;

            string textT2 = "Even though this was one of my hardest classes I had fun making it.";

            float tx2 = 200.0f;
            float ty2 = 490.0f;

            string textT3 = "Hopefully you can be my teacher for Game Design";

            float tx3 = 200.0f;
            float ty3 = 505.0f;

            string textT4 = "until I graduate.";

            float tx4 = 200.0f;
            float ty4 = 520.0f;

            Font.Text(pb, tx, ty, textScale, colorWhite, textT);
            Font.Text(pb, tx1, ty1, textScale, colorWhite, textT1);
            Font.Text(pb, tx2, ty2, textScale, colorWhite, textT2);
            Font.Text(pb, tx3, ty3, textScale, colorWhite, textT3);
            Font.Text(pb, tx4, ty4, textScale, colorWhite, textT4);
        }
    }
}