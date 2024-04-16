using Godot;
using System;

public partial class shoot : Node
{
	[Export]
	private PackedScene ball;

	[Export]
	public double offset = 100.0;

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

			if (Input.IsActionJustPressed("click")&& lastFire > fireRate)
				{
					lastFire = 0;

					// Get the global position of the mouse cursor
                	Vector2 worldposMouse = this.GetParent<Node2D>().GetGlobalMousePosition();
                	// Position of the shooter node
                	Vector2 shooterPosition = ((Node2D)GetParent()).GlobalPosition;

               		// Calculate the direction vector from the shooting position to the mouse position
                	Vector2 direction = (worldposMouse - shooterPosition).Normalized();

					Node2D oball = (Node2D)ball.Instantiate();
					// oball.Position = ((Node2D)GetParent()).GlobalPosition - new Vector2(0, (float)offset);
					oball.Position = shooterPosition - new Vector2(0, (float)offset);

					// Rotate the ball to face the direction of the mouse cursor
					float rot_z = Mathf.Atan2(direction.Y, direction.X);
					oball.Rotation = rot_z - Mathf.Pi / 2;


					GetTree().Root.AddChild(oball);

					// oball.GetChild<move>(0).direction = (this.GetParent<Node2D>().GlobalTransform.Y);

					countBall.count.RemoveBall();

					// Apply force
					RigidBody2D rigidBody = ((RigidBody2D)oball);
					// Vector2 force = new Vector2(0,100);
					Vector2 force = direction * 500;
					rigidBody.ApplyCentralImpulse(force);
					// ((RigidBody2D)oball).apply_force(Vector2.Zero,(this.GetParent<Node2D>().GlobalTransform.Y) * 100);

				}
	}
}
