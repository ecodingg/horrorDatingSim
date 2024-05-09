using Godot;
using System;
using DialogueManagerRuntime;

public partial class test_scene : Node2D
{
	bool dialogueActive;
	private CharacterBody2D _playerCat;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_playerCat = GetNode<CharacterBody2D>("PlayerCat"); //refer to player node
		dialogueActive = false;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		GD.Print(_playerCat);
		//dialogue is active means player won't move
		if(dialogueActive)
		{
			
		}
		else
		{
			
		}
	}
	
	//dialogue trigger event sample
	private void _on_dialogue_interactable_dialogue_trigger()
	{
		dialogueActive = true;
		
		//example dialogue provided from addon creators
		var dialogue = GD.Load<Resource>("res://Dialogue/test.dialogue");
		DialogueManager.ShowExampleDialogueBalloon(dialogue, "start");
		
		//built in function when a dialogue finishes
		DialogueManager.DialogueEnded += (dialogue) =>
		{
			GD.Print("dialogue finished");
			dialogueActive = false;
		};
	}
}
