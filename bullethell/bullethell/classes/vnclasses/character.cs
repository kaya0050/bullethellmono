using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bullethell.classes.vnclasses
{
    public class character
    {
        public bool active = true;

        public string name;
        public string title;

        
        public Texture2D sprite;
        public Texture2D[] expressions;

        public Vector2 position;
        public Vector2 scale;

        public Rectangle rectangle
        {
            get
            {
                return new Rectangle((int)position.X,(int)position.Y, 200, 200);
            }
        }
        public character()
        {
            
        }

        public void drawcharacter(SpriteBatch SB)
        {
            if (sprite != null && active)
            {

                SB.Draw(sprite, rectangle, Color.Multiply(Color.White, 1f));

            }
           
        }
    }
}
