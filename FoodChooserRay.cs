using Godot;
using System;

public class FoodChooserRay : RayCast
{
    private GameEvents _gameEvents;
    private bool _isMousingOver = false;

    public override void _Ready()
    {
        // todo: this breaks if the fs is changed, should I just attach a reference of the script on the editor(?)
        _gameEvents = GetNode<GameEvents>("/root/GameEvents");
    }

    public override void _Input(InputEvent e)
    {
        Area collidedArea = GetCollider() as Area;

        if (collidedArea is Food food)
        {
            if (!_isMousingOver)
            {
                _isMousingOver = true;
                _gameEvents.EmitSignal(nameof(GameEvents.foodMousedOver), food);
            }
        }
        else if (_isMousingOver)
        {
            _isMousingOver = false;
            _gameEvents.EmitSignal(nameof(GameEvents.foodMousedOut));
        }
    }
}
