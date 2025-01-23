using bullethell.audioengine.audiomanagers;
using bullethell.classes;
using bullethell.classes.vnclasses;
using bullethell.gamestateclasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using static bullethell.classes.util;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using bullethell.classes.bosses;


namespace bullethell
{
    
    public class Game1 : Game
    {
        RasterizerState rasterizerState;
        public util uti;

        #region bosses
        public boss1 boss1;
        #endregion


        #region 3d
        Matrix modelposMA;
        Model Modelload;
        BasicEffect BasicEffect;
        Vector3 camTarget;
        Vector3 Campos;
        Vector3 pos3d;
        float rotmodel = 1.57f;
        Matrix ProjectionMA;
        Matrix ViewMA;
        Matrix WorldMA;

        loadscreen loadscreen1;
        util.modelcol modelcol1;
        #endregion

        #region audio
        public Song testsound;

        #endregion  

        #region novelthings
        public character testchar1 = new character();
        public Texture2D textbox;
        public Texture2D test;

        #endregion

        #region player
        public Texture2D playersprite;
        #endregion

        #region testboss
        public Texture2D testbosssprite;
        #endregion

        public bool loaded = false;
        public GraphicsDeviceManager _graphics;
        public SpriteBatch _spriteBatch;
        public GraphicsDevice device;

        public enemy enemy1;



        List<entity> gameobjects; 

        
        public player player1;
        public collisionobjects testcollider;

        public weGamin weGamin;

        public Texture2D bulletsprite;

        public SpriteFont font;

        public Texture2D background;


        public Vector2 windDir = new Vector2(0f,0f);


        #region testcharacter
        public character testcharacter;
        public Texture2D testCharsprite;

        #endregion

        #region spawner
        public List<int> numbers;
        public waveSystem wave;
        new Vector2 spawnpointlocation;
        #endregion
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferHeight = 800;
            _graphics.PreferredBackBufferWidth = 1280;
            Window.IsBorderless = false;
            _graphics.PreferMultiSampling = true;

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }
        
        protected override void Initialize()
        {
            rasterizerState = new RasterizerState();
            rasterizerState.CullMode = CullMode.None;
            //gamestates
            weGamin = new weGamin();
            //gamestates = new gamestates();
            gamestates.gamestate = gamestates.state.play;


            player1 = new player();
            player1.name = "Timmy";
            
            player1.tags = new List<string>();
            //player1.tags.Add("player");
            player1.tags.Add("collision");

            uti = new util();

            uti.volume(1f);

            player1.id = 1;
            player1.position = new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2);

            //enemys
            spawnpointlocation = new Vector2(_graphics.PreferredBackBufferWidth / 2, -10);


            enemy1 = new enemy(player1);
            enemy1.alive = true;

            //enemyspawner
            var enemyli = new List<enemy>();
            enemyli.Add(enemy1);


            numbers = new List<int>();
            numbers.Add(3);
            numbers.Add(3);
            numbers.Add(2);
            numbers.Add(1);
            numbers.Add(1);
            //enemySpawner = new enemySpawner(enemyli,player1,spawnpointlocation);
            wave = new waveSystem(enemyli, numbers, player1);

            #region 3d
            camTarget = new Vector3(0, 0, 0);
            Campos = new Vector3(0, 2, -10);
            ProjectionMA = Matrix.CreatePerspectiveFieldOfView(
                MathHelper.ToRadians(30),
                GraphicsDevice.DisplayMode.AspectRatio,/*minimum render distance*/1,/*maximum render distance*/100
            );
            ViewMA = Matrix.CreateLookAt(Campos, camTarget, Vector3.Up);
            WorldMA = Matrix.CreateWorld(camTarget, Vector3.Forward, Vector3.Up);
            modelposMA = Matrix.CreateLookAt(pos3d, Vector3.Forward, Vector3.Up);
            #endregion

            #region novel
            testchar1.name = "namepie";
            testchar1.title = "shrinepriest";
            #endregion

            #region sorting gameObjects
            gameobjects = new List<entity>();

            gameobjects.Add(player1);

            
            foreach (entity entity in gameobjects)
            {
                if (!(entity is player))
                {
                    if (entity.tags.Contains("collision"))
                    {
                        testcollider.entities.Add(entity);
                    }
                }
                
                if(entity is player player && entity.tags.Contains("collision"))
                {

                }
            }

            #endregion

            //Console.WriteLine(Modelload.ToString());
            #region bosses
            boss1 = new boss1(player1);
            #endregion




            base.Initialize();
            
        }
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            
            load2d();
            load3d();
            loadaudio();
            initafterloading();
            //loaded = true;
        }

        protected override void Update(GameTime gameTime)
        {

            

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            { 
                Exit();
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {


            }
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            {
                this.Exit();
            }
            if (GamePad.GetState(PlayerIndex.One).Buttons.Start == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                loaded = true;
                MediaPlayer.Play(testsound);
                MediaPlayer.IsRepeating = false;
            }
            player1.position += (windDir * new Vector2((float)gameTime.ElapsedGameTime.TotalSeconds, (float)gameTime.ElapsedGameTime.TotalSeconds));
            
            gamestates.UpdateState(gameTime, this, weGamin);

            loadscreen1.updateloadscreen();
            
            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
           
            drawinback();

            gamestates.drawstate(this,weGamin,device);

             
            //moet nog naar ui class verplaatst worden
            if (loaded)
            {
                _spriteBatch.Begin();
                _spriteBatch.DrawString(font, "lives:" + player1.lives + "\n" + "points:" + player1.points, new Vector2(20, 20), Color.Blue);
                _spriteBatch.End();
            }
            else
            {
                _spriteBatch.Begin();
                _spriteBatch.DrawString(font, "loading", new Vector2(20, 20), Color.Blue);
                _spriteBatch.End();

                loadscreen1.drawloadscreen(_spriteBatch,bulletsprite);
            }
            


            

            base.Draw(gameTime);
            
        }
        void drawinback()
        {
            // objects in bg draw here
            _spriteBatch.Begin();
            _spriteBatch.Draw(background, new Vector2(75, 0), new Rectangle(0, 0, 10000, 10000), Color.Multiply(Color.White, 1f), -0.0f, new Vector2(0, 0), new Vector2(0.32f, 0.32f), SpriteEffects.None, 0.0f);
            _spriteBatch.End();
        }
        void load3d()
        {
            Modelload = Content.Load<Model>("3dmodels/sword");
        }
        void load2d()
        {
            font = Content.Load<SpriteFont>("fonts/font");
            bulletsprite = Content.Load<Texture2D>("sprites/bullet");
            background = Content.Load<Texture2D>("bg");
            textbox = Content.Load<Texture2D>("vnassets/textbox");
            test = Content.Load<Texture2D>("vnassets/test");
            playersprite = Content.Load<Texture2D>("sprites/witch");
            player1.textureforbullet = bulletsprite;

        }
        void loadaudio()
        {
            testsound = Content.Load<Song>("audio/test");
        }
        void initafterloading()
        {
            modelcol1 = new util.modelcol(Modelload, BasicEffect, camTarget, Campos, pos3d, rotmodel, ProjectionMA, ViewMA, WorldMA, modelposMA);
            loadscreen1 = new loadscreen(modelcol1);
            player1.playertexture = playersprite;
        }
    }
}