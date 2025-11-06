extends Node2D

@export var default_texture: Texture2D
@export var activated_texture: Texture2D
@export var one_time_trigger: bool = true
@export var min_pitch: float = 0.9
@export var max_pitch: float = 1.1
@export var reset_delay: float = 5.0

var _activated: bool = false
var _base_texture_size: Vector2
var _base_scale: Vector2

func _ready() -> void:
	if default_texture:
		$Sprite2D.texture = default_texture
	_store_base_sprite_size()
	$Area2D.body_entered.connect(_on_body_entered)

func _on_body_entered(body: Node) -> void:
	if body.name != "Player":
		return

	if one_time_trigger and _activated:
		return

	if _activated:
		return
	
	_activated = true

	var rand_pitch = randf_range(min_pitch, max_pitch)
	$AudioStreamPlayer2D.pitch_scale = rand_pitch
	$AudioStreamPlayer2D.play()
	if activated_texture:
		_set_sprite_texture_preserving_size(activated_texture)
		var stick_pos: Vector2 = global_position
		for enemy in get_tree().get_nodes_in_group("Enemy"):
			if enemy.has_method("alert_to_stick"):
				enemy.alert_to_stick(stick_pos)
	_start_reset_timer()

func _start_reset_timer() -> void:
	await get_tree().create_timer(reset_delay).timeout
	_reset_stick()

func _reset_stick() -> void:
	# allow triggering again unless you truly want one-time only
	_activated = false

	var sprite := $Sprite2D
	if default_texture:
		_set_sprite_texture_preserving_size(default_texture)
	else:
		sprite.texture = null
		sprite.scale = _base_scale

func _store_base_sprite_size() -> void:
	var sprite := $Sprite2D
	if sprite.texture:
		_base_texture_size = sprite.texture.get_size()
	else:
		_base_texture_size = Vector2.ONE
	_base_scale = sprite.scale

func _set_sprite_texture_preserving_size(new_tex: Texture2D) -> void:
	var sprite := $Sprite2D
	if new_tex == null:
		return
	sprite.texture = new_tex
	var new_size: Vector2 = new_tex.get_size()
	if new_size.x == 0.0 or new_size.y == 0.0:
		return
	var target_visual_size: Vector2 = _base_texture_size * _base_scale
	var new_scale: Vector2 = Vector2(
		target_visual_size.x / new_size.x,
		target_visual_size.y / new_size.y
	)
	sprite.scale = new_scale
