using Godot;
using System;

public class FoodQuizz : Spatial
{
    [Export]
    private Resource _dialogue;

    private GameEvents _gameEvents;

    public override void _Ready()
    {
        // todo: this breaks if the fs is changed, should I just attach a reference of the script on the editor(?)
        _gameEvents = GetNode<GameEvents>("/root/GameEvents");
    }

    private void _OnDialogTriggerBodyEntered(Node body)
    {
        if (_dialogue is Dialogue dialogue)
        {
            _gameEvents.EmitSignal(nameof(GameEvents.DialogInitiated), dialogue);
        }
    }
}