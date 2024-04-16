using Godot;
using System;


public partial class pegDestroy : Node
{
   [Export]
   public double timeToDestroy = 3.0f;
   private double timeCount = 0f;
   private bool on = false;
//    public static int waitDestroy = 0;



   public override void _Ready()
   {

       if (GetParent() is Node parent && parent.GetChild(3) is Area2D area2D)
        {
            area2D.BodyEntered += _on_Area2D_body_entered;
        }

        this.TreeExited += _on_exited;
      
   }


   public override void _Process(double delta)
   {
       if (on)
       {
           timeCount += delta;
           if (timeCount > timeToDestroy)
           {
               Node body = GetParent();
               if (body != null && body.GetParent() != null)
               {
                   body.GetParent().RemoveChild(body);
                   body.QueueFree();
               }
           }
       }
   }

   private void ballCountChange()
   {
       if (this != null && GetParent() != null)
       {
           Node body = GetParent();
           if (body.GetParent() != null)
           {
               body.GetParent().RemoveChild(body);
               body.QueueFree();
           }
       }
   }


   public void _on_Area2D_body_entered(object body)
    {
        if (!on && body is RigidBody2D rigidBody && rigidBody != GetParent())
        {
            on = true;
            GetParent().GetChild<Sprite2D>(0).Modulate = new Color(0.5f, 0.5f, 0.5f);
            // onBallCount.countChange += ballCountChange;
            // waitDestroy++;

        }
    }


   private void _on_exited()
   {
    //    waitDestroy--;
    //    onBallCount.countChange -= ballCountChange;
   }
}
