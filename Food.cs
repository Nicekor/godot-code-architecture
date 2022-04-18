using Godot;
using System;

public class Food : Area
{
    private GameEvents _gameEvents;
    private SpotLight spotLight;

    public override void _Ready()
    {
        // todo: this breaks if the fs is changed, should I just attach a reference of the script on the editor(?)
        _gameEvents = GetNode<GameEvents>("/root/GameEvents");
        spotLight = GetNode<SpotLight>("SpotLight");

        _gameEvents.Connect(nameof(GameEvents.foodMousedOver), this, nameof(_OnMouseEntered));
        _gameEvents.Connect(nameof(GameEvents.foodMousedOut), this, nameof(_OnMouseOut));
    }

    private void _OnMouseEntered(Food food)
    {
        if (food == this)
        {
            spotLight.Visible = true;
        }
    }

    private void _OnMouseOut()
    {
        spotLight.Visible = false;
    }
}
