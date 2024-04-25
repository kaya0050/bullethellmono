using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bullethell.classes
{
    internal class entity
    {
        public int id;
        public string tag;
        public string name;
        public Texture2D basetex;
        public Vector2 position;
        public float rotation;
        public entity()
        {

        }
        public Rectangle hitbox
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, 32, 64);
            }
        }
        public void entityUpdate(GameTime GT)
        {
            #region debug
            MouseState mouse = Mouse.GetState();
            var distance = new Vector2(mouse.X - position.X, mouse.Y - position.Y);
            //rotation = (float)Math.Atan2(distance.Y, distance.X);
            rotation = 0;
            
            var keystateplayer = Keyboard.GetState();

            if (keystateplayer.IsKeyDown(Keys.W))
            {
                position.Y -= 100 * (float)GT.ElapsedGameTime.TotalSeconds;
            }
            if (keystateplayer.IsKeyDown(Keys.S))
            {
                position.Y += 100 * (float)GT.ElapsedGameTime.TotalSeconds;
            }
            if (keystateplayer.IsKeyDown(Keys.A))
            {
                float pp = MathF.Sin((((float)GT.TotalGameTime.TotalSeconds * 10)));
                rotation = pp / 5;
                position.X -= 100 * (float)GT.ElapsedGameTime.TotalSeconds;
            }
            if (keystateplayer.IsKeyDown(Keys.D))
            {
                float pp = MathF.Sin((((float)GT.TotalGameTime.TotalSeconds * 10)));
                rotation = pp / 5;
                position.X += 100 * (float)GT.ElapsedGameTime.TotalSeconds;
            }
            #endregion
        }
        public void drawEntity(SpriteBatch SB,GraphicsDevice GD)
        {
            SB.Begin();

            
            // creates single pixel texture
            if (basetex == null)
            {
                basetex = new Texture2D(GD, 1, 1);
                basetex.SetData(new[] { Color.White });
            }

            SB.Draw(basetex,position, hitbox, Color.Multiply(Color.White,1), rotation,new Vector2(hitbox.Width/2,hitbox.Height/2),1f,SpriteEffects.None,0);

            SB.End();
        }


    }
}
