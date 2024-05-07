using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bullethell.classes
{
    internal class gamestates
    {
        public enum state { start,play,load,gameover }
        public state gamestate { get; set; }


        public void UpdateState()
        {
            switch (gamestate)
            {
                case state.start:
                    //startmenu

                    break;


                case state.play:
                    //main game loop

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
