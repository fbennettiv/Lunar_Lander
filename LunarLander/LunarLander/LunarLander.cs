using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MyLibrary;

namespace LunarLander
{
    public class LunarLander : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        StateManager screen;

        public LunarLander()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 720;
            _graphics.ApplyChanges();

            Window.Title = "Lunar Lander";
        }

        protected override void Initialize()
        {
            screen = new StateManager(this);
            screen.Push(new Screens.Splash());

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            screen.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            
            screen.Draw(gameTime);

            base.Draw(gameTime);
        }
    }
}