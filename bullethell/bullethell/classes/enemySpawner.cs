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
        public virtual void spawn(GameTime GT)
        {
            
            foreach (var enemy in enemies)
            {
                
                
            }
        }
        bool right = false;
        public void Update(GameTime GT)
        {
            foreach(var enemy in enemies)
            {
                if (!enemy.alive)
                {
                    
                    
                }
                else
                {
                    enemy.Update(GT);
                }
            }

            timer--;
            if (timer <= 0)
            {
                
                
                enemy enemysp = new enemy(player1);
                enemysp.position = new Vector2(extrapos,0);

                

                // make player colide with enemy
                //enemysp.collider.players.Add(player1);


                enemies.Add(enemysp);
                
                timer = 50;
            }
            
            spawn(GT);
        }
        public void Draw(SpriteBatch SB,GraphicsDevice GD)
        {
            foreach (var enemy in enemies)
            {
                enemy.Draw(SB,GD);
            }
        }
    }
}
