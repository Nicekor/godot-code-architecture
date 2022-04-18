using Godot;
using System;

public class FoodChooserRay : RayCast
{
    public override void _Input(InputEvent e)
    {
        Area collidedArea = GetCollider() as Area;
        if (collidedArea is Food)
        {
            GD.Print(collidedArea.Name);
        }
    }
}
