using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bullethell.classes
{
    internal class inputanager
    {
        #region AxisButtons
        public float Vertical;
        public Keys Horizontal_Positive = Keys.W;
        public Keys Horizontal_Negative = Keys.S;

        public float Horizontal;
        public Keys Vertical_Positive = Keys.D;
        public Keys Vertical_Negative = Keys.A;
        #endregion

        #region ActionButtons
        public bool Shoot1;
        public Keys Shoot1_key;

        public bool Shoot2;
        public Keys Shoot2_key;

        public bool Shoot3;
        public Keys Shoot3_key;

        public bool Shoot4;
        public Keys Shoot4_key;
        #endregion

        #region MenuButtons
        public bool Accept;
        public Keys Accept_key;
        public bool Deny;
        public Keys Deny_key;
        public bool Back;
        public Keys Back_key;
        #endregion

        #region Mouse
        MouseState mouseState;
        public Vector2 mousePosition;
        public bool mouseclickLeft;
        public bool mouseclickRight;

        public Rectangle mouseRect;
        #endregion


        public void InputUpdate()
        {
            var Input = Keyboard.GetState();

            #region GetinputFunctions
            VH(Input);
            Shoot(Input);
            Menu(Input);
            MouseInput();
            #endregion  
        }


        #region InputFuncs
        public void VH(KeyboardState Input)
        {
            #region Vertical
            if (Input.IsKeyDown(Vertical_Positive))
            {
                Vertical = 1;
            }
            else if (Input.IsKeyDown(Vertical_Negative))
            {
                Vertical = -1;
            }
            else
            {
                Vertical = 0;
            }
            #endregion

            #region Horizontal
            if (Input.IsKeyDown(Horizontal_Positive))
            {
                Horizontal = 1;
            }
            else if (Input.IsKeyDown(Horizontal_Negative))
            {
                Horizontal = -1;
            }
            else
            {
                Horizontal = 0;
            }
            #endregion
        }
        
        public void Shoot(KeyboardState Input)
        {
            Shoot1 = Input.IsKeyDown(Shoot1_key);
            Shoot1 = Input.IsKeyDown(Shoot2_key);
            Shoot1 = Input.IsKeyDown(Shoot3_key);
            Shoot1 = Input.IsKeyDown(Shoot4_key);
        }

        public void Menu(KeyboardState Input)
        {
            Accept = Input.IsKeyDown(Accept_key);
            Deny = Input.IsKeyDown(Deny_key);
            Back = Input.IsKeyDown(Back_key);
        }

        public void MouseInput()
        {
            mouseState = Mouse.GetState();

            mouseRect = new Rectangle(mouseState.X, mouseState.Y, 1, 1);
            mousePosition = new Vector2(mouseState.X, mouseState.Y);

            #region MouseButtons
            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                mouseclickLeft = true;
            }
            else 
            { 
                mouseclickLeft = false; 
            }


            if (mouseState.RightButton == ButtonState.Pressed)
            {
                mouseclickRight = true;
            }
            else
            {
                mouseclickRight = false;
            }
            #endregion

        }
        #endregion

    }
}
