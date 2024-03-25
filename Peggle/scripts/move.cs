using Godot;
using System;

public partial class move : Node
{
	[Export]
    public Vector2 direction = Vector2.Zero;
    [Export]
    public double speed = 100.0f;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Vector2 movement = direction * (float)speed * (float)delta;
        this.GetParent<Node2D>().Position += movement; 
	}
}
