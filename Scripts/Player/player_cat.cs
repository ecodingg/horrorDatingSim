using Godot;
using System;
using Godot.Collections;
using DialogueManagerRuntime;
using System.Threading.Tasks;
using Helpers;

public partial class player_cat : CharacterBody2D
{
	[Export]
	public float move_speed = 100;

	[Export]
	public Vector2 starting_direction = new Vector2(0, 0);

	private AnimationTree animation_tree;
	Area2D actionableFinder;
	Vector2 inputVector = Vector2.Zero;

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

	public override void _UnhandledInput(InputEvent @event)
	{
		if (Input.IsActionJustPressed("interact"))
		{
			Array<Area2D> actionables = actionableFinder.GetOverlappingAreas();
			if (actionables.Count > 0)
			{
				(actionables[0] as Actionable).Action();
				inputVector = Vector2.Zero;
			}
		}

		inputVector = Input.GetVector("left", "right", "up", "down");
	}

}

