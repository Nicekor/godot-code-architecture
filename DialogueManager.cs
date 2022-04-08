using Godot;
using System;

public class DialogueManager : Control
{
    [Export]
    private NodePath dialogTextPath;

    private Label dialogText;

    public override void _Ready()
    {
        dialogText = GetNode<Label>(dialogTextPath);
        dialogText.Text = "Welcome to the game!";
    }
}
