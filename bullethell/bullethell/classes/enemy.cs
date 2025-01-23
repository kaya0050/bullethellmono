using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

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
        
        public int bulletTimer = 50;
        public int bulletTime = 0;


        public int deathTimer = 1000;

        public int ColorMultiplyer;

        public float gunrot = 0;

        public enemy(player player)
        {
            position = new Vector2(0, 0);
            collider = new collisionobjects();
            collider.collisionWidth = 32;
            collider.collisionHeight = 32;
            playerToEnemy = player;

        }
        public virtual void gun(GameTime GT)
        {

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



                for (int i = 0; i < 20; i++)
                {
                    bullet bullet2 = new bullet(position + new Vector2(16, 16), (gunrot + i));
                    bullet2.speed = 2;
                    bullet2.color = new Color(255, 255, i * 10);
                    bullets.Add(bullet2);


                }
                gunrot += 0.07f;
                bulletTime = bulletTimer;
            }
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
                gun(GT);





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
                SB.Draw(basetex, position, hitbox, Color.Multiply(Color.White, 1f), 0, new Vector2(0, 0), 1f, SpriteEffects.None, 1);

                SB.End();
            }
            
        }
        
    }
}
