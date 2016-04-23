using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using TowerDefense.Lib;
using TowerDefense.Lib.Graphics;
using TowerDefense.Lib.Scene;

namespace TowerDefense
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class TowerDefenseGame : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private GameState _state;

        public GameState State
        {
            get { return _state; }
            set { ChangeState(value); }
        }

        public Dictionary<GameState, Scene> Scenes { get; set; }

        public TowerDefenseGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";


            IsMouseVisible = true;
            IsFixedTimeStep = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Scenes = new Dictionary<GameState, Scene>();
            Scenes[GameState.MainMenu] = new MainMenuScene(this);
            Scenes[GameState.Prototype] = new Prototype(this);

            State = GameState.MainMenu;
            
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            
            GameGraphics.Load(Content);
            

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (Scenes.ContainsKey(State))
                Scenes[State].UpdateKeyboardInput();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            if (Scenes.ContainsKey(State))
            {
                Scenes[State].Draw(gameTime);
            }
            
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        private void ChangeState(GameState value)
        {
            if (Scenes.ContainsKey(value))
            {
                _state = value;
                Scenes[value].Load();
            }
        }
    }
}
