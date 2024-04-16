using Godot;
using System;

public partial class followMouse : Node
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
    {
        
        Vector2 worldposMouse = this.GetParent<Node2D>().GetGlobalMousePosition();
        
        Vector2 relativPos = worldposMouse - this.GetParent<Node2D>().Position;

        float rot_z = Mathf.Atan2(relativPos.Y, relativPos.X);
        this.GetParent<Node2D>().Rotation = rot_z-Mathf.Pi/2;
    }
}
