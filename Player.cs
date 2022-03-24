using Godot;
using System;

public class Player : KinematicBody
{
    [Export]
    private float mouseSensitivity = 0.08f;

    public override void _Ready()
    {
        Input.SetMouseMode(Input.MouseMode.Captured);
    }

    public override void _Input(InputEvent inputEvent)
    {
        InputEventMouseMotion mouseMotion = inputEvent as InputEventMouseMotion;
        if (mouseMotion != null)
        {
            Camera playerCamera = this.GetNode<Camera>("Camera");
            this.RotationDegrees -= new Vector3(0, mouseMotion.Relative.x, 0) * mouseSensitivity;

            float currentTilt = playerCamera.RotationDegrees.x;
            currentTilt -= mouseMotion.Relative.y * mouseSensitivity;

            playerCamera.RotationDegrees = new Vector3(Mathf.Clamp(currentTilt, -90, 90), 0, 0);
        }
    }
}
