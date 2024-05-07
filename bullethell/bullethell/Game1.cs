using bullethell.classes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;



namespace bullethell
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private GraphicsDevice device;
        
        

        player player1;
        collisionobjects testcollider;

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
            // TODO: Add your initialization logic here
            //box initialize
            player1 = new player();
            player1.name = "sjonnie";
            player1.tag = "player";
            player1.id = 1;
            player1.position = new Vector2(_graphics.PreferredBackBufferWidth / 4, _graphics.PreferredBackBufferHeight / 4);


            /*box = new entity();
            box.tag = "debugItem";
            box.id = 0;
            box.name = "box";
            box.position = new Vector2(_graphics.PreferredBackBufferWidth / 4, _graphics.PreferredBackBufferHeight / 4);
            */

            //collider initialize
            testcollider = new collisionobjects();
            testcollider.collisionWidth = 128;
            testcollider.collisionHeight = 32;
            testcollider.position = new Vector2(
                _graphics.PreferredBackBufferWidth / 2 - testcollider.collisionWidth / 2,
                _graphics.PreferredBackBufferHeight / 2 - testcollider.collisionHeight / 2
            );

            //testcollider.entities.Add(player1);
            testcollider.players.Add(player1);

            //box.collider.entities.Add(box);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("fonts/font");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                
                Exit();

            }
            
            
            Console.WriteLine(gameTime.TotalGameTime.TotalSeconds);
            
            testcollider.UpdateCollisionObjects();
            player1.playerUpdate(gameTime, _graphics);


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