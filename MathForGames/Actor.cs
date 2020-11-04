using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace MathForGames
{
    class Actor
    {
        protected char _icon = ' ';
        protected Vector2 _velocity;
        protected Matrix3 _localTransform = new Matrix3();
        protected Matrix3 _globalTransform = new Matrix3();
        protected Matrix3 _rotation = new Matrix3();
        protected Matrix3 _translation = new Matrix3();
        protected Matrix3 _scale = new Matrix3();
        protected ConsoleColor _color;
        protected Color _rayColor;
        protected Actor _parent;
        protected Actor[] _children = new Actor[0];

        public bool Started { get; private set; }

        public Vector2 Forward
        {
            get 
            {
                return new Vector2(_localTransform.m11, _localTransform.m21); 
            }

        }

        public Vector2 WorldPosition
        {
            get
            {
                return new Vector2(_globalTransform.m13, _globalTransform.m23);
            }
        }

        public Vector2 LocalPosition
        {
            get
            {
                return new Vector2(_localTransform.m13, _localTransform.m23);
            }
            set
            {
                _translation.m13 = value.X;
                _translation.m23 = value.Y;
            }
        }


        public void AddChild(Actor child)
        {
            Actor[] tempArray = new Actor[_children.Length + 1];

            for (int i = 0; i < _children.Length; i++)
            {
                tempArray[i] = _children[i];
            }

            tempArray[_children.Length] = child;
            _children = tempArray;
            child._parent = this;
        }


        public bool RemoveChild(Actor child)
        {
            bool childRemoved = false;

            if (child == null)
            {
                return false;
            }

            Actor[] tempArray = new Actor[_children.Length - 1];

            int j = 0;
            for (int i = 0; i < _children.Length; i++)
            {
                if (child != _children[i])
                {
                    tempArray[j] = _children[i];
                    j++;
                }
                else
                {
                    childRemoved = true;
                }
            }

            _children = tempArray;
            child._parent = null;
            return childRemoved;
        }



        public void SetTranslate(Vector2 position)
        {
            _translation.m13 = position.X;
            _translation.m23 = position.Y;
        }

        public void SetRotation(float radians)
        {
            _rotation.m11 = (float)(Math.Cos(radians));
            _rotation.m21 = -(float)(Math.Sin(radians));
            _rotation.m12 = (float)(Math.Sin(radians));
            _rotation.m22 = (float)(Math.Cos(radians));
        }

       public void UpdateGlobalTransform()
        {
            
        }
        
            

        public void SetScale(float x, float y)
        {
            _scale.m11 = x;
            _scale.m22 = y;
        }

        private void UpdateTransform()
        {
            _localTransform = _translation * _rotation * _scale;

        }

        private void SceneObject()
        {


        }


        public Vector2 Velocity
        {
            get
            {
                return _velocity;
            }
            set
            {
                _velocity = value;
            }
        }


        public Actor(float x, float y, char icon = ' ', ConsoleColor color = ConsoleColor.White)
        {
            _rayColor = Color.WHITE;
            _icon = icon;
            _localTransform = new Matrix3(1, 0, 0, 0, 1, 0, 0, 0, 1);
            _globalTransform = new Matrix3(1, 0, 0, 0, 1, 0, 0, 0, 1);
            LocalPosition = new Vector2(x, y);
            _velocity = new Vector2();
            _color = color;
        }

        public Actor(float x, float y, Color rayColor, char icon = ' ', ConsoleColor color = ConsoleColor.White)
            : this(x, y, icon, color)
        {
            _rayColor = rayColor;
        }

        private void UpdateFacing()
        {
            if (_velocity.Magnitude <= 0)
                return;
        }


        public virtual void Start()
        {
            Started = true;
        }

        public virtual void Update(float deltaTime)
        {
            UpdateTransform();
            UpdateFacing();
            LocalPosition += _velocity * deltaTime;
        }

        public virtual void Draw()
        {
            Raylib.DrawText(_icon.ToString(), (int)(LocalPosition.X * 32), (int)(LocalPosition.Y * 32), 32, _rayColor);
            Raylib.DrawLine(
                (int)(LocalPosition.X * 32),
                (int)(LocalPosition.Y * 32),
                (int)((LocalPosition.X + Forward.X) * 32),
                (int)((LocalPosition.Y + Forward.Y) * 32),
                Color.WHITE
            );

            Console.ForegroundColor = _color;
            Console.SetCursorPosition((int)LocalPosition.X, (int)LocalPosition.Y);
            Console.Write(_icon);
            Console.ForegroundColor = Game.DefaultColor;


        }

        public virtual void End()
        {
            Started = false;
        }

    }
}
