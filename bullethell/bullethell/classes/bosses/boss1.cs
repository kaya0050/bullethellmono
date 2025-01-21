using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bullethell.classes.bosses
{
    internal class boss1 : enemy
    {

        int bulletTimer = 80;
        public boss1(player player) : base(player)
        {

        }

        public override void gun(GameTime GT)
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
        public void Update()
        {

        }
        public void Draw()
        {

        }

    }
}
