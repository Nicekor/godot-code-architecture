using Godot;
using System;

public class Player : KinematicBody
{
    [Export]
    private float mouseSensitivity = 0.08f;
    [Export]
    private float moveSpeed = 3f;

    public override void _Ready()
    {
        Input.SetMouseMode(Input.MouseMode.Captured);
    }

    public override void _Input(InputEvent inputEvent)
    {
        aim(inputEvent);
    }

    // same as _process except that it's called consistently on the tick inside of the pysics engine which is separate from the game engine 
    public override void _PhysicsProcess(float delta)
    {
        base._PhysicsProcess(delta);
        movement();
    }

    private void aim(InputEvent evt)
    {
        InputEventMouseMotion mouseMotion = evt as InputEventMouseMotion;
        if (mouseMotion != null)
        {
            Camera playerCamera = this.GetNode<Camera>("Camera");
            this.RotationDegrees -= new Vector3(0, mouseMotion.Relative.x, 0) * mouseSensitivity;

            float currentTilt = playerCamera.RotationDegrees.x;
            currentTilt -= mouseMotion.Relative.y * mouseSensitivity;

            playerCamera.RotationDegrees = new Vector3(Mathf.Clamp(currentTilt, -90, 90), 0, 0);
        }
    }

    private void movement()
    {
        Vector3 movementVector = new Vector3();
        Vector3 forwardMovement = new Vector3();
        Vector3 sidewaysMovement = new Vector3();

        if (Input.IsActionPressed("move_forward"))
        {
            forwardMovement = -Transform.basis.z;
        }
        else if (Input.IsActionPressed("move_backward"))
        {
            forwardMovement = Transform.basis.z;
        }

        if (Input.IsActionPressed("move_left"))
        {
            sidewaysMovement = -Transform.basis.x;
        }
        else if (Input.IsActionPressed("move_right"))
        {
            sidewaysMovement = Transform.basis.x;
        }

        movementVector = (forwardMovement + sidewaysMovement).Normalized();

        MoveAndSlide(movementVector * moveSpeed);
    }

}
