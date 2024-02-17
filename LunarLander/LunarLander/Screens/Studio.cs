using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using MyLibrary;

namespace LunarLander.Screens
{
    public class Studio : GameScreen
    {
        SpriteBatch spriteBatch;

        Texture2D studio;

        private TimeSpan elapsedTime = TimeSpan.Zero;

        public Studio()
        {
            LoadContent();
        }

        public override void LoadContent()
        {
            spriteBatch = new SpriteBatch(StateManager.graphicsDevice);

            StateManager.game.Window.Title = "Lunar Lander";

            studio = StateManager.Content.Load<Texture2D>("Studio(BlankInc)");
        }
        
        protected override void UnloadContent()
        {
            studio.Dispose();

            base.UnloadContent();
        }

        public override void Update(GameTime gameTime, StateManager screen,
            GamePadState gamePadState, MouseState mouseState,
            KeyboardState keyState, InputHandler input)
        {
            if (input.KeyboardState.WasKeyPressed(Keys.Space) ||
                input.WasPressed(0, InputHandler.ButtonType.A, Keys.A))
            {
                Menu menu = new Menu();
                screen.Pop();
                screen.Push(menu);
            }

            elapsedTime += gameTime.ElapsedGameTime;

            if (elapsedTime > TimeSpan.FromSeconds(3))
            {
                Menu menu = new Menu();
                screen.Pop();
                screen.Push(menu);
            }
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            spriteBatch.Draw(studio, new Vector2(0,0), Color.White);

            spriteBatch.End();
        }
    }
}