using System;
using Microsoft.Xna.Framework.Graphics;

public static class SpriteBatchExtentions
{
	public static void Execute(this SpriteBatch self, Action<SpriteBatch> action)
	{
		self.Begin();
		action(self);
		self.End();
	}
}