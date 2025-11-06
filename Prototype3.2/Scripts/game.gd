extends Node2D

@export var body_scene: PackedScene
@export var enemy_scene: PackedScene
var rng := RandomNumberGenerator.new()
var is_game_over: bool = false

func game_end(player: Node, is_win: bool) -> void:
	if is_game_over:
		return
	is_game_over = true

	if player.has_method("freeze_player"):
		player.freeze_player()

	if is_win:
		$UIFolder/YouWin/YouWinLabel.visible = true
	else:
		$UIFolder/GameOver/GameOverLabel.visible = true
		$LoseAudio.stop()
		$LoseAudio.play()

	var tween := create_tween()
	tween.tween_property($AmbienceMusic, "volume_db", -80.0, 1.0)
	tween.tween_callback(Callable($AmbienceMusic, "stop"))

	var tree := get_tree()
	var current_scene := tree.current_scene
	if current_scene:
		tree.create_timer(3.0).timeout.connect(func():
			tree.reload_current_scene())


func _ready() -> void:
	rng.randomize()
	var points: Array[Node2D] = []
	for child in $SpawnsFolder.get_children():
		if child is Node2D and child.name.begins_with("SP"):
			points.append(child)
	points.shuffle()
	var enemy_spawn_count: int = mini(points.size(), 5)
	for i in range(enemy_spawn_count):
		var sp_node: Node2D = points[i]
		var enemy := enemy_scene.instantiate()
		enemy.global_position = sp_node.global_position
		add_child(enemy)
	var body_sp: Node2D = points[enemy_spawn_count]
	var body := body_scene.instantiate()
	body.global_position = body_sp.global_position
	add_child(body)
