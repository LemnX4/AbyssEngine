using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;


namespace Abyss
{
    public class MyGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public static List<System> Systems = new();
        public static List<System> UpdateSystems = new();
        public static List<System> RenderSystems = new();
        public static List<Entity> Entities = new();

        public static KeyboardManager KeyboardManager = new();
        public static MouseManager MouseManager = new();

        public static int Width = 1280;
        public static int Height = 720;

        public MyGame()
        {
            _graphics = new GraphicsDeviceManager(this);

            _graphics.PreferredBackBufferWidth = Width;
            _graphics.PreferredBackBufferHeight = Height;
            _graphics.ApplyChanges();

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            double deltaTime = gameTime.ElapsedGameTime.TotalMilliseconds;

            MouseManager.Flush(gameTime);
            KeyboardManager.Flush(gameTime);

            foreach (System system in UpdateSystems)
                system.Update(deltaTime);


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);


            foreach (System system in RenderSystems)
                system.Render(_spriteBatch);


            base.Draw(gameTime);
        }
    }
}