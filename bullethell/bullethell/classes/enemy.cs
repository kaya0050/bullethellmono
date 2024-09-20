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
        public player playerToEnemy;

        public int ID;

        public int lives = 3;
        public bool alive = true;

        public int pointsEnemy = 10;

        public List<item> inventory = new List<item>();

        public int ammo;
        public List<bullet> bullets = new List<bullet>();

        public bullet bullet1; 
        
        public int bulletTimer = 70;
        public int bulletTime = 0;


        public int deathTimer = 1000;

        public int ColorMultiplyer;



        public enemy(player player)
        {
            position = new Vector2 (200, 50);
            collider = new collisionobjects();
            collider.collisionWidth = 32;
            collider.collisionHeight = 32;
            playerToEnemy = player;

        }
        
        public void Update(GameTime GT)
        {
            deathTimer--;
            if (deathTimer < 0)
            {
                alive = false;
            }
            if (lives <= 0 && alive)
            {
                //things to do before enemy is dead
                playerToEnemy.points += pointsEnemy;



                alive = false;
            }

            if (alive)
            {
                #region gun


                bulletTime--;
                foreach (var bullet in bullets)
                {
                    bullet.Update(GT);

                    if (playerToEnemy.hitbox.Intersects(bullet.bulletcol) && bullet.alive)
                    {
                        playerToEnemy.lives -= 1;
                        bullet.alive = false;
                    }
                }

                if (bulletTime < 0)
                {
                    bullet1 = new bullet(position + new Vector2(21,16), 1.57f);
                    bullet1.speed = 2;
                    bullet1.color = Color.Red;
                    bullets.Add(bullet1);
                    bulletTime = bulletTimer;
                }


                #endregion
                
                
                collider.UpdateCollisionObjects();
                position += new Vector2(0, 1);
                collider.position = position;
                foreach (var bullet in playerToEnemy.playerbullets)
                {
                    if (bullet.bulletcol.Intersects(collider.hitbox))
                    {
                        bullet.alive = false;
                        //Console.WriteLine("enemy hit");
                        lives -= 1;
                        playerToEnemy.playerbullets.Remove(bullet);
                        return;

                    }
                }
                if (playerToEnemy.hitbox.Intersects(collider.hitbox))
                {
                    playerToEnemy.lives -= 1;
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
                var c = new Color(100, 0, 0);

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
