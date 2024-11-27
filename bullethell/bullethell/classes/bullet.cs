using Microsoft.Win32.SafeHandles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace bullethell.classes
{
    public class bullet
    {
        bool nosprite = false;
        Game1 game1;

        public bool alive = true;
        public int dmg;

        public int timer = 300;
        public float speed = 5;

        public Vector2 position;
        public Vector2 velocity;
        public float direction;

        float rot;


        public Texture2D bullettex;
        public Color color;

      

        public Rectangle bulletcol
        {
            set
            {

            }
            get
            {
                // - 5 centers bullet collider
                return new Rectangle((int)position.X - 5, (int)position.Y - 5, 10, 10);
            }
        }
        public bullet(Vector2 position, float rotation)
        {
            //collider.collisionWidth = 10; 
            //collider.collisionHeight = 10;
            
            
            this.position = position;

            this.direction = rotation;

        }
        public bullet(Vector2 position, float rotation, Texture2D tex)
        {
            //collider.collisionWidth = 10; 
            //collider.collisionHeight = 10;

            bullettex = tex;
            this.position = position;

            this.direction = rotation;

        }


        public void Update(GameTime gt)
        {
            
            timer--;
            if (timer < 0)
            {
                alive = false;
            }
            if (alive)
            {
                velocity = new Vector2((float)Math.Cos(direction), (float)Math.Sin(direction)) * speed;

                position += velocity;
                //collider.position = new Vector2(position.X, position.Y - 10);


            }
            else
            {
                    
            }
        }
        public void draw(SpriteBatch SB,GraphicsDevice GD)
        {
            if (alive)
            {
                // rotates player bullets
                rot += 0.1f;

                SB.Begin();
                if (bullettex == null)
                {
                    bullettex = new Texture2D(GD, 1, 1);
                    bullettex.SetData(new[] { color });
                    nosprite =  true;
                }
                //if has bullet image
                if (!nosprite)
                {
                    SB.Draw(
                        bullettex,
                        position,
                        null,
                        Color.Multiply(Color.White, 1f),
                        rot,
                        new Vector2(bullettex.Width / 2, bullettex.Height / 2),
                        new Vector2(1, 1),
                        SpriteEffects.None,
                        0f
                   );
                }
                else
                {
                    SB.Draw(
                       bullettex,
                       position,
                       bulletcol,
                       Color.Multiply(Color.White, 1f),
                       3.14f,
                       new Vector2(bullettex.Width / 2, bullettex.Height / 2),
                       new Vector2(1, 1),
                       SpriteEffects.None,
                       0f
                  );
                }
               
                
                SB.End();
                //collider.drawCollider(SB, GD);
            }
            
        }
    }
}
