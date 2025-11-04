extends Node2D

var _is_game_over: bool = false

func game_over(player: Node) -> void:
	if _is_game_over:
		return
	_is_game_over = true
	if player.has_method("freeze_player"):
		player.freeze_player()
	$CanvasLayer/GameOverLabel.visible = true
	var tree := get_tree()
	var current_scene := tree.current_scene
	if current_scene:
		tree.create_timer(3.0).timeout.connect(func():
			tree.reload_current_scene())

func you_win(player: Node) -> void:
	if _is_game_over:
		return
	_is_game_over = true
	if player.has_method("freeze_player"):
		player.freeze_player()
	$CanvasLayer2/YouWinLabel.visible = true
	var tree := get_tree()
	var current_scene := tree.current_scene
	if current_scene:
		tree.create_timer(3.0).timeout.connect(func():
			tree.reload_current_scene())
			
@export var enemy_scene: PackedScene
@export var name_filter: String = "SP"        # matches any node with "SP" in its name
@export var spawn_count: int = 1
@export var remove_marker_after_spawn := true
@export var debug_prints := false

var _rng := RandomNumberGenerator.new()

func _ready() -> void:
	if enemy_scene == null:
		push_warning("enemy_scene not set.")
		return

	_rng.randomize()

	var points: Array[Node] = _collect_spawn_points(name_filter)
	if points.is_empty():
		push_warning("No spawn points with '%s' in the name were found." % name_filter)
		return

	var n: int = min(spawn_count, points.size())  # ✅ typed as int

	# Pick without replacement using our RNG
	for i in n:  # loops 0..n-1 in Godot 4
		var k: int = _rng.randi_range(0, points.size() - 1)
		var sp: Node = points[k]
		points.remove_at(k)

		var enemy: Node = enemy_scene.instantiate()
		add_child(enemy)

		if enemy is Node2D and sp is Node2D:
			(enemy as Node2D).global_position = (sp as Node2D).global_position

		if debug_prints:
			print("Spawned at: ", sp.get_path())

		if remove_marker_after_spawn:
			sp.queue_free()

func _collect_spawn_points(filter_text: String) -> Array[Node]:
	var want := filter_text.to_upper()
	var found: Array[Node] = []
	var stack: Array[Node] = [self]
	while not stack.is_empty():
		var n: Node = stack.pop_back()
		for c in n.get_children():
			stack.push_back(c)
			if str(c.name).to_upper().find(want) != -1:
				found.append(c)
	return found
