extends CharacterBody2D

@export  var move_speed : float = 100
@export  var starting_direction : Vector2 = Vector2(0, 1)
#parameters/Idle/blend_position

#@onready var animation_tree = $AnimationTree

#func _ready():
	#animation_tree.set("parameters/Idle/blend_position", starting_direction) 
func _physics_process(_delta):
	# Get input direction
	var input_direction = Vector2(
		Input.get_action_strength("right") - Input.get_action_strength("left"),
		Input.get_action_strength("down") - Input.get_action_strength("up")
	)
	#print(input_direction)
	
	# Update velocity
	velocity = input_direction * move_speed
	# Move and Slide function uses velocity of character body to move charactr on map
	move_and_slide()
