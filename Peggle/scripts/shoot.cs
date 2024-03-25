using Godot;
using System;

public partial class shoot : Node
{
	[Export]
	private PackedScene ball;

	[Export]
	public double offset = 1.0f;

	[Export]
	public double fireRate = 1.0f;
	double lastFire = 0.0f;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		lastFire = fireRate;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		lastFire += delta;
		if(countBall.count.numBall >0)

			if (Input.IsActionJustPressed("click"))
				if (lastFire > fireRate)
				{
					lastFire = 0;

					Node2D oball = (Node2D)ball.Instantiate();
					oball.Position = ((Node2D)GetParent()).GlobalPosition - new Vector2(0, (float)offset);

					GetTree().Root.AddChild(oball);

					// oball.GetChild<move>(0).direction = (this.GetParent<Node2D>().GlobalTransform.Y);

					countBall.count.RemoveBall();

					// Apply force
					RigidBody2D rigidBody = ((RigidBody2D)oball);
					Vector2 force = new Vector2(0,100);
					rigidBody.ApplyCentralImpulse(force);
					// ((RigidBody2D)oball).apply_force(Vector2.Zero,(this.GetParent<Node2D>().GlobalTransform.Y) * 100);

				}
	}
}
