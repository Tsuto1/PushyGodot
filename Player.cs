using Godot;
using System;

public class Player : KinematicBody2D
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	public float speed = 150;
	public float maxVelocity = 10;
	public float drag = 4;
	private Vector2 velocity = new Vector2(0f, 0f);
	
	private int counter = 0;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}
	
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess( float delta )
	{
		Vector2 direction;
		direction.x = Input.GetActionStrength( "ui_right" ) - Input.GetActionStrength( "ui_left" );
		direction.y = Input.GetActionStrength( "ui_down" ) - Input.GetActionStrength( "ui_up" );
		
		if ( Math.Abs( direction.x ) == 1 || Math.Abs( direction.y ) == 1 )
			velocity += velocity/-drag;
		
		if ( Math.Abs( direction.x ) == 1 && Math.Abs( direction.y ) == 1 )
			direction = direction.Normalized();
		
		Vector2 movement = speed * direction * delta;
		
		if (Math.Abs( velocity.y ) < maxVelocity && Math.Abs( velocity.y ) < maxVelocity)
			velocity += movement;
		MoveAndCollide( velocity );
		if ( Math.Abs( velocity.x ) > 0.1f || Math.Abs( velocity.y ) > 0.1f )
			velocity += velocity/-10;
			else
			velocity = Vector2.Zero;
		
		counter++;
		if (counter > 50) {
		GD.Print(velocity);
		counter = 0;
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process( float delta )
	{
		
	}
}
