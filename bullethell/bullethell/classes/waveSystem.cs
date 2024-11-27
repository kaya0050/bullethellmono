using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bullethell.classes
{
    public class waveSystem
    {
        public List<bullet> bulletsOfDeadEnemys = new List<bullet>();

        public List<enemy> enemiesToSpawn = new List<enemy>();
        public List<int> countBeforeNewRow = new List<int>();

        public List<enemy> enemies = new List<enemy>();
        public int count = 1;

        public Vector2 spawnpoint = new Vector2(0,0);

        public player playerspawner;


        public waveSystem(List<enemy> enemies,List<int> numLi,player player)
        {
            enemiesToSpawn = enemies;
            countBeforeNewRow = numLi;
            playerspawner = player;
        }
        public void spawnWave()
        {
            //je moet een niewe enemy aanmaken anders gebriukt hij dezelfde als die dood is
            enemy enemy = new enemy(playerspawner);
            Console.WriteLine(enemies.Count);
            if (enemies.Count < 2)
            {
                enemies.Add(enemy);
            }
        }
        public void Update(GameTime gt)
        {
            
            foreach (var enemy in enemies)
            {
                enemy.Update(gt);
                if (!enemy.alive)
                {
                    foreach (var bullet in enemy.bullets)
                    {
                        bulletsOfDeadEnemys.Add(bullet);
                    }
                    List<enemy> newenemies = new List<enemy>();
                    for (int i = 0; i < enemies.Count; i++)
                    {
                        if (enemies.ToArray<enemy>()[i].alive)
                        {
                            newenemies.Add(enemies.ToArray<enemy>()[i]);

                        }
                    }
                    enemies = newenemies;
                }
             
            }
            foreach (var bullet in bulletsOfDeadEnemys)
            {
                bullet.Update(gt);

                if (playerspawner.hitbox.Intersects(bullet.bulletcol) && bullet.alive)
                {
                    playerspawner.lives -= 1;
                    bullet.alive = false;
                }
            }
            spawnWave();
        }
        public void Draw(SpriteBatch sb,GraphicsDevice gd)
        {
            foreach (var enemy in enemies)
            {
                
                enemy.Draw(sb,gd);
            }
            foreach (var bullet in bulletsOfDeadEnemys)
            {
                bullet.draw(sb, gd);
            }
        }
    }
}
