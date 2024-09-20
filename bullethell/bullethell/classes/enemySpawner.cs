using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bullethell.classes
{
    public class enemySpawner
    {
        //NEW bulletmanager
        public List<bullet> bulletsOfDeadEnemys = new List<bullet>();



        public List<enemy> enemies = new List<enemy>();
        public List<Vector2> spawnpoints = new List<Vector2>();

        public player player1;

        public int timer = 0;

        int extrapos = 200;
        public enemySpawner(List<enemy> enemiestospawn, player player,Vector2 spawnpoint)
        {
            enemies = enemiestospawn;
            player1 = player;
            spawnpoints.Add(spawnpoint);
            foreach (var enemy in enemies)
            {
                enemy.position = spawnpoint;
            }
        }

        bool right = false;
        public void Update(GameTime GT)
        {
            Console.WriteLine(enemies.Count);
            Console.Clear();

            


            #region enemymanager
            foreach (var enemy in enemies)
            {
                if (!enemy.alive)
                {
                    //make new list of enemies alive to replace old one so the dead enemies are deleted
                    List<enemy> newenemies = new List<enemy>();

                    foreach (var bullet in enemy.bullets)
                    {
                        bulletsOfDeadEnemys.Add(bullet);
                    }
                    
                    for (int i = 0; i < enemies.Count; i++)
                    {
                        if (enemies.ToArray<enemy>()[i].alive)
                        {
                            
                            newenemies.Add(enemies.ToArray<enemy>()[i]);
                            
                        }
                    }
                    enemies = newenemies;
                }
                else
                {
                    enemy.Update(GT);
                }
            }


            foreach (var bullet in bulletsOfDeadEnemys)
            {
                bullet.Update(GT);

                if (player1.hitbox.Intersects(bullet.bulletcol) && bullet.alive)
                {
                    player1.lives -= 1;
                    bullet.alive = false;
                }
            }

            #endregion


            timer--;
            if (timer <= 0)
            {
                
                
                enemy enemysp = new enemy(player1);
                enemysp.position = new Vector2(extrapos,0);

                

                //make player colide with enemy
                //enemysp.collider.players.Add(player1);


                enemies.Add(enemysp);
                
                timer = 50;
            }

        }
        public void Draw(SpriteBatch SB,GraphicsDevice GD)
        {
            foreach (var enemy in enemies)
            {
                enemy.Draw(SB,GD);
                
            }
            foreach (var bullet in bulletsOfDeadEnemys)
            {
                bullet.draw(SB,GD);
            }
        }
    }
}
