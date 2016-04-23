using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace TowerDefense.Lib.Input
{
    public static class InputManager
    {
        public static Vector2 MousePosition
        {
            get { return new Vector2(MouseState.X, MouseState.Y); }
        }

        public static Point MousePositionPoint
        {
            get { return new Point(MouseState.X, MouseState.Y); }
        }

        public static MouseState MouseState { get; set; }
        public static KeyboardState KeyboardState { get; set; }
        public static KeyboardState LastKeyboardState { get; set; }
        public static TimeSpan LastMouseRightClick { get; set; }
        public static TimeSpan LastMouseLeftClick { get; set; }

        //public static Point MouseToMapPoint
        //{
        //    get
        //    {
        //        return new Point((int) (MousePosition.X + Camera.Position.X), (int) (MousePosition.Y + Camera.Position.Y));
        //    }
        //}

        //public static Vector2 MouseToMapVector
        //{
        //    get
        //    {
        //        return new Vector2((int) (MousePosition.X + Camera.Position.X),
        //            (int) (MousePosition.Y + Camera.Position.Y));
        //    }
        //}

        public static Vector2 MovementVector { get; set; }

        public static Vector2 MovementInput
        {
            get
            {
                Vector2 movement = Vector2.Zero;
                if (KeyboardState.IsKeyDown(InputConfiguration.Config.Right))
                    movement.X = 1;
                else if (KeyboardState.IsKeyDown(InputConfiguration.Config.Left))
                    movement.X = -1;
                if (KeyboardState.IsKeyDown(InputConfiguration.Config.Down))
                    movement.Y = 1;
                else if (KeyboardState.IsKeyDown(InputConfiguration.Config.Up))
                    movement.Y = -1;
                return movement;
            }
        }

        public static MouseState LastMouseState { get; set; }

        public static bool KeyPress(Keys key)
        {
            return KeyboardState.IsKeyDown(key) && LastKeyboardState.IsKeyUp(key);
        }

        private enum InputType
        {
            Joystick,
            Keyboard
        }
    }
}