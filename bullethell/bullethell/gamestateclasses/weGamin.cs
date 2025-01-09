using bullethell.classes;
using bullethell.classes.vnclasses;
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
        public visualnovel visualnovel = new visualnovel(true);
        public void Update(GameTime GT,Game1 game1)
        {
            if (webegamin)
            {
                if (game1.loaded)
                {
                   
                    visualnovel.updatetext();
                    visualnovel.textbox = game1.textbox;
                    visualnovel.character.sprite = game1.test;
                    //visualnovel.character.position = new Vector2 (130,300);
                    if (visualnovel.end)
                    {
                        game1.player1.playerUpdate(GT, game1._graphics);
                        game1.wave.Update(GT);
                    }
                }




            }

        }
        public void Draw(Game1 game1)
        {
            if (webegamin)
            {
                if (game1.loaded)
                {
                    if (visualnovel.end)
                    {
                        game1.wave.Draw(game1._spriteBatch, game1.GraphicsDevice);
                        game1.player1.playerDraw(game1._spriteBatch, game1.GraphicsDevice);
                    }
                    
                    visualnovel.drawtext(game1._spriteBatch, game1.font);
                }
            }
            
            
        }
    }
}
