using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace monopong;

public class Bat
{
    private const float BatSpeed = 20f;
    
    private readonly GraphicsDevice graphicsDevice;
    private readonly BatInput batInput;
    
    private VertexBuffer vertexBuffer;
    private BasicEffect basicEffect;
    private Matrix world = Matrix.CreateTranslation(0, 0, 0);
    private Matrix view = Matrix.CreateLookAt(new Vector3(0, 0, 3), new Vector3(0, 0, 0), new Vector3(0, 1, 0));
    private Matrix projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45), 800f / 480f, 0.01f, 100f);

    private Vector3 position;
    
    public Bat(GraphicsDevice graphicsDevice)
    {
        batInput = new BatInput();
        
        this.graphicsDevice = graphicsDevice;
        basicEffect = new BasicEffect(graphicsDevice);
 
        VertexPositionColor[] vertices = new VertexPositionColor[6];
        vertices[0] = new VertexPositionColor(new Vector3(0.5f, 1, 0), Color.Red);
        vertices[1] = new VertexPositionColor(new Vector3(0.5f, -1, 0), Color.Green);
        vertices[2] = new VertexPositionColor(new Vector3(-0.5f, 1, 0), Color.Blue);
        vertices[3] = new VertexPositionColor(new Vector3(-0.5f, 1, 0), Color.Blue);
        vertices[4] = new VertexPositionColor(new Vector3(0.5f, -1, 0), Color.Green);
        vertices[5] = new VertexPositionColor(new Vector3(-0.5f, -1, 0), Color.Red);
 
        vertexBuffer = new VertexBuffer(graphicsDevice, typeof(VertexPositionColor), 6, BufferUsage.WriteOnly);
        vertexBuffer.SetData<VertexPositionColor>(vertices);
    }

    public void Update(GameTime gameTime)
    {
        var direction = batInput.GetMovementInput();
        position += direction * (float)(BatSpeed * gameTime.ElapsedGameTime.TotalSeconds);
        world = Matrix.CreateTranslation(position);
    }
    
    public void Draw()
    {
        basicEffect.World = world;
        basicEffect.View = view;
        basicEffect.Projection = projection;
        basicEffect.VertexColorEnabled = true;
 
        graphicsDevice.SetVertexBuffer(vertexBuffer);
 
        RasterizerState rasterizerState = new RasterizerState();
        rasterizerState.CullMode = CullMode.None;
        graphicsDevice.RasterizerState = rasterizerState;
 
        foreach (EffectPass pass in basicEffect.CurrentTechnique.Passes)
        {
            pass.Apply();
            graphicsDevice.DrawPrimitives(PrimitiveType.TriangleList, 0, 2);
        }
    }
}