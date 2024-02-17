using System;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace MyLibrary
{
    public class FPSCounterComponent : DrawableGameComponent
    {
        SpriteBatch spriteBatch;
        SpriteFont spriteFont;

        PrimitiveBatch pb;

        public int frameRate = 0;
        int frameCounter = 0;
        TimeSpan elapsedTime = TimeSpan.Zero;

        public FPSCounterComponent(Game game)
            : base(game)
        {
            /*spriteFont = Font;
            spriteBatch = Batch;*/
            pb = new PrimitiveBatch(game.GraphicsDevice);
        }

        public override void Update(GameTime gameTime)
        {
            elapsedTime += gameTime.ElapsedGameTime;

            if (elapsedTime > TimeSpan.FromSeconds(1))
            {
                elapsedTime -= TimeSpan.FromSeconds(1);
                frameRate = frameCounter;
                frameCounter = 0;
            }
        }

        public override void Draw(GameTime gameTime)
        {
            frameCounter++;

            string fps = string.Format("FPS: {0}", frameRate);

            pb.Begin(PrimitiveType.LineList);

            Font.Text(pb, 15.0f, 650.0f, 1f, Color.White, fps);

            pb.End();

            // TODO: Finish spriteBatch Begin() and End()
            /*spriteBatch.Begin();
            spriteBatch.DrawString(spriteFont, fps, new Vector2(100, 100), Color.White);
            spriteBatch.End();*/
        }
    }
}