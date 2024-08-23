using Godot;
using System;

public partial class WinLose : Node
{
	[Export]
	public NodePath WinRef; // WinUI refrence
	public Control WinUI
	{
		get
		{
			return GetNode<Control>(WinRef);
		}
	}

	[Export]
	public NodePath LoseRef; // LoseUI refrence
	public Control LoseUI
	{
		get
		{
			return GetNode<Control>(LoseRef);
		}
	}


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		lPlatformCount.countChange += PlatformCountChange;
		onBallCount.countChange += BallCountChange;
	}

	void PlatformCountChange(int platformCount)
	{
		if (platformCount == 0)
		{
			WinUI.Visible = true;
		}
	}

	void BallCountChange()
	{
		GD.Print("UI Testing: " + "WinUI Visible?: " + WinUI.Visible);

		if (WinUI.Visible != true){
			if(countBall.count.numBall <= 0){
				LoseUI.Visible = true;
			}
		}
	}

	public void onButtonPressed()
	{
		lPlatformCount.countChange -= PlatformCountChange;
		onBallCount.countChange -= BallCountChange;

		//reset 
		countBall.count.numBall = 5;
		GetTree().ReloadCurrentScene();

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
