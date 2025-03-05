using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bullethell.classes.bosses
{
    public class boss1 : enemy
    {
        public int lives = 20;

        int bulletTimer = 80;
        public boss1(player player) : base(player)
        {
            position = new Vector2(0, 0);
        }

        public void gun(GameTime GT,float speed,float rotation)
        {
            //base.gun(GT);
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
                for (int i = 0; i < 10; i++)
                {
                    bullet bullet2 = new bullet(position + new Vector2(16, 16), (gunrot + i));
                    bullet2.speed = speed;
                    bullet2.color = new Color(255, i * 10,255);
                    bullets.Add(bullet2);


                }
                gunrot += rotation;
                bulletTime = bulletTimer;
            }
        }

        public void phase1(GameTime GT)
        {
            gun(GT,2,0.02f);
        }
        public void phase2(GameTime GT)
        {
            
            gun(GT,4,0.005f);
            gun(GT,1,0.05f);

        }

        public void Update(GameTime GT)
        {
            if (lives <= 0)
            {
                alive = false;
            }
            if (alive)
            {
                if (lives >= 10)
                {
                    phase1(GT);
                }
                if (lives < 10)
                {
                    phase2(GT);
                }
                collider.UpdateCollisionObjects();

                //position += new Vector2(0.1f, 0.1f);
                var distance = new Vector2(playerToEnemy.position.X - position.X, playerToEnemy.position.Y - position.Y);
                rotation = (float)Math.Atan2(distance.Y, distance.X);
                Vector2 velocity = new Vector2((float)Math.Cos(rotation), (float)Math.Sin(rotation)) * 1;
                position += velocity;

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
        public void Draw(SpriteBatch SB, GraphicsDevice GD)
        {
            if (alive)
            {
                foreach (var bullet in bullets)
                {
                    bullet.draw(SB, GD);

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
                SB.Draw(basetex, position, hitbox, Color.Multiply(Color.White, 1f), 0, new Vector2(0, 0), 1f, SpriteEffects.None, 1);

                SB.End();
            }
        }

    }
}
