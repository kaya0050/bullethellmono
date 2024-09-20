using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bullethell.gamestateclasses
{
    public class weGamin
    {
        public bool webegamin = false;
        public Game1 Game1;
        public void Update(GameTime GT,Game1 game1)
        {
            if (webegamin)
            {

                //game1.testcollider.UpdateCollisionObjects();
                game1.player1.playerUpdate(GT, game1._graphics);
                game1.enemySpawner.Update(GT);



            }
        }
        public void Draw()
        {

        }
    }
}
