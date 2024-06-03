extends Area2D

@export var dialogue_resource: DialogueResource
@export var dialoague_start: String = "start"

func action() -> void:
	DialogueManager.show_example_dialogue_balloon(dialogue_resource, dialoague_start)
