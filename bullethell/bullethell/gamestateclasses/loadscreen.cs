using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bullethell.classes;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using static bullethell.classes.util;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace bullethell.gamestateclasses
{
    
    public class loadscreen
    {
        public SoundEffect start;

        util.modelcol modelcol1;
        
        public loadscreen(util.modelcol modelcol)
        {
            modelcol1 = modelcol;
        }
        public void updateloadscreen()
        {
            
            modelcol1.rotmodel += 0.001f;
            modelcol1.pos3d = new Vector3(-2.75f,-2,0);
            modelcol1.WorldMA = Matrix.CreateRotationY(modelcol1.rotmodel) * Matrix.CreateTranslation(modelcol1.pos3d);
        }
        public void drawloadscreen(SpriteBatch _spriteBatch,Texture2D background)
        {
            _spriteBatch.Begin();
            //_spriteBatch.Draw(background, new Vector2(75, 0), new Rectangle(0, 0, 10000, 10000), Color.Multiply(Color.White, 0.3f), -0.0f, new Vector2(0, 0), new Vector2(20f, 20f), SpriteEffects.None, 0.0f);
            _spriteBatch.End();

            foreach (ModelMesh mesh in modelcol1.model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {

                    effect.View = modelcol1.ViewMA;
                    effect.World = modelcol1.WorldMA;
                    effect.Projection = modelcol1.ProjectionMA;


                }
                mesh.Draw();
            }
        }
    }
}
