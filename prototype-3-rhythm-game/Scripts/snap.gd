extends Sprite2D

@onready var _animated_sprite = $AnimatedSprite2D
# Called when the node enters the scene tree for the first time.
func _ready():
	pass # Replace with function body.

func _input(event):
	if event.is_action_pressed("ui_left"):
		print("pressed")
		_animated_sprite.play("snap")
	if event.is_action_pressed("ui_right"):
		_animated_sprite.play("snap")

# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	pass
