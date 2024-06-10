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
    public class collisionobjects
    {
        public List<entity> entities;
        public List<player> players;
        public Vector2 position;
        public float rotation;
        public int collisionWidth;
        public int collisionHeight;

        public Texture2D basetex;
        public Color color = Color.Blue;
        //for colliding
        Vector2 entitypos;

        public collisionobjects()
        {
            entities = new List<entity>();
            players = new List<player>();
            
            
        }
        public Rectangle hitbox
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, collisionWidth, collisionHeight);
            }
            set
            {

            }
        }

        public virtual void UpdateCollisionObjects()
        {



            if (entities != null)
            {
                foreach (entity entity in entities)
                {
                    if (entity.collider.hitbox.Intersects(hitbox))
                    {
                        if (basetex != null)
                            basetex.SetData(new[] { Color.Red });

                        Console.WriteLine("hit");
                        
                        entity.position = entitypos;
                    }
                    else
                    {
                        if (basetex != null)
                            basetex.SetData(new[] { color });
                        
                        entitypos = entity.position;
                    }
                }
            }

            if (players != null)
            {
                foreach (player player in players)
                {

                    if (player.collider.hitbox.Intersects(hitbox))
                    {
                        if (basetex != null)
                            basetex.SetData(new[] { Color.Red });

                        Console.WriteLine("hit");

                        player.position = entitypos;
                    }
                    else
                    {
                        if (basetex != null)
                            basetex.SetData(new[] { color });

                        entitypos = player.position;
                    }

                }
            }
        }
        public void drawCollider(SpriteBatch SB, GraphicsDevice GD)
        {
            SB.Begin();


            // creates single pixel texture
            if (basetex == null)
            {
                basetex = new Texture2D(GD, 1, 1);
                basetex.SetData(new[] { color });
            }

            SB.Draw(basetex, position, hitbox, Color.White, rotation, new Vector2(0,0), 1f, SpriteEffects.None, 0);

            SB.End();
        }
    }
}
