﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bullethell.classes
{
    internal class entity
    {
        public int id;
        public string tag;
        public string name;
        public Texture2D basetex;
        Color color = Color.White;


        public Vector2 position;
        public float rotation;
        public int width = 32;
        public int height = 32;
        #region debug variables

        double V;
        int speed = 200;
        #endregion
        public collisionobjects collider = new collisionobjects();
        public entity()
        {
            collider.collisionWidth = 64;
            collider.collisionHeight = 64;
            
        }
        public Rectangle hitbox
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, width, height);
            }
        }
        
        public void entityUpdate(GameTime GT, GraphicsDeviceManager graphics)
        {
            #region debug
            MouseState mouse = Mouse.GetState();
            //var distance = new Vector2(mouse.X - position.X, mouse.Y - position.Y);
            //rotation = (float)Math.Atan2(distance.Y, distance.X);
            //rotation += 1 * (float)GT.ElapsedGameTime.TotalSeconds;
            

            // center collider
            collider.position = new Vector2(position.X - 16,position.Y - 16);
            
            var keystateplayer = Keyboard.GetState();
            
            if (keystateplayer.IsKeyDown(Keys.A))
            {
                if (hitbox.Left > 0)
                {
                    float pp = MathF.Sin((((float)GT.TotalGameTime.TotalSeconds * 20)));
                    //rotation = pp / 5;
                    //rotation = 179 + pp / 10;
                    
                    position.X -= speed * (float)GT.ElapsedGameTime.TotalSeconds;
                    collider.position.X -= speed * (float)GT.ElapsedGameTime.TotalSeconds;

                }
            }
            if (keystateplayer.IsKeyDown(Keys.D))
            {
                if (hitbox.Right <= graphics.PreferredBackBufferWidth)
                {
                    float pp = MathF.Sin((((float)GT.TotalGameTime.TotalSeconds * 20)));
                    //rotation = pp / 5;
                    //rotation = -179 + pp / 10;
                    
                    position.X += speed * (float)GT.ElapsedGameTime.TotalSeconds;
                    collider.position.X += speed * (float)GT.ElapsedGameTime.TotalSeconds;
                }
                
            }
            if (keystateplayer.IsKeyDown(Keys.W))
            {
                if (hitbox.Top > 0)
                {
                    
                    position.Y -= speed * (float)GT.ElapsedGameTime.TotalSeconds;
                    collider.position.Y -= speed * (float)GT.ElapsedGameTime.TotalSeconds;
                }
                
            }
            
            if (keystateplayer.IsKeyDown(Keys.S))
            {
                if (hitbox.Bottom < graphics.PreferredBackBufferHeight)
                {
                    
                    position.Y += speed * (float)GT.ElapsedGameTime.TotalSeconds;
                    collider.position.Y += speed * (float)GT.ElapsedGameTime.TotalSeconds;
                }
            }
            //if (hitbox.Bottom <= graphics.PreferredBackBufferHeight + 32)
            //{
            //    position.Y += 500 * (float)GT.ElapsedGameTime.TotalSeconds;
            //}


            





            #endregion
        }
        public void drawEntity(SpriteBatch SB,GraphicsDevice GD)
        {
            collider.color = Color.DarkGray;
            collider.drawCollider(SB, GD);
            SB.Begin();
          

            // creates single pixel texture
            if (basetex == null)
            {
                basetex = new Texture2D(GD, 1, 1);
                basetex.SetData(new[] { color });
            }
            
            SB.Draw(basetex,position, hitbox, Color.Multiply(Color.White,1f), rotation,new Vector2(0, 0),1f,SpriteEffects.None,1);

            SB.End();
            
        }


    }
}
