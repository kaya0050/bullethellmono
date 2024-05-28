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
        public void Update(GameTime gameTime,Game1 game1)
        {
            if (webegamin)
            {

                //Console.WriteLine(gameTime.TotalGameTime.TotalSeconds);

                game1.testcollider.UpdateCollisionObjects();
                game1.player1.playerUpdate(gameTime, game1._graphics);



            }
        }
    }
}
