using Godot;
using System;
using DialogueManagerRuntime;

public partial class Dialogue_Interactable : Area2D
{
	//custom signal to emit dialogue trigger
	[Signal]
	public delegate void DialogueTriggerEventHandler();
	//bool to detect if dialogue will trigger or not
	public bool dialogueState;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		dialogueState = false;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		//if player is in the dialogue body AND presses interact
		if(Input.IsActionJustPressed("interact") && dialogueState == true)
		{
			//GD.Print("entered");
			
			//DialogueTrigger() signal use in a different scene for different dialogue
			EmitSignal(SignalName.DialogueTrigger);
		}
	}

	//function that signals when player enters dialogue area
	private void _on_body_entered(PhysicsBody2D player)
	{
		dialogueState = true;
	}
	//dialogueState returns to false when player leaves dialogue area
	private void _on_body_exited(PhysicsBody2D player)
	{
		dialogueState = false;
	}
}
