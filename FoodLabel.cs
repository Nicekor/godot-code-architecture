using Godot;
using System;

public class FoodLabel : Label
{
    private GameEvents _gameEvents;
    public override void _Ready()
    {
        _gameEvents = GetNode<GameEvents>("/root/GameEvents");
        _gameEvents.Connect(nameof(GameEvents.foodMousedOver), this, nameof(_OnFoodHovered));
        _gameEvents.Connect(nameof(GameEvents.foodMousedOut), this, nameof(_OnFoodUnhovered));
    }

    private void _OnFoodHovered(Food food)
    {
        this.Visible = true;
        this.Text = food.FoodName;
    }

    private void _OnFoodUnhovered()
    {
        this.Visible = false;
    }
}
