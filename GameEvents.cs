using Godot;
using System;

public class GameEvents : Node
{
    [Signal]
    public delegate void DialogInitiated(Dialogue dialogue);
}
