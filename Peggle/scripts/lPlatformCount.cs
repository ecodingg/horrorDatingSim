using Godot;
using System;

public partial class lPlatformCount : Node
{
    // Instance count for each individual instance of lPlatformCount
    private static int count = 0;
    public static int Count
    {
        get { return count; }
        set 
        {
            countChange?.Invoke(value); 
            count = value; 
        }
    }

    public static Action<int> countChange;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        Count++; // Increment count when the node is ready
        this.GetParent().TreeExited += _on_exited;
    }

    
    // Decrement count when the node is exited
    private void _on_exited()
    {
        Count--;
        this.GetParent().TreeExited -= _on_exited;
    }
}
