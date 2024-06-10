using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bullethell.classes
{
    public class enemy : entity
    {
        public player playertoenemy;

        public int ID;

        public int lives = 3;
        public bool alive = true;

        public int pointsenemy = 10;

        public List<item> inventory = new List<item>();

        public int ammo;
        public List<bullet> bullets = new List<bullet>();

        public bullet bullet1; 
        
        public int bullettimer = 70;
        public int bullettime = 0;


        public int Colormultiplyer;



        public enemy(player player)
        {
            position = new Vector2 (200, 50);
            collider = new collisionobjects();
            collider.collisionWidth = 32;
            collider.collisionHeight = 32;
            playertoenemy = player;
            
        }
        
        public void Update(GameTime GT)
        {
            

            if (lives <= 0 && alive)
            {
                //things to do before enemy is dead
                playertoenemy.points += pointsenemy;



                alive = false;
            }

            if (alive)
            {
                #region gun
                bullettime--;
                foreach (var bullet in bullets)
                {
                    bullet.Update(GT);
                    
                    if (playertoenemy.hitbox.Intersects(bullet.bulletcol) && bullet.alive)
                    {
                        playertoenemy.lives -= 1;
                        bullet.alive = false;
                    }
                }

                if (bullettime < 0)
                {
                    bullet1 = new bullet(position, 1.57f);
                    bullet1.speed = 2;
                    bullet1.color = Color.Red;
                    bullets.Add(bullet1);
                    bullettime = bullettimer;
                }
                #endregion

                
                collider.UpdateCollisionObjects();
                position += new Vector2(0, 1);
                collider.position = position;
                foreach (var bullet in playertoenemy.playerbullets)
                {
                    if (bullet.bulletcol.Intersects(collider.hitbox))
                    {
                        bullet.alive = false;
                        Console.WriteLine("enemy hit");
                        lives -= 1;
                        playertoenemy.playerbullets.Remove(bullet);
                        return;

                    }
                }
                if (playertoenemy.hitbox.Intersects(collider.hitbox))
                {
                    playertoenemy.lives -= 1;
                    alive = false;
                }
            }
        }
        
        public void Draw(SpriteBatch SB,GraphicsDevice GD)
        {
            if (alive)
            {
                foreach (var bullet in bullets)
                {
                    bullet.draw(SB,GD);

                }
                collider.drawCollider(SB, GD);
                SB.Begin();
                var c = new Color(Colormultiplyer, 0, 0);

                // creates single pixel texture
                if (basetex == null)
                {
                    basetex = new Texture2D(GD, 1, 1);
                    basetex.SetData(new[] { c });
                }
                SB.Draw(basetex, position, hitbox, Color.Multiply(Color.White, 1f), rotation, new Vector2(0, 0), 1f, SpriteEffects.None, 1);

                SB.End();
            }
            
        }
        
    }
}
