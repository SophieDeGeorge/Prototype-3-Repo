extends CharacterBody2D

@export var move_speed: float = 80.0
@export var min_change_time: float = 0.5
@export var max_change_time: float = 2.0
@export var player_detection_radius: float = 1500.0
@export var target_reached_radius: float = 8.0

var player: Node2D

var _rng := RandomNumberGenerator.new()
var _timer: Timer
var _direction: Vector2 = Vector2.ZERO

var chasing_stick: bool = false
var chasing_player: bool = false
var target_pos: Vector2 = Vector2.ZERO
var is_activated: bool = false

@onready var sprite = $Sprite2D    # or $AnimatedSprite2D / $AnimatedSprite2D2D

func _ready() -> void:
	player = get_tree().get_first_node_in_group("player")
	$Area2D.body_entered.connect(_on_body_entered)
	_rng.randomize()

	_timer = Timer.new()
	_timer.one_shot = true
	add_child(_timer)
	_timer.timeout.connect(_choose_new_direction)

	_choose_new_direction()

func _physics_process(delta: float) -> void:
	_update_player_chase()

	if chasing_player:
		_move_towards(target_pos)
	elif chasing_stick:
		_move_towards(target_pos)
	else:
		_move_wander()

	move_and_slide()
	_update_flip()

func _update_player_chase() -> void:
	if player and global_position.distance_to(player.global_position) <= player_detection_radius:
		chasing_player = true
		chasing_stick = false
		target_pos = player.global_position
	else:
		chasing_player = false

func _move_wander() -> void:
	velocity = _direction * move_speed
	if is_on_wall():
		_choose_new_direction()

func _move_towards(target: Vector2) -> void:
	var dir := target - global_position
	if dir.length() <= target_reached_radius:
		if chasing_stick:
			chasing_stick = false
			_choose_new_direction()
		velocity = Vector2.ZERO
		return

	dir = dir.normalized()
	_direction = dir
	velocity = dir * move_speed

func _choose_new_direction() -> void:
	if chasing_player or chasing_stick:
		return

	var dirs: Array[Vector2] = [
		Vector2.LEFT,
		Vector2.RIGHT,
		Vector2.UP,
		Vector2.DOWN
	]
	_direction = dirs[_rng.randi_range(0, dirs.size() - 1)]
	var wait_time = _rng.randf_range(min_change_time, max_change_time)
	_timer.start(wait_time)

func alert_to_stick(stick_global_pos: Vector2) -> void:
	target_pos = stick_global_pos
	chasing_stick = true
	chasing_player = false

func _on_body_entered(body: Node) -> void:
	if body.name != "Player" or is_activated:
		return
	is_activated = true
	var game_root := get_tree().current_scene
	if game_root and game_root.has_method("game_end"):
		game_root.game_end(body, false)

func _update_flip() -> void:
	if not sprite:
		return

	if velocity.x > 0.1:
		sprite.flip_h = false
	elif velocity.x < -0.1:
		sprite.flip_h = true
