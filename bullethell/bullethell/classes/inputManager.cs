using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bullethell.classes
{
    public class inputManager
    {

        #region controller
        public Vector2 velocity = new Vector2();
        #endregion



        KeyboardState keystate;
        #region AxisButtons
        public float Horizontal;
        public Keys Horizontal_Positive = Keys.W;
        public Keys Horizontal_Negative = Keys.S;


        
        public float Vertical;
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
        public bool shootbutton1;
        public bool mouseclickRight;

        public Rectangle mouseRect;
        #endregion


        public void InputUpdate()
        {
            var Input = Keyboard.GetState();

            #region GetinputFunctions
            VH();
            Shoot();
            Menu();
            MouseInput();
            #endregion  
        }


        #region InputFuncs
        public void VH()
        {
            keystate = Keyboard.GetState();
            #region Vertical
            if (keystate.IsKeyDown(Vertical_Positive))
            {
                Vertical = 1;
            }
            else if (keystate.IsKeyDown(Vertical_Negative))
            {
                Vertical = -1;
            }

            #endregion

            #region Horizontal
            if (keystate.IsKeyDown(Horizontal_Positive))
            {
                Horizontal = 1;
            }
            else if (keystate.IsKeyDown(Horizontal_Negative))
            {
                Horizontal = -1;
            }

            #endregion


            #region controller
            if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X < 0.0f)
            {
                Vertical = 1 * GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X;
            }
            else if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X > 0.0f)
            {
                Vertical = 1 * GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X;
            }
            else
            {
                Vertical = 0;
            }

            if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y < 0.0f)
            {
                Horizontal = 1 * GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y;
            }
            else if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y > 0.0f)
            {
                Horizontal = 1 * GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y;
            }
            else
            {
                Horizontal = 0;
            }
            #endregion

            velocity.X = Vertical;
            velocity.Y = -Horizontal;

            //velocity.Normalize();



            
            
        }
        
        public void Shoot()
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Pressed)
            {
                shootbutton1 = true;


                GamePad.SetVibration(PlayerIndex.One, 1f, 1f);


            }
            else
            {
                shootbutton1 = false;
                GamePad.SetVibration(PlayerIndex.One, 0.0f, 0.0f);
            }


        }

        public void Menu()
        {
            //Accept = Input.IsKeyDown(Accept_key);
            if(GamePad.GetState(PlayerIndex.One).Buttons.B == ButtonState.Pressed)
            {
                Accept = true;  
            }
            else
            {
                Accept = false;
            }
            
            //Deny = Input.IsKeyDown(Deny_key);
            //Back = Input.IsKeyDown(Back_key);
        }

        public void MouseInput()
        {
            mouseState = Mouse.GetState();

            mouseRect = new Rectangle(mouseState.X, mouseState.Y, 1, 1);
            mousePosition = new Vector2(mouseState.X, mouseState.Y);

            #region MouseButtons
            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                shootbutton1 = true;
            }
            else 
            { 
                shootbutton1 = false; 
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
