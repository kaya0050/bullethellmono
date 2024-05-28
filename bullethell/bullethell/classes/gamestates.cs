using bullethell.gamestateclasses;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bullethell.classes
{
    public static class gamestates
    {
        
        public enum state { start,play,load,gameover }
        public static state gamestate { get; set; }
        
        public static void UpdateState(GameTime gameTime,Game1 game1,weGamin weGamin)
        {
            switch (gamestate)
            {
                case state.start:
                    //startmenu

                    break; 


                case state.play:
                    //main game loop
                    weGamin.webegamin = true;
                    weGamin.Update(gameTime,game1);
                    break;


                case state.load:
                    //loading

                    break;


                case state.gameover:
                    //gameover menu

                    break;


                default:

                    break;
            }
        }

    }
}
