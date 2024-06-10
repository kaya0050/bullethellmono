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

        int extrapos = 0;
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
                enemy.Update(GT);
                
            }
        }
        bool right = false;
        public void Update(GameTime GT)
        {
            timer--;
            if (timer <= 0)
            {
                if (extrapos >720 )
                {
                    right = false;
                }
                if (extrapos < 0)
                {
                    right = true;
                }
                if (!right)
                {

                    extrapos -= 64;
                }
                if (right)
                {
                    extrapos += 64;
                }
                
                enemy enemysp = new enemy(player1);
                enemysp.position = new Vector2(extrapos,0);

                enemysp.Colormultiplyer = extrapos;
                //enemysp.collider.players.Add(player1);
                enemies.Add(enemysp);
                
                timer = 10;
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
