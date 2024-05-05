using Godot;
using System;
using Godot.Collections;
using DialogueManagerRuntime;
using System.Threading.Tasks;
using Helpers;

public partial class skinwalker : CharacterBody2D
{
	[Export] public float MoveSpeed = 300;

	private AnimationTree animationTree;
	private AnimationNodeStateMachinePlayback stateMachine;
	private Area2D actionableFinder;

	private Vector2 inputVector = Vector2.Zero;
	private Vector2 lastDirection = new Vector2(0, -1);

	public override void _Ready()
	{
		animationTree = GetNode<AnimationTree>("AnimationTree");
		stateMachine = (AnimationNodeStateMachinePlayback)animationTree.Get("parameters/playback");

		actionableFinder = GetNode<Area2D>("ActionableFinder");
	}

	public override void _PhysicsProcess(double delta)
	{
		// Read input for movement
		inputVector = new Vector2(
			Input.GetActionStrength("right") - Input.GetActionStrength("left"),
			Input.GetActionStrength("down") - Input.GetActionStrength("up")
		);

		// Transition between Idle and Walk based on movement
		if (inputVector != Vector2.Zero)
		{
			// Normalize to avoid faster diagonal speed
			inputVector = inputVector.Normalized();

			// Update last direction when moving
			lastDirection = inputVector;
			
			// Set to "Walk" state and update blend position
			stateMachine.Travel("Walk"); // Transition to Walk state
			animationTree.Set("parameters/Walk/blend_position", lastDirection);
			Velocity = inputVector.Normalized() * MoveSpeed;
		}
		else
		{
			// Set to "Idle" state if no movement
			stateMachine.Travel("Idle");
			animationTree.Set("parameters/Idle/blend_position", lastDirection);
			Velocity = Vector2.Zero;
		}

		MoveAndSlide();
	}

	public override void _UnhandledInput(InputEvent @event)
	{
		if (Input.IsActionJustPressed("interact"))
		{
			var actionables = actionableFinder.GetOverlappingAreas();
			if (actionables.Count > 0)
			{
				var actionable = actionables[0] as Actionable;
				actionable?.Action();
			}
		}
	}
}
