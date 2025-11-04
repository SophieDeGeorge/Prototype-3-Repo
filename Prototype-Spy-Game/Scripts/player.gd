extends CharacterBody2D

@export var move_speed: float = 1000.0
var is_frozen: bool = false

func _physics_process(delta: float) -> void:
	if is_frozen:
		velocity = Vector2.ZERO
		move_and_slide()
		return

	var input_vec := Vector2(
		Input.get_action_strength("move_right") - Input.get_action_strength("move_left"),
		Input.get_action_strength("move_down") - Input.get_action_strength("move_up")
	)

	if input_vec.length() > 0.0:
		input_vec = input_vec.normalized()

	velocity = input_vec * move_speed
	move_and_slide()

func freeze_player() -> void:
	is_frozen = true
