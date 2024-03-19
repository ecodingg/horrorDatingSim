using Godot;
using System;

public partial class Border : StaticBody2D
{
	[Export]
	public Color color = new Color(192,192,192);
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		GetNode<ColorRect>("ColorRect").Modulate = color;
	}
}
