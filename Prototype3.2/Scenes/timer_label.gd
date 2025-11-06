extends Label

@export var start_time_seconds: int = 90  # 1:30

var time_left: float

func _ready() -> void:
	time_left = float(start_time_seconds)
	_update_text()
	set_process(true)

func _process(delta: float) -> void:
	if time_left <= 0.0:
		return

	time_left -= delta
	if time_left <= 0.0:
		time_left = 0.0
		_update_text()
		_call_game_over()
		set_process(false)
	else:
		_update_text()

func _update_text() -> void:
	var total := int(ceil(time_left))
	var minutes := total / 60
	var seconds := total % 60
	text = "%d:%02d" % [minutes, seconds]

func _call_game_over() -> void:
	var game_root := get_tree().current_scene
	if game_root and game_root.has_method("game_end"):
		game_root.game_end(get_tree().get_first_node_in_group("player"), false)
