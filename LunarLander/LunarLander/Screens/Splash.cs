using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using MyLibrary;

namespace LunarLander.Screens
{
    public class Splash : GameScreen
    {
        SpriteBatch spriteBatch;

        Texture2D studioPNG;

        private TimeSpan elapsedTime = TimeSpan.Zero;

        public Splash()
        {
            LoadContent();
        }

        public override void LoadContent()
        {
            spriteBatch = new SpriteBatch(StateManager.graphicsDevice);

            StateManager.game.Window.Title = "Lunar Lander";

            studioPNG = StateManager.Content.Load<Texture2D>("Splash(Lunar Lander)(1280,720)");
        }

        public override void Update(GameTime gameTime, StateManager screen, 
            GamePadState gamePadState, MouseState mouseState, 
            KeyboardState keyState, InputHandler input)
        {
            if (input.KeyboardState.WasKeyPressed(Keys.Space) ||
                input.WasPressed(0, InputHandler.ButtonType.A, Keys.A))
            {
                Studio studio = new Studio();
                screen.Pop();
                screen.Push(studio);
            }

            elapsedTime += gameTime.ElapsedGameTime;

            if (elapsedTime > TimeSpan.FromSeconds(3))
            {
                Studio studio = new Studio();
                screen.Pop();
                screen.Push(studio);
            }
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            spriteBatch.Draw(studioPNG, new Vector2(0,0), Color.White);

            spriteBatch.End();
        }
    }
}