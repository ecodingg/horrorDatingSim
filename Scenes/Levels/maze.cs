using Godot;
using System;

public partial class maze : Node2D
{
	private Label _label;
	private Timer _timer;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// Initialize the label and timer nodes
		_label = GetNode<Label>("CanvasLayer/Label");
		_timer = GetNode<Timer>("Timer");

		// Connect the timer's timeout signal to the OnTimerTimeout method
		_timer.Connect("timeout", this, nameof(OnTimerTimeout));

		// Start the timer
		_timer.Start();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}

	private void _on_timer_timeout()
	{
		_label.Text = "Time's up!";
	}

}
