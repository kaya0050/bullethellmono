
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bullethell.classes
{
    public class player : entity
    {
        public inputManager inputmanager = new inputManager();

        public int points = 50;

        public int lives = 3;
        public int bombs = 3;
        public bool alive = true;

        public List<item> Inventory = new List<item>();



        public Vector2 position;
        public float rotation = -1.57f;
        public int speed = 200;
        public int width = 32;
        public int height = 32;

        public collisionobjects collider = new collisionobjects();

        public List<bullet> playerbullets = new List<bullet>();

        public int timer = 0;
        public int timerdowntime = 10;

        public Texture2D textureforbullet;
        public player()
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
        public void playerUpdate(GameTime GT, GraphicsDeviceManager graphics)
        {
           




            if (lives <= 0)
            {
                alive = false;
            }
            if (alive)
            {
                
                #region controls
                
                //var distanceToMouse = new Vector2(mouse.X - position.X, mouse.Y - position.Y);

                timer--;

                inputmanager.VH();
                inputmanager.MouseInput();


                // center collider to player pos
                collider.position = new Vector2(position.X - 16, position.Y - 16);
                
                

                //vertical and horizontal input
                if (inputmanager.Vertical < 0)
                {
                    rotation += 0.1f;
                    if (hitbox.Left > 0)
                    {
                        float pp = MathF.Sin((((float)GT.TotalGameTime.TotalSeconds * 20)));


                        position.X -= speed * (float)GT.ElapsedGameTime.TotalSeconds;
                        collider.position.X -= speed * (float)GT.ElapsedGameTime.TotalSeconds;

                    }
                }
                if (inputmanager.Vertical > 0)
                {
                    rotation -= 0.1f;
                    if (hitbox.Right <= graphics.PreferredBackBufferWidth)
                    {
                        float pp = MathF.Sin((((float)GT.TotalGameTime.TotalSeconds * 20)));

                        position.X += speed * (float)GT.ElapsedGameTime.TotalSeconds;
                        collider.position.X += speed * (float)GT.ElapsedGameTime.TotalSeconds;
                    }

                }
                if (inputmanager.Horizontal > 0)
                {
                    if (hitbox.Top > 0)
                    {

                        position.Y -= speed * (float)GT.ElapsedGameTime.TotalSeconds;
                        collider.position.Y -= speed * (float)GT.ElapsedGameTime.TotalSeconds;
                    }

                }
                if (inputmanager.Horizontal < 0)
                {
                    if (hitbox.Bottom < graphics.PreferredBackBufferHeight)
                    {

                        position.Y += speed * (float)GT.ElapsedGameTime.TotalSeconds;
                        collider.position.Y += speed * (float)GT.ElapsedGameTime.TotalSeconds;
                    }
                }

                if (inputmanager.mouseclickLeft && timer <= 0)
                {
                    gun();
                }

                foreach (var bullet in playerbullets)
                {
                    bullet.Update(GT);
                    
                }

                #endregion
            }
        }
        public void playerDraw(SpriteBatch SB, GraphicsDevice GD)
        {
            if (alive)
            {
                collider.color = Color.DarkRed;

                //collider.drawCollider(SB, GD);
                foreach (var bullet in playerbullets)
                {
                    bullet.draw(SB, GD);
                }

                SB.Begin();



                //creates single pixel texture
                if (basetex == null)
                {
                    basetex = new Texture2D(GD, 1, 1);
                    basetex.SetData(new[] { color });
                }

                SB.Draw(
                    basetex,
                    position,
                    hitbox,
                    Color.Multiply(Color.White, 1f),
                    rotation,
                    new Vector2(16, 16),
                    1f,
                    SpriteEffects.None,
                    1
                );
                
                
                SB.End();
            }
        }
        public void gun()
        {
            if (points >= 100)
            {
                var bullet2 = new bullet(new Vector2(position.X + 48, position.Y + -32), rotation + 0.1f,textureforbullet);
                bullet2.color = Color.Green;
                var bullet3 = new bullet(new Vector2(position.X + -16, position.Y + -32), rotation + -0.1f,textureforbullet);
                bullet3.color = Color.Red;
                playerbullets.Add(bullet2);
                playerbullets.Add(bullet3);

                timerdowntime = 10;
            }
            var bullet1 = new bullet(new Vector2(position.X, position.Y + -32), -1.57f,textureforbullet);
            bullet1.color = Color.Gold;
            playerbullets.Add(bullet1);
            
            timer = timerdowntime;

        }
    }
    
}
