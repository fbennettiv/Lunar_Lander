using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MyLibrary
{
    public class Font
    {
        public static Color color;

        public static void Text(PrimitiveBatch pb, float x, float y, float scale, Color color, string text)
        {
            LinkedList<Vector2> list = new LinkedList<Vector2>();
            LinkedList<Vector2> chArray = null;

            float chWidth = 15.0f * scale;
            float lineHeight = 4.0f * scale;
            float lineWidth = 4.0f * scale;
            float dx = 0.0f;
            float dy = 0.0f;
            float posX = 0.0f;
            float posY = 0.0f;
            int i = 0;

            for (i = 0; i < text.Length; i++)
            {
                chArray = ABC123.GetABC123(text.ToCharArray()[i]);

                foreach (Vector2 v in chArray)
                {
                    dx = v.X;
                    dy = v.Y;
                    posX = x + i * chWidth;
                    posY = y;

                    list.AddLast(new Vector2(posX + v.X * lineWidth, posY + v.Y * lineHeight));
                }
            }

            pb.Begin(PrimitiveType.LineList);

            foreach (Vector2 v2 in list)
            {
                pb.AddVertex(v2, color);
            }

            pb.End();
        }
    }
}
