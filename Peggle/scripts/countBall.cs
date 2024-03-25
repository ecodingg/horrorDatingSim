using Godot;
using System;

public partial class countBall : Node
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public static countBall count = new countBall();
	int balls = 5;
	public Action<int> countChange;

	public int numBall{
		
		get{ return balls; }
		set{
			balls = value;
			countChange?.Invoke(numBall);

		}
	}

	public void AddBall(){
		balls++;
		countChange?.Invoke(numBall);
	}

	public void RemoveBall(){
		balls--;
		countChange?.Invoke(numBall);
	}
}
