﻿using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;
using MathLibrary;

namespace MathForGames
{
    /// <summary>
    /// An actor that moves based on input given by the user
    /// </summary>
    class Player : Actor
    {
        private float _speed = 1;
        private Sprite _sprite;
        private bool _canMove = true;

        public float Speed
        {
            get
            {
                return _speed;
            }
            set
            {
                _speed = value;
            }
        }

        /// <param name="x">Position on the x axis</param>
        /// <param name="y">Position on the y axis</param>
        /// <param name="icon">The symbol that will appear when drawn</param>
        /// <param name="color">The color of the symbol that will appear when drawn</param>
        public Player(float x, float y, char icon = ' ')
            : base(x, y, icon)
        {
<<<<<<< HEAD
            _sprite = new Sprite("Images/barrelBlue.png");
=======
            _sprite = new Sprite("Images/bullet.png");
>>>>>>> master
        }

        /// <param name="x">Position on the x axis</param>
        /// <param name="y">Position on the y axis</param>
        /// <param name="rayColor">The color of the symbol that will appear when drawn to raylib</param>
        /// <param name="icon">The symbol that will appear when drawn</param>
        /// <param name="color">The color of the symbol that will appear when drawn to the console</param>
        public Player(float x, float y, Color rayColor, char icon = ' ')
            : base(x, y, rayColor, icon)
        {
<<<<<<< HEAD
            _sprite = new Sprite("Images/barrelBlue.png");
=======
            _sprite = new Sprite("Images/bullet.png");
        }

        public override void Start()
        {
            GameManager.onWin += DrawWinText;
            base.Start();
        }

        public void Sword()
        {
            Enemy enemy = new Enemy(WorldPosition.X, WorldPosition.Y);
            Engine.GetCurrentScene().AddActor(enemy);
           

>>>>>>> master
        }

        public override void Update(float deltaTime)
        {
            //Gets the player's input to determine which direction the actor will move in on each axis 
            int xDirection = -Convert.ToInt32(Game.GetKeyDown((int)KeyboardKey.KEY_A))
                + Convert.ToInt32(Game.GetKeyDown((int)KeyboardKey.KEY_D));
            int yDirection = -Convert.ToInt32(Game.GetKeyDown((int)KeyboardKey.KEY_W))
                + Convert.ToInt32(Game.GetKeyDown((int)KeyboardKey.KEY_S));

<<<<<<< HEAD
            if(In)
=======
            if (Engine.GetKeyPressed((int)KeyboardKey.KEY_SPACE))
                Raylib.DrawText("STUPID!!!\nPress Esc to quit", 100, 100, 100, Color.BLUE);






>>>>>>> master
            //Set the actors current velocity to be the a vector with the direction found scaled by the speed
            Acceleration = new Vector2(xDirection, yDirection);
           Velocity = Velocity.Normalized * Speed;
            base.Update(deltaTime);
        }


        public override void Draw()
        {


            if(_sprite != null)
                _sprite.Draw(_globalTransform);

            base.Draw();
        }

        private void DrawWinText()
        {
            Raylib.DrawText("You Win!!\nPress Esc to quit", 100, 100, 100, Color.BLUE);
        }


    }  
}
