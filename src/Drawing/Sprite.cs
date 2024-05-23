using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Ink.Drawing;

public sealed class Sprite : IDrawable
{
	public Texture2D Texture { get; }
	public Point Position { get; set; } = Point.Zero;
	public float Scale { get; set; } = 1.0f;


	public Sprite(Texture2D texture)
	{
		this.Texture = texture;
	}

	public void Draw(SpriteBatch spriteBatch)
	{
		Point size = (this.Texture.Bounds.Size.ToVector2() * this.Scale).ToPoint();
		spriteBatch.Draw(this.Texture, new Rectangle(this.Position - size, size), Color.White);
	}
}