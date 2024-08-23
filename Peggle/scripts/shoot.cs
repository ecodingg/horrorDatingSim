using Godot;
using System;

public partial class shoot : Node
{
    [Export]
    private PackedScene ball;

    [Export]
    public double fireRate = 1.0f;
    
    [Export]
    public Vector2 shooterOffset = new Vector2(0, -78); 

    private double lastFire = 0.0f;

    public override void _Ready()
    {
        lastFire = fireRate;
    }

    public override void _Process(double delta)
    {
        lastFire += delta;
        if(countBall.count.numBall > 0)
        {
            if (Input.IsActionJustPressed("click") && lastFire > fireRate)
            {
                lastFire = 0;

                // Get the global position of the mouse cursor
                Vector2 worldposMouse = this.GetParent<Node2D>().GetGlobalMousePosition();
                
                // Position of the shooter node
                Vector2 shooterPosition = ((Node2D)GetParent()).GlobalPosition;

            
                Vector2 direction = (worldposMouse - shooterPosition).Normalized();
                Vector2 adjustedShooterPosition = shooterPosition + direction * shooterOffset.Length();

                Node2D oball = (Node2D)ball.Instantiate();
                
                oball.Position = adjustedShooterPosition;

                float rot_z = Mathf.Atan2(direction.Y, direction.X);
                oball.Rotation = rot_z - Mathf.Pi / 2;

                GetTree().Root.AddChild(oball);

                countBall.count.RemoveBall();

                // Apply force
                RigidBody2D rigidBody = ((RigidBody2D)oball);
                Vector2 force = direction * 500;
                rigidBody.ApplyCentralImpulse(force);
            }
        }
    }
}
