using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bullethell.classes
{
    public class item
    {
        struct healitem
        {
            public int id;
            public int hp;
            public string name;
        }
        struct combatitem
        {
            public int id;
            public int dmg;
            public string name;
            public void func()
            {

            }
        }
    }
}
