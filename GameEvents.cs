using Godot;
using System;

public class GameEvents : Node
{
    [Signal]
    public delegate void DialogInitiated(Dialogue dialogue);
    [Signal]
    public delegate void foodMousedOver(Food food);
    [Signal]
    public delegate void foodMousedOut();
    [Signal]
    public delegate void foodClicked();
}
