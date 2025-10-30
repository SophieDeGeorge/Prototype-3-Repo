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
