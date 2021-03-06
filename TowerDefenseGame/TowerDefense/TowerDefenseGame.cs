﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using TowerDefense.Lib;
using TowerDefense.Lib.Graphics;
using TowerDefense.Lib.Input;
using TowerDefense.Lib.Objects;
using TowerDefense.Lib.Scene;
using Color = Microsoft.Xna.Framework.Color;
using Rectangle = Microsoft.Xna.Framework.Rectangle;
using Size = System.Drawing.Size;

namespace TowerDefense
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class TowerDefenseGame : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        RenderTarget2D renderTarget;
        Texture2D shadowMap;



        public static Size WindowSize;
        public static Size NativeResolution = new Size(1920, 1080);

        public static Rectangle WindowBounds
        {
            get { return new Rectangle(0, 0, WindowSize.Width, WindowSize.Height); }
        }

        public static Rectangle NativeResolutionBounds
        {
            get { return new Rectangle(0, 0, NativeResolution.Width, NativeResolution.Height); }
        }
        
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

            WindowSize = new Size(1366, 768);

            SetResolution(WindowSize.Width, WindowSize.Height);

            IsMouseVisible = true;
            IsFixedTimeStep = true;

        }

        private void SetResolution(int width, int height)
        {
            graphics.PreferredBackBufferWidth = width;
            graphics.PreferredBackBufferHeight = height;
            graphics.ApplyChanges();
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

            //State = GameState.Prototype;

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

            State = GameState.Prototype;

            PresentationParameters pp = GraphicsDevice.PresentationParameters;
            renderTarget = new RenderTarget2D(GraphicsDevice, NativeResolution.Width, NativeResolution.Height, true, GraphicsDevice.DisplayMode.Format, DepthFormat.Depth24);


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
            InputManager.MouseState = Mouse.GetState();
            InputManager.KeyboardState = Keyboard.GetState();
            
            if (Scenes.ContainsKey(State))
                Scenes[State].UpdateKeyboardInput();

            // Verifica o estado 
            if (IsActive)
            {
                if (InputManager.MouseState.LeftButton == ButtonState.Released && InputManager.LastMouseState.LeftButton == ButtonState.Pressed)
                {
                    MouseClick(MouseButton.Left);
                }
                else if (InputManager.MouseState.LeftButton == ButtonState.Pressed)
                {
                    MouseDown(MouseButton.Left);
                }

                if (InputManager.MouseState.RightButton == ButtonState.Released && InputManager.LastMouseState.RightButton == ButtonState.Pressed)
                {
                    MouseClick(MouseButton.Right);
                }
                else if (InputManager.MouseState.RightButton == ButtonState.Pressed)
                {
                    MouseDown(MouseButton.Right);
                }

                Scenes[State].Update(gameTime);
            }

            InputManager.LastKeyboardState = InputManager.KeyboardState;
            InputManager.LastMouseState = InputManager.MouseState;

            base.Update(gameTime);
        }

        private void MouseDown(MouseButton mouseButton)
        {
            Scenes[State].MouseDown(mouseButton);
        }

        private void MouseClick(MouseButton mouseButton)
        {
            Scenes[State].MouseClick(mouseButton);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.SetRenderTarget(renderTarget);
            
            if (Scenes.ContainsKey(State))
            {
                Scenes[State].Draw(gameTime);
                Scenes[State].Update(gameTime);
            }

            GraphicsDevice.SetRenderTarget(null);
            shadowMap = (Texture2D)renderTarget;

            GraphicsDevice.Clear(ClearOptions.Target | ClearOptions.DepthBuffer, Color.DarkSlateBlue, 1.0f, 0);

            using (var sprite = new SpriteBatch(GraphicsDevice))
            {
                sprite.Begin();
                sprite.Draw(shadowMap, new Rectangle(0, 0, WindowSize.Width, WindowSize.Height), Color.White);
               
                sprite.End();
            }            

            base.Draw(gameTime);
        }

        // Use esse cara quando quiser mudar de um estado do jogo para o outro
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