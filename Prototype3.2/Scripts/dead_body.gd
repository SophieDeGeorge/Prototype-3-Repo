extends Node2D

var is_activated: bool = false

func _ready() -> void:
	$Area2D.body_entered.connect(_on_body_entered)

func _on_body_entered(body: Node) -> void:
	if body.name != "Player" or is_activated:
		return
	is_activated = true
	$AudioStreamPlayer2D.play()
	var game_root := get_tree().current_scene
	if game_root and game_root.has_method("game_end"):
		game_root.game_end(body, true)
