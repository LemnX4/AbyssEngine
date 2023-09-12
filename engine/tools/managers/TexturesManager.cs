using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Abyss
{
    public enum SpriteSheetTag
    {
        None,
        Player
    }

    public class SpriteSheet
    {
        public SpriteSheetTag Tag = SpriteSheetTag.None;
        public string TexturePath = null;
        public Texture2D Texture { get; set; } = null;
        public Texture2D HighlightedTexture { get; set; } = null;
        public Point Size { get; set; } = new(0, 0);
        public Point Offset { get; set; } = new(0, 0);
    }

    public class TextureManager
    {
        public ContentManager Content { set; get; } = null;
        public GraphicsDeviceManager DeviceManager { set; get; } = null;
        public SpriteBatch SpriteBatch { set; get; } = null;
        public List<SpriteSheet> SpriteSheets { get; set; } = new List<SpriteSheet>();

        public void LoadSpriteSheetTexture(SpriteSheet spriteSheet)
        {
            Texture2D texture;
            Texture2D highlightedTexture;

            if (spriteSheet.Texture == null && spriteSheet.TexturePath != null)
            {
                texture = Content.Load<Texture2D>(spriteSheet.TexturePath);
            }
            else
                return;


            Color[] data = new Color[texture.Width * texture.Height];

            texture.GetData(data);

            for (int i = 0; i < data.Length; i++)
                if (data[i].A != 0)
                    data[i] = Color.White;

            highlightedTexture = new Texture2D(texture.GraphicsDevice, texture.Width, texture.Height);
            highlightedTexture.SetData(data);

            RenderTarget2D buffer = new RenderTarget2D(DeviceManager.GraphicsDevice, MyGame.Width, MyGame.Height);
            var renderTargets = SpriteBatch.GraphicsDevice.GetRenderTargets();

            SpriteBatch.GraphicsDevice.SetRenderTarget(buffer);

            SpriteBatch spriteBatchBuffer = new SpriteBatch(SpriteBatch.GraphicsDevice);

            SpriteBatch.GraphicsDevice.Clear(Color.Transparent);


            spriteBatchBuffer.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend, SamplerState.PointClamp, null, null, null, null);

            spriteBatchBuffer.Draw(highlightedTexture, new Rectangle(1, 0, texture.Width, texture.Height), Color.White);
            spriteBatchBuffer.Draw(highlightedTexture, new Rectangle(-1, 0, texture.Width, texture.Height), Color.White);
            spriteBatchBuffer.Draw(highlightedTexture, new Rectangle(0, 1, texture.Width, texture.Height), Color.White);
            spriteBatchBuffer.Draw(highlightedTexture, new Rectangle(0, -1, texture.Width, texture.Height), Color.White);


            spriteBatchBuffer.End();

            SpriteBatch.GraphicsDevice.SetRenderTargets(renderTargets);

            spriteSheet.HighlightedTexture = buffer;
            spriteSheet.Texture = texture;
        }
    }
}