using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bullethell.classes.vnclasses
{
    public class visualnovel
    {
        Dictionary<string,string> textandname = new Dictionary<string,string>();
        public inputManager inputmanager = new inputManager();

        public List<character> characters;

        #region textures
        public Texture2D BG;
        public Texture2D textbox;
        
        public List<Texture2D> charactersprites;
        #endregion
        public int currentline;

        public List<string> Text;
        public List<string> Charnames;

        public bool nexttext;
        public bool end = false;

        public character character;

        Rectangle textboxrect
        {
            get
            {
                return new Rectangle(140, 460, 1000, 300);
            }
        }


        public visualnovel(bool test)
        {
            character = new character();

            characters = new List<character>();

            characters.Add(character);


            Text = new List<string>();
            Text.Add("hello");
            Text.Add("this is a test");
            Text.Add("test test");
            Text.Add("wow");
            Text.Add("super cool");
            Text.Add("(o_0)");
            Text.Add("coolie joelie so cool blabla bla bla cool blabla bla bla \ncool blabla bla bla cool blabla bla bla");
            Text.Add("endtext");

            Charnames = new List<string>();
            Charnames.Add("namepie");
            Charnames.Add("tommy");
            Charnames.Add("namepie");
            Charnames.Add("tommy");
            Charnames.Add("name4");
            Charnames.Add("name5");
            Charnames.Add("name6");
            Charnames.Add("name7");
        }
        public visualnovel()
        {
            
        }
        public void updatetext()
        {
            inputmanager.Shoot();
            inputmanager.Menu();
            if (!end)
            {
                if (Text[currentline] == "endtext")
                {
                    end = true;
                }
                #region textcontroller
                if (!inputmanager.Accept)
                {
                    nexttext = false;
                }
                
                if (!nexttext && inputmanager.Accept)
                {
                    if (Text != null && Text[currentline] != null)
                    {
                        if (currentline < Text.Count - 1 && !nexttext)
                        {
                            character.position = new Vector2(130 + (currentline * 10), 300);
                            currentline++;
                            nexttext = true;
                        }
                    }


                }
                #endregion
            }

        }
        public void drawtext(SpriteBatch SB,SpriteFont font)
        {
            

            SB.Begin();
            if (end)
            {
                //SB.Draw(textbox, new Rectangle(-200, -700, 10000, 10000), Color.Black);
            }
            if (!end)
            {
                foreach(character c in characters)
                {
                    c.drawcharacter(SB);
                }
                
                if (Text != null && Text[currentline] != null)
                {
                    if (textbox != null)
                    {
                        SB.Draw(textbox, textboxrect, Color.Multiply(Color.White, 0.9f));
                    }
                    if(Text[currentline] != "endtext")
                    {
                        SB.DrawString(font, Text[currentline], new Vector2(180, 540), Color.White);
                        SB.DrawString(font, Charnames[currentline], new Vector2(180, 490), Color.White);
                    }
                   
                }
                else
                {
                    SB.DrawString(font, "error:: no text to display", new Vector2(500, 600), Color.White);
                }
                
            }
            SB.End();
            
        }


    }
}
