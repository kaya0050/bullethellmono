using bullethell.classes;
using bullethell.gamestateclasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;


namespace bullethell
{
    public class Game1 : Game
    {
        public GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private GraphicsDevice device;

        List<entity> gameobjects; 

        
        public player player1;
        public collisionobjects testcollider;

        public weGamin weGamin;

        public Texture2D bulletsprite;

        

        private SpriteFont font;

        public enemySpawner enemySpawner;
        new Vector2 spawnpointlocation;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferHeight = 540;
            _graphics.PreferredBackBufferWidth = 720;
            Window.IsBorderless = false;


            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }
        
        protected override void Initialize()
        {
            //gamestates
            weGamin = new weGamin();
            //gamestates = new gamestates();
            gamestates.gamestate = gamestates.state.play;

            
            
            player1 = new player();
            player1.name = "Timmy";
            
            player1.tags = new List<string>();
            //player1.tags.Add("player");
            player1.tags.Add("collision");
            
               
            player1.id = 1;
            player1.position = new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2);

            //enemys
            spawnpointlocation = new Vector2(_graphics.PreferredBackBufferWidth / 2, -10);
            
            
            
            //enemyspawner
            var enemyli = new List<enemy>();
            
            enemySpawner = new enemySpawner(enemyli,player1,spawnpointlocation);
            

            
            testcollider = new collisionobjects();
            testcollider.collisionWidth = 420;
            testcollider.collisionHeight = 69;
            testcollider.position = new Vector2(
                _graphics.PreferredBackBufferWidth / 2 - testcollider.collisionWidth / 2,
                _graphics.PreferredBackBufferHeight / 2 - testcollider.collisionHeight / 2
            );
            


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
                    testcollider.players.Add(player);
                }
            }

            #endregion
            base.Initialize();
        }
          
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("fonts/font");
            bulletsprite = Content.Load<Texture2D>("cross");
            player1.textureforbullet = bulletsprite;
        }

        protected override void Update(GameTime gameTime)
        {
            //esc key closes app
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            { 
                Exit();
            }
            
            
            
            gamestates.UpdateState(gameTime, this, weGamin);

           
            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            enemySpawner.Draw(_spriteBatch,GraphicsDevice);
            player1.playerDraw(_spriteBatch, GraphicsDevice);

            


            _spriteBatch.Begin();
            
            
            _spriteBatch.DrawString(font,"lives:"+ player1.lives +"\n"+ "points:" + player1.points, new Vector2(20, 20), Color.Blue);
            _spriteBatch.End();
            base.Draw(gameTime);
            
        }
    }
}