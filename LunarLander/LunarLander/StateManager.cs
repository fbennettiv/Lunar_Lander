using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LunarLander
{
    public class StateManager : DrawableGameComponent
    {
        private Stack<Screens.GameScreen> screens;

        private static ContentManager m_Content;
        private static GraphicsDevice m_graphicsDevice;
        private static InputHandler m_input;
        private static Game m_game;

        public static Game game
        {
            get { return m_game; }
            set { m_game = value; }
        }

        public static ContentManager Content
        {
            get { return m_Content; }
        }

        public static GraphicsDevice graphicsDevice
        {
            get { return m_graphicsDevice; }
        }

        public StateManager(Game game) : base(game)
        {
            screens = new Stack<Screens.GameScreen>();
            m_Content = game.Content;
            m_graphicsDevice = game.GraphicsDevice;
            m_input = new InputHandler(game);
            m_game = game;
        }

        public void Push(Screens.GameScreen screen)
        {
            screens.Push(screen);
        }

        public Screens.GameScreen Pop()
        {
            return screens.Pop();
        }

        protected override void LoadContent()
        {
            ContentManager content = Game.Content;
        }

        public Screens.GameScreen Top()
        {
            return screens.Peek();
        }

        public override void Update(GameTime gameTime)
        {
            GamePadState gamePadState = GamePad.GetState(PlayerIndex.One);
            MouseState mouseState = Mouse.GetState();
            KeyboardState keyState = Keyboard.GetState();
            m_input.Update(gameTime);

            Top().Update(gameTime, this, gamePadState, mouseState, keyState,
                m_input);
        }

        public override void Draw(GameTime gameTime)
        {
            Top().Draw(gameTime);
        }
    }
}
