using Godot;
using System;

public partial class platformCount : Label
{
    // this is to update the platform or peg count label
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        lPlatformCount.countChange += UpdateText;
        UpdateText(lPlatformCount.Count);
        GD.Print("Initial platform count: " + lPlatformCount.Count);

        this.TreeExited += _on_exited;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        
    }

    void UpdateText(int i)
    {
        Text = "x" + i.ToString();
    }

    private void _on_exited()
    {
        lPlatformCount.countChange -= UpdateText;
        this.TreeExited -= _on_exited;
    }
}
