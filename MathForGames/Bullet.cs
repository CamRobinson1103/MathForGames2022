using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;
using MathLibrary;

namespace MathForGames
{
    class Bullet : Actor
    {
        private float _speed = 1;
        private Sprite _sprite;

        public Bullet(float x, float y, char icon = ' ', ConsoleColor color = ConsoleColor.White)
           : base(x, y, icon, color)
        {
            _sprite = new Sprite("Images/bullet.png");
        }

        public Bullet(float x, float y, Color rayColor, char icon = ' ', ConsoleColor color = ConsoleColor.White)
           : base(x, y, rayColor, icon, color)
        {
            _sprite = new Sprite("Images/bullet.png");
        }
    }
}
