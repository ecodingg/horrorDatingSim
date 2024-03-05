using Godot;
using System;

public partial class player_cat : CharacterBody2D
{
	[Export]
	public float move_speed = 100;

	[Export]
	public Vector2 starting_direction = new Vector2(0, 1);

	private AnimationTree animation_tree;

	public override void _Ready()
	{
		animation_tree = GetNode<AnimationTree>("AnimationTree");
		animation_tree.Set("parameters/Idle/blend_position", starting_direction);
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 input_direction = new Vector2(
			Input.GetActionStrength("right") - Input.GetActionStrength("left"),
			Input.GetActionStrength("down") - Input.GetActionStrength("up")
		);
		Velocity = input_direction * move_speed;
		MoveAndSlide();
	}
}
