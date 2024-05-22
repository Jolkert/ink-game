using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Ink;
public sealed class InkGame : Game
{
	private GraphicsDeviceManager _graphics;
	private SpriteBatch _spriteBatch;


	public InkGame()
	{
		_graphics = new GraphicsDeviceManager(this);
		Content.RootDirectory = "Content";
		IsMouseVisible = true;
	}

	protected override void Initialize() => base.Initialize();


	protected override void LoadContent()
	{
		_spriteBatch = new SpriteBatch(GraphicsDevice);

		// TODO: use this.Content to load your game content here
	}

	protected override void Update(GameTime gameTime)
	{
		// TODO: Add your update logic here
		this.ProcessInput();
		base.Update(gameTime);
	}
	private void ProcessInput()
	{
		if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
			this.Exit();
	}

	protected override void Draw(GameTime gameTime)
	{
		GraphicsDevice.Clear(Color.Pink);

		// TODO: Add your drawing code here

		// base.Draw(gameTime);
	}
}
