
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
        public int points = 50;

        public int lives = 100;
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
                #region debug
                MouseState mouse = Mouse.GetState();
                //var distanceToMouse = new Vector2(mouse.X - position.X, mouse.Y - position.Y);

                timer--;

                // center collider
                collider.position = new Vector2(position.X - 16, position.Y - 16);

                var keystateplayer = Keyboard.GetState();

                if (keystateplayer.IsKeyDown(Keys.A))
                {
                    if (hitbox.Left > 0)
                    {
                        float pp = MathF.Sin((((float)GT.TotalGameTime.TotalSeconds * 20)));


                        position.X -= speed * (float)GT.ElapsedGameTime.TotalSeconds;
                        collider.position.X -= speed * (float)GT.ElapsedGameTime.TotalSeconds;

                    }
                }
                if (keystateplayer.IsKeyDown(Keys.D))
                {
                    if (hitbox.Right <= graphics.PreferredBackBufferWidth)
                    {
                        float pp = MathF.Sin((((float)GT.TotalGameTime.TotalSeconds * 20)));

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
                if (mouse.LeftButton == ButtonState.Pressed && timer <= 0)
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
                collider.color = Color.White;
                collider.drawCollider(SB, GD);
                foreach (var bullet in playerbullets)
                {
                    bullet.draw(SB, GD);
                }
                SB.Begin();



                // creates single pixel texture
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
                    0,
                    new Vector2(0, 0),
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
            var bullet1 = new bullet(new Vector2(position.X + 16, position.Y + -32), rotation,textureforbullet);
            bullet1.color = Color.Gold;
            playerbullets.Add(bullet1);
            
            timer = timerdowntime;

        }
    }
    
}
