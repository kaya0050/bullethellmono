using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bullethell.classes
{
    internal class entity
    {
        public int id;
        public string tag;
        public List<string> tags;
        
        public string name;
        public Texture2D basetex;
        public Color color = Color.White;


        public Vector2 position;
        public float rotation;
        public int width = 32;
        public int height = 32;

        public collisionobjects collider = new collisionobjects();
        public entity()
        {
            collider.collisionWidth = 64;
            collider.collisionHeight = 64;
            
        }
        public Rectangle hitbox
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, width, height);
            }
        }
        
        public void entityUpdate(GameTime GT, GraphicsDeviceManager graphics)
        {
            
        }
        public void drawEntity(SpriteBatch SB,GraphicsDevice GD)
        {
            collider.color = Color.DarkGray;
            collider.drawCollider(SB, GD);
            SB.Begin();
          

            // creates single pixel texture
            if (basetex == null)
            {
                basetex = new Texture2D(GD, 1, 1);
                basetex.SetData(new[] { color });
            }
            
            SB.Draw(basetex,position, hitbox, Color.Multiply(Color.White,1f), rotation,new Vector2(0, 0),1f,SpriteEffects.None,1);

            SB.End();
            
        }


    }
}
