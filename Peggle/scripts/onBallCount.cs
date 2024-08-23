using Godot;
using System;

public partial class onBallCount : Node
{
	// Called when the node enters the scene tree for the first time.
	private static int count = 0;
    public static int Count
    {
        get { return count; }
        set
        {
            if(value <=0) 
            {
                pegDestroy.waitDestroy = 0;
                countChange?.Invoke();
            }
            count = value;
        }
    }
    public static Action countChange;

    public override void _Ready()
    {
        onBallCount.Count++;
        this.TreeExited += _on_exited;
    }
    
    private void _on_exited()
    {
        onBallCount.Count--;
    }
}
