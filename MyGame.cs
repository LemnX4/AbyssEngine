using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;


namespace Abyss
{
    public class MyGame : Game
    {
        public static GraphicsDeviceManager graphics;
        public static SpriteBatch spriteBatch;

        public static List<System> Systems = new();
        public static List<System> UpdateSystems = new();
        public static List<System> RenderSystems = new();
        public static List<Entity> Entities = new();

        public static KeyboardManager KeyboardManager = new();
        public static MouseManager MouseManager = new();
        public static TexturesManager TexturesManager = new();

        public static int Width = 1280;
        public static int Height = 720;

        public static int SPS = 4;

        public MyGame()
        {
            graphics = new GraphicsDeviceManager(this);

            graphics.PreferredBackBufferWidth = Width;
            graphics.PreferredBackBufferHeight = Height;
            graphics.ApplyChanges();

            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            TexturesManager.Content = Content;
            TexturesManager.SpriteBatch = spriteBatch;
            TexturesManager.DeviceManager = graphics;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

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
                system.Render(spriteBatch);


            base.Draw(gameTime);
        }
    }
}