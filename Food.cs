using Godot;
using System;

public class Food : Area
{
    [Export]
    public string FoodName;
    private GameEvents _gameEvents;
    private SpotLight _spotLight;
    private float _spinSpeed = 180;
    [Export]
    private NodePath _foodMeshPath;
    private Spatial _foodMesh;

    public override void _Ready()
    {
        // todo: this breaks if the fs is changed, should I just attach a reference of the script on the editor(?)
        _gameEvents = GetNode<GameEvents>("/root/GameEvents");
        _spotLight = GetNode<SpotLight>("SpotLight");
        _foodMesh = GetNode<Spatial>(_foodMeshPath);

        _gameEvents.Connect(nameof(GameEvents.foodMousedOver), this, nameof(_OnMouseEntered));
        _gameEvents.Connect(nameof(GameEvents.foodMousedOut), this, nameof(_OnMouseOut));
    }

    public override void _Process(float delta)
    {
        if (_spotLight.Visible)
        {
            _foodMesh.RotationDegrees += new Vector3(0, _spinSpeed, 0) * delta;
        }
    }

    private void _OnMouseEntered(Food food)
    {
        if (food == this)
        {
            _spotLight.Visible = true;
        }
    }

    private void _OnMouseOut()
    {
        _spotLight.Visible = false;
    }
}
