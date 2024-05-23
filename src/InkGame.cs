using System;
using System.Collections.Generic;
using System.Linq;
using Ink.Drawing;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Ink;
public sealed class InkGame : Game
{
	private GraphicsDeviceManager _graphics;

	// this is allowed to be null from the constructor since it gets set in LoadContent() -morgan 2024-05-22
	private SpriteBatch _spriteBatch = null!;

	private Dictionary<string, Texture2D> _textureMap;
	private Dictionary<string, Sprite> _spriteMap;

	public InkGame()
	{
		_graphics = new GraphicsDeviceManager(this);
		_textureMap = new Dictionary<string, Texture2D>();
		_spriteMap = new Dictionary<string, Sprite>();

		this.Content.RootDirectory = "Content";
		this.IsMouseVisible = true;
	}

	protected override void Initialize() => base.Initialize();


	protected override void LoadContent()
	{
		_spriteBatch = new SpriteBatch(this.GraphicsDevice);
		LoadTextures(new string[] { "enemy", "player" });

		_spriteMap.Add("player", new Sprite(_textureMap["player"])
		{
			Position = new Point(160, 250),
			Scale = 2.0f
		});
		_spriteMap.Add("enemy", new Sprite(_textureMap["enemy"])
		{
			Position = new Point(660, 250),
			Scale = 2.0f
		});
	}

	private void LoadTextures(string[] textureIds)
	{
		foreach (string id in textureIds)
		{
			LoadTexture(id);
		}
	}
	private void LoadTexture(string textureId)
	{
		string filePath = $"assets/sprites/{textureId}";
		_textureMap[textureId] = this.Content.Load<Texture2D>(filePath);
	}

	protected override void Update(GameTime gameTime)
	{
		// TODO: Add your update logic here
		ProcessInput();
		base.Update(gameTime);
	}
	private void ProcessInput()
	{
		if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
			this.Exit();
	}

	protected override void Draw(GameTime gameTime)
	{
		this.GraphicsDevice.Clear(Color.Pink);

		_spriteBatch.Execute((spriteBatch) =>
		{
			foreach ((_, Sprite sprite) in _spriteMap)
			{
				sprite.Draw(spriteBatch);
			}

		});
		base.Draw(gameTime);
	}
}
