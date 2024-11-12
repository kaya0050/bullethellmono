using bullethell.classes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct2D1;
using SharpDX.Direct3D9;
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
                game1.wave.Update(GT);
                //game1.enemy1.Update(GT);



            }
        }
        public void Draw(Game1 game1)
        {
            if (game1.loaded)
            {
                game1.wave.Draw(game1._spriteBatch,game1.GraphicsDevice);
                game1.enemy1.Draw(game1._spriteBatch, game1.GraphicsDevice);
                game1.player1.playerDraw(game1._spriteBatch, game1.GraphicsDevice);
            }
            
        }
    }
}
