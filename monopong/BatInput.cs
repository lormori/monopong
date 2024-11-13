using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace monopong;

public class BatInput
{
    public Vector3 GetMovementInput()
    {
        if (Keyboard.GetState().IsKeyDown(Keys.Down))
        {
            return Vector3.Down;
        }
        if (Keyboard.GetState().IsKeyDown(Keys.Up))
        {
            return Vector3.Up;
        }

        return Vector3.Zero;
    }
}