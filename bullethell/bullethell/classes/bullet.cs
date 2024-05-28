using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bullethell.classes
{
    public class bullet
    {
        public int dmg;


        public float speed;

        public Vector2 position;
        public Vector2 velocity;
        public float direction;

        public Texture2D bulletcolor;

        public collisionobjects collider = new collisionobjects();

        public Rectangle bulletcol
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, 5, 5);
            }
        }
        public bullet(Vector2 position, float rotation)
        {
            collider.collisionWidth = 32;
            collider.collisionHeight = 32;

            this.position = position;

            this.direction = rotation;

        }
        public void Update(GameTime gt)
        {


            

            velocity = new Vector2((float)Math.Cos(direction), (float)Math.Sin(direction)) * 5f;

            position += velocity;

            collider.position = position;



        }
        public void draw(SpriteBatch SB,GraphicsDevice GD)
        {

            if (bulletcolor == null)
            {
                bulletcolor = new Texture2D(GD, 1, 1);
                bulletcolor.SetData(new[] { Color.Red });
            }
            SB.Draw(
                bulletcolor,
                position,
                bulletcol,
                Color.Multiply(Color.White, 1f),
                direction,
                new Vector2(32 / 2, 32 / 2),
                Vector2.One,
                SpriteEffects.None,
                0f
             );
        }
    }
}
