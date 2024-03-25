using Godot;
using System;

public partial class countString : Label
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		countBall.count.countChange += UpdateText;
		UpdateText(countBall.count.numBall);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	void UpdateText(int i){
		Text = "x" + i.ToString();
	}
}
