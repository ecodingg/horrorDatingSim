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
        //position de la sourie dans la vue 3d 
        Vector2 worldposMouse = this.GetParent<Node2D>().GetGlobalMousePosition();

        //position de la sourie par raport objet
        Vector2 relativPos = worldposMouse - this.GetParent<Node2D>().Position;

        //rotation de l'objet
        float rot_z = Mathf.Atan2(relativPos.Y, relativPos.X);
        this.GetParent<Node2D>().Rotation = rot_z-Mathf.Pi/2;
    }
}
