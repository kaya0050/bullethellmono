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

        //make public or else no Update???
        public player player1;
        public collisionobjects testcollider;

        public weGamin weGamin;
        


        private SpriteFont font;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferHeight = 540;
            _graphics.PreferredBackBufferWidth = 720;

            

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
            player1.name = "Player name";
            
            player1.tags = new List<string>();
            //player1.tags.Add("player");
            player1.tags.Add("collision");
            

            player1.id = 1;
            player1.position = new Vector2(_graphics.PreferredBackBufferWidth / 4, _graphics.PreferredBackBufferHeight / 4);

            
            
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
            
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            { 
                Exit();
            }

            Console.WriteLine(testcollider.entities.Count);
            gamestates.UpdateState(gameTime, this, weGamin);

            //weGamin.Update(gameTime,this);



            Console.Clear();
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
           

            player1.playerDraw(_spriteBatch, GraphicsDevice);
            testcollider.drawCollider(_spriteBatch, GraphicsDevice);
            _spriteBatch.Begin();
            _spriteBatch.DrawString(font, player1.name + "\n" + ((int)gameTime.TotalGameTime.TotalSeconds), new Vector2(20, 20), Color.Red);
            _spriteBatch.End();
            base.Draw(gameTime);
            
        }
    }
}