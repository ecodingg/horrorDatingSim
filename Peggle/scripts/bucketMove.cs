using Godot;
using System;

public partial class bucketMove : Node
{
	[Export]
	public float speed = 100.0f;
	[Export]
	public float min = -100.0f;
	[Export]
	public float max = 100.0f;

	bool doRight = true;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Node2D transform = this.GetParent<Node2D>();
		if(doRight){
			transform.Position += new Vector2((float)(delta * speed),0);
			if(transform.Position.X > max){
				transform.Position = new Vector2(max, transform.Position.Y);
				doRight = !doRight;
			}
		}
		else{
			transform.Position -= new Vector2((float)(delta * speed),0);
			if(transform.Position.X < min){
				transform.Position = new Vector2(min, transform.Position.Y);
				doRight = !doRight;
			}
		}
	}
}
