extends Node2D

@export var default_texture: Texture2D
@export var activated_texture: Texture2D
@export var one_time_trigger: bool = true

var _activated: bool = false

func _ready() -> void:
	$Area2D.body_entered.connect(_on_body_entered)

func _on_body_entered(body: Node) -> void:
	if body.name != "Player":
		return
	if one_time_trigger and _activated:
		return
	_activated = true
	$AudioStreamPlayer2D.play()
	var game_root := get_tree().current_scene
	if game_root and game_root.has_method("you_win"):
		game_root.you_win(body)
