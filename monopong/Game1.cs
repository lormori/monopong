using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace monopong;

public class Game1 : Game
{
    private GraphicsDeviceManager graphics;
    private Bat playerTwo;
    private Bat playerOne;

    public Game1()
    {
        graphics = new GraphicsDeviceManager(this);
        
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        base.Initialize();
    }

    protected override void LoadContent()
    {
        playerOne = new Bat(GraphicsDevice);
        playerTwo = new Bat(GraphicsDevice);
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        playerOne.Update(gameTime);
        
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        playerOne.Draw();
        
        base.Draw(gameTime);
    }
}