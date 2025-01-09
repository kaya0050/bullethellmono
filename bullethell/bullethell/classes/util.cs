using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bullethell.classes
{
    public class util
    {

        public struct modelcol
        {
            public Model model;
            public BasicEffect BasicEffect;
            public Vector3 camTarget;
            public Vector3 Campos;
            public Vector3 pos3d;
            public float rotmodel;
            public Matrix ProjectionMA;
            public Matrix ViewMA;
            public Matrix WorldMA;
            public Matrix modelposMA;
            public modelcol(Model modelS,BasicEffect basicEffectS,
                Vector3 camtargetS,Vector3 camposS,Vector3 pos3dS,
                float rotmodelS,Matrix ProjectionMAS,Matrix ViewMAS,
                Matrix WorldMAS,Matrix ModelposMAS)
            {
                this.model = modelS;
                this.BasicEffect = basicEffectS;
                this.camTarget = camtargetS;
                this.Campos = camposS;
                this.pos3d = pos3dS;
                this.rotmodel = rotmodelS;
                this.ProjectionMA = ProjectionMAS;
                this.ViewMA = ViewMAS;
                this.WorldMA = WorldMAS;
                this.modelposMA = ModelposMAS;
            }
        }

        public void volume(float vol)
        {
            MediaPlayer.Volume = vol;
            
        }
    }
}
