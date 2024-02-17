using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;

namespace MyLibrary
{
    public class ABC123
    {
        public static LinkedList<Vector2> GetABC123(char ch)
        {
            LinkedList<Vector2> list = new LinkedList<Vector2>();

            switch (ch)
            {
                case 'A':
                case 'a':
                    {
                        list.AddLast(new Vector2(0, 2));
                        list.AddLast(new Vector2(0, 1));

                        list.AddLast(new Vector2(0, 1));
                        list.AddLast(new Vector2(1, 0));

                        list.AddLast(new Vector2(1, 0));
                        list.AddLast(new Vector2(2, 1));

                        list.AddLast(new Vector2(2, 1));
                        list.AddLast(new Vector2(0, 1));

                        list.AddLast(new Vector2(2, 1));
                        list.AddLast(new Vector2(2, 2));

                        break;
                    }
                case 'B':
                case 'b':
                    {
                        list.AddLast(new Vector2(0, 2));
                        list.AddLast(new Vector2(0, 0));

                        list.AddLast(new Vector2(0, 0));
                        list.AddLast(new Vector2(2, 0));

                        list.AddLast(new Vector2(2, 0));
                        list.AddLast(new Vector2(0, 1));

                        list.AddLast(new Vector2(0, 1));
                        list.AddLast(new Vector2(2, 2));

                        list.AddLast(new Vector2(2, 2));
                        list.AddLast(new Vector2(0, 2));

                        break;
                    }
                case 'C':
                case 'c':
                    {
                        list.AddLast(new Vector2(2, 2));
                        list.AddLast(new Vector2(0, 2));

                        list.AddLast(new Vector2(0, 2));
                        list.AddLast(new Vector2(0, 0));

                        list.AddLast(new Vector2(0, 0));
                        list.AddLast(new Vector2(2, 0));

                        break;
                    }
                case 'D':
                case 'd':
                    {
                        list.AddLast(new Vector2(0, 2));
                        list.AddLast(new Vector2(0, 0));

                        list.AddLast(new Vector2(0, 0));
                        list.AddLast(new Vector2(1, 0));

                        list.AddLast(new Vector2(1, 0));
                        list.AddLast(new Vector2(2, 1));

                        list.AddLast(new Vector2(2, 1));
                        list.AddLast(new Vector2(2, 2));

                        list.AddLast(new Vector2(2, 2));
                        list.AddLast(new Vector2(0, 2));

                        break;
                    }
                case 'E':
                case 'e':
                    {
                        list.AddLast(new Vector2(2, 2));
                        list.AddLast(new Vector2(0, 2));

                        list.AddLast(new Vector2(0, 2));
                        list.AddLast(new Vector2(0, 0));

                        list.AddLast(new Vector2(0, 0));
                        list.AddLast(new Vector2(2, 0));

                        list.AddLast(new Vector2(0, 1));
                        list.AddLast(new Vector2(1, 1));

                        break;
                    }
                case 'F':
                case 'f':
                    {
                        list.AddLast(new Vector2(0, 2));
                        list.AddLast(new Vector2(0, 0));

                        list.AddLast(new Vector2(0, 0));
                        list.AddLast(new Vector2(2, 0));

                        list.AddLast(new Vector2(0, 1));
                        list.AddLast(new Vector2(1, 1));

                        break;
                    }
                case 'G':
                case 'g':
                    {
                        list.AddLast(new Vector2(1, 1));
                        list.AddLast(new Vector2(2, 1));

                        list.AddLast(new Vector2(2, 1));
                        list.AddLast(new Vector2(2, 2));

                        list.AddLast(new Vector2(2, 2));
                        list.AddLast(new Vector2(0, 2));

                        list.AddLast(new Vector2(0, 2));
                        list.AddLast(new Vector2(0, 0));

                        list.AddLast(new Vector2(0, 0));
                        list.AddLast(new Vector2(2, 0));

                        break;
                    }
                case 'H':
                case 'h':
                    {
                        list.AddLast(new Vector2(0, 2));
                        list.AddLast(new Vector2(0, 0));

                        list.AddLast(new Vector2(0, 1));
                        list.AddLast(new Vector2(2, 1));

                        list.AddLast(new Vector2(2, 0));
                        list.AddLast(new Vector2(2, 2));

                        break;
                    }
                case 'I':
                case 'i':
                    {
                        list.AddLast(new Vector2(0, 2));
                        list.AddLast(new Vector2(2, 2));

                        list.AddLast(new Vector2(1, 2));
                        list.AddLast(new Vector2(1, 0));

                        list.AddLast(new Vector2(0, 0));
                        list.AddLast(new Vector2(2, 0));

                        break;
                    }
                case 'J':
                case 'j':
                    {
                        list.AddLast(new Vector2(0, 1));
                        list.AddLast(new Vector2(0, 2));

                        list.AddLast(new Vector2(0, 2));
                        list.AddLast(new Vector2(1, 2));

                        list.AddLast(new Vector2(1, 2));
                        list.AddLast(new Vector2(1, 0));

                        list.AddLast(new Vector2(0, 0));
                        list.AddLast(new Vector2(2, 0));

                        break;
                    }
                case 'K':
                case 'k':
                    {
                        list.AddLast(new Vector2(0, 2));
                        list.AddLast(new Vector2(0, 0));

                        list.AddLast(new Vector2(0, 1));
                        list.AddLast(new Vector2(2, 0));

                        list.AddLast(new Vector2(0, 1));
                        list.AddLast(new Vector2(2, 2));

                        break;
                    }
                case 'L':
                case 'l':
                    {
                        list.AddLast(new Vector2(0, 0));
                        list.AddLast(new Vector2(0, 2));

                        list.AddLast(new Vector2(0, 2));
                        list.AddLast(new Vector2(2, 2));

                        break;
                    }
                case 'M':
                case 'm':
                    {
                        list.AddLast(new Vector2(0, 2));
                        list.AddLast(new Vector2(0, 0));

                        list.AddLast(new Vector2(0, 0));
                        list.AddLast(new Vector2(1, 1));

                        list.AddLast(new Vector2(1, 1));
                        list.AddLast(new Vector2(2, 0));

                        list.AddLast(new Vector2(2, 0));
                        list.AddLast(new Vector2(2, 2));

                        break;
                    }
                case 'N':
                case 'n':
                    {
                        list.AddLast(new Vector2(0, 2));
                        list.AddLast(new Vector2(0, 0));

                        list.AddLast(new Vector2(0, 0));
                        list.AddLast(new Vector2(2, 2));

                        list.AddLast(new Vector2(2, 2));
                        list.AddLast(new Vector2(2, 0));

                        break;
                    }
                case 'O':
                case 'o':
                    {
                        list.AddLast(new Vector2(0, 0));
                        list.AddLast(new Vector2(2, 0));

                        list.AddLast(new Vector2(2, 0));
                        list.AddLast(new Vector2(2, 2));

                        list.AddLast(new Vector2(2, 2));
                        list.AddLast(new Vector2(0, 2));

                        list.AddLast(new Vector2(0, 2));
                        list.AddLast(new Vector2(0, 0));

                        break;
                    }
                case 'P':
                case 'p':
                    {
                        list.AddLast(new Vector2(0, 2));
                        list.AddLast(new Vector2(0, 0));

                        list.AddLast(new Vector2(0, 0));
                        list.AddLast(new Vector2(2, 0));

                        list.AddLast(new Vector2(2, 0));
                        list.AddLast(new Vector2(2, 1));

                        list.AddLast(new Vector2(2, 1));
                        list.AddLast(new Vector2(0, 1));

                        break;
                    }
                case 'Q':
                case 'q':
                    {
                        list.AddLast(new Vector2(0, 2));
                        list.AddLast(new Vector2(0, 0));

                        list.AddLast(new Vector2(0, 0));
                        list.AddLast(new Vector2(2, 0));

                        list.AddLast(new Vector2(2, 0));
                        list.AddLast(new Vector2(2, 1));

                        list.AddLast(new Vector2(2, 1));
                        list.AddLast(new Vector2(1, 2));

                        list.AddLast(new Vector2(1, 2));
                        list.AddLast(new Vector2(0, 2));

                        list.AddLast(new Vector2(1, 1));
                        list.AddLast(new Vector2(2, 2));

                        break;
                    }
                case 'R':
                case 'r':
                    {
                        list.AddLast(new Vector2(0, 2));
                        list.AddLast(new Vector2(0, 0));

                        list.AddLast(new Vector2(0, 0));
                        list.AddLast(new Vector2(2, 0));

                        list.AddLast(new Vector2(2, 0));
                        list.AddLast(new Vector2(2, 1));

                        list.AddLast(new Vector2(2, 1));
                        list.AddLast(new Vector2(0, 1));

                        list.AddLast(new Vector2(0, 1));
                        list.AddLast(new Vector2(2, 2));

                        break;
                    }
                case 'S':
                case 's':
                    {
                        list.AddLast(new Vector2(0, 2));
                        list.AddLast(new Vector2(2, 2));

                        list.AddLast(new Vector2(2, 2));
                        list.AddLast(new Vector2(2, 1));

                        list.AddLast(new Vector2(2, 1));
                        list.AddLast(new Vector2(0, 1));

                        list.AddLast(new Vector2(0, 1));
                        list.AddLast(new Vector2(0, 0));

                        list.AddLast(new Vector2(0, 0));
                        list.AddLast(new Vector2(2, 0));

                        break;
                    }
                case 'T':
                case 't':
                    {
                        list.AddLast(new Vector2(1, 2));
                        list.AddLast(new Vector2(1, 0));

                        list.AddLast(new Vector2(0, 0));
                        list.AddLast(new Vector2(2, 0));

                        break;
                    }
                case 'U':
                case 'u':
                    {
                        list.AddLast(new Vector2(0, 0));
                        list.AddLast(new Vector2(0, 2));

                        list.AddLast(new Vector2(0, 2));
                        list.AddLast(new Vector2(2, 2));

                        list.AddLast(new Vector2(2, 2));
                        list.AddLast(new Vector2(2, 0));

                        break;
                    }
                case 'V':
                case 'v':
                    {
                        list.AddLast(new Vector2(0, 0));
                        list.AddLast(new Vector2(1, 2));

                        list.AddLast(new Vector2(1, 2));
                        list.AddLast(new Vector2(2, 0));

                        break;
                    }
                case 'W':
                case 'w':
                    {
                        list.AddLast(new Vector2(0, 0));
                        list.AddLast(new Vector2(0, 2));

                        list.AddLast(new Vector2(0, 2));
                        list.AddLast(new Vector2(1, 1));

                        list.AddLast(new Vector2(1, 1));
                        list.AddLast(new Vector2(2, 2));

                        list.AddLast(new Vector2(2, 2));
                        list.AddLast(new Vector2(2, 0));

                        break;
                    }
                case 'X':
                case 'x':
                    {
                        list.AddLast(new Vector2(0, 2));
                        list.AddLast(new Vector2(2, 0));

                        list.AddLast(new Vector2(0, 0));
                        list.AddLast(new Vector2(2, 2));

                        break;
                    }
                case 'Y':
                case 'y':
                    {
                        list.AddLast(new Vector2(1, 2));
                        list.AddLast(new Vector2(1, 1));

                        list.AddLast(new Vector2(1, 1));
                        list.AddLast(new Vector2(0, 0));

                        list.AddLast(new Vector2(1, 1));
                        list.AddLast(new Vector2(2, 0));

                        break;
                    }
                case 'Z':
                case 'z':
                    {
                        list.AddLast(new Vector2(2, 2));
                        list.AddLast(new Vector2(0, 2));

                        list.AddLast(new Vector2(0, 2));
                        list.AddLast(new Vector2(2, 0));

                        list.AddLast(new Vector2(2, 0));
                        list.AddLast(new Vector2(0, 0));

                        break;
                    }
                case '1':
                    {
                        list.AddLast(new Vector2(1, 0));
                        list.AddLast(new Vector2(1, 2));

                        break;
                    }
                case '2':
                    {
                        list.AddLast(new Vector2(2, 2));
                        list.AddLast(new Vector2(0, 2));

                        list.AddLast(new Vector2(0, 2));
                        list.AddLast(new Vector2(0, 1));

                        list.AddLast(new Vector2(0, 1));
                        list.AddLast(new Vector2(2, 1));

                        list.AddLast(new Vector2(2, 1));
                        list.AddLast(new Vector2(2, 0));

                        list.AddLast(new Vector2(2, 0));
                        list.AddLast(new Vector2(0, 0));

                        break;
                    }
                case '3':
                    {
                        list.AddLast(new Vector2(0, 2));
                        list.AddLast(new Vector2(2, 2));

                        list.AddLast(new Vector2(2, 2));
                        list.AddLast(new Vector2(2, 1));

                        list.AddLast(new Vector2(2, 1));
                        list.AddLast(new Vector2(0, 1));

                        list.AddLast(new Vector2(2, 1));
                        list.AddLast(new Vector2(2, 0));

                        list.AddLast(new Vector2(2, 0));
                        list.AddLast(new Vector2(0, 0));

                        break;
                    }
                case '4':
                    {
                        list.AddLast(new Vector2(2, 2));
                        list.AddLast(new Vector2(2, 0));

                        list.AddLast(new Vector2(2, 1));
                        list.AddLast(new Vector2(0, 1));

                        list.AddLast(new Vector2(0, 1));
                        list.AddLast(new Vector2(0, 0));

                        break;
                    }
                case '5':
                    {
                        list.AddLast(new Vector2(0, 2));
                        list.AddLast(new Vector2(2, 2));

                        list.AddLast(new Vector2(2, 2));
                        list.AddLast(new Vector2(2, 1));

                        list.AddLast(new Vector2(2, 1));
                        list.AddLast(new Vector2(0, 1));

                        list.AddLast(new Vector2(0, 1));
                        list.AddLast(new Vector2(0, 0));

                        list.AddLast(new Vector2(0, 0));
                        list.AddLast(new Vector2(2, 0));

                        break;
                    }
                case '6':
                    {
                        list.AddLast(new Vector2(2, 0));
                        list.AddLast(new Vector2(0, 0));

                        list.AddLast(new Vector2(0, 0));
                        list.AddLast(new Vector2(0, 2));

                        list.AddLast(new Vector2(0, 2));
                        list.AddLast(new Vector2(2, 2));

                        list.AddLast(new Vector2(2, 2));
                        list.AddLast(new Vector2(2, 1));

                        list.AddLast(new Vector2(2, 1));
                        list.AddLast(new Vector2(0, 1));

                        break;
                    }
                case '7':
                    {
                        list.AddLast(new Vector2(0, 0));
                        list.AddLast(new Vector2(2, 0));

                        list.AddLast(new Vector2(2, 0));
                        list.AddLast(new Vector2(2, 2));

                        break;
                    }
                case '8':
                    {
                        list.AddLast(new Vector2(0, 0));
                        list.AddLast(new Vector2(0, 2));

                        list.AddLast(new Vector2(0, 2));
                        list.AddLast(new Vector2(2, 2));

                        list.AddLast(new Vector2(2, 2));
                        list.AddLast(new Vector2(2, 0));

                        list.AddLast(new Vector2(2, 0));
                        list.AddLast(new Vector2(0, 0));

                        list.AddLast(new Vector2(0, 1));
                        list.AddLast(new Vector2(2, 1));

                        break;
                    }
                case '9':
                    {
                        list.AddLast(new Vector2(2, 2));
                        list.AddLast(new Vector2(2, 0));

                        list.AddLast(new Vector2(2, 0));
                        list.AddLast(new Vector2(0, 0));

                        list.AddLast(new Vector2(0, 0));
                        list.AddLast(new Vector2(0, 1));

                        list.AddLast(new Vector2(0, 1));
                        list.AddLast(new Vector2(2, 1));

                        break;
                    }
                case '0':
                    {
                        list.AddLast(new Vector2(0, 2));
                        list.AddLast(new Vector2(2, 2));

                        list.AddLast(new Vector2(2, 2));
                        list.AddLast(new Vector2(2, 0));

                        list.AddLast(new Vector2(2, 0));
                        list.AddLast(new Vector2(0, 0));

                        list.AddLast(new Vector2(0, 0));
                        list.AddLast(new Vector2(0, 2));

                        list.AddLast(new Vector2(0, 2));
                        list.AddLast(new Vector2(2, 0));

                        break;
                    }
                case '.':
                    {
                        list.AddLast(new Vector2(1, 2));
                        list.AddLast(new Vector2(2, 2));

                        list.AddLast(new Vector2(2, 2));
                        list.AddLast(new Vector2(2, 1));

                        list.AddLast(new Vector2(2, 1));
                        list.AddLast(new Vector2(1, 1));

                        list.AddLast(new Vector2(1, 1));
                        list.AddLast(new Vector2(1, 2));

                        break;
                    }
                case ':':
                    {
                        list.AddLast(new Vector2(1, 0));
                        list.AddLast(new Vector2(1, 0.5f));

                        list.AddLast(new Vector2(1, 1.5f));
                        list.AddLast(new Vector2(1, 2));

                        break;
                    }
                case '+':
                    {
                        list.AddLast(new Vector2(1, 0));
                        list.AddLast(new Vector2(1, 2));

                        list.AddLast(new Vector2(0, 1));
                        list.AddLast(new Vector2(2, 1));

                        break;
                    }
                case '-':
                    {
                        list.AddLast(new Vector2(0, 1));
                        list.AddLast(new Vector2(2, 1));

                        break;
                    }
                case '(':
                    {
                        list.AddLast(new Vector2(2, 0));
                        list.AddLast(new Vector2(1, 0.5f));

                        list.AddLast(new Vector2(1, 0.5f));
                        list.AddLast(new Vector2(1, 1.5f));

                        list.AddLast(new Vector2(1, 1.5f));
                        list.AddLast(new Vector2(2, 2));

                        break;
                    }
                case ')':
                    {
                        list.AddLast(new Vector2(0, 0));
                        list.AddLast(new Vector2(1, 0.5f));

                        list.AddLast(new Vector2(1, 0.5f));
                        list.AddLast(new Vector2(1, 1.5f));

                        list.AddLast(new Vector2(1, 1.5f));
                        list.AddLast(new Vector2(0, 2));

                        break;
                    }
                case ',':
                    {
                        list.AddLast(new Vector2(1, 1.5f));
                        list.AddLast(new Vector2(1, 2.5f));

                        break;
                    }
                case '!':
                    {
                        list.AddLast(new Vector2(1, 0));
                        list.AddLast(new Vector2(1, 1.5f));

                        list.AddLast(new Vector2(1, 2));
                        list.AddLast(new Vector2(1, 2.2f));

                        break;
                    }
            }

            return list;
        }
    }
}
