using Godot;
using System;

public class RightFlipperAxel : Node2D
{
    [Export] public int RotationSpeed;
    
    public int GetRotationSpeed()
    {
        return RotationSpeed;
    }

    public void SetRotationSpeed(int value) => RotationSpeed = value;

    //Checks for key press and rotates if down
    public bool RotateRightFlipper()
    {
        if(Input.GetActionStrength("move_right_flipper")>0)
        {
            return true;
        }
        return false;
    }
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        RotationSpeed = 3;
    }

 // Called every frame. 'delta' is the elapsed time since the previous frame.
 public override void _PhysicsProcess(float delta)
 {
     if(RotateRightFlipper() && RotationDegrees < 20)
     {
        Rotation += RotationSpeed * delta;
     } 
     else if(RotateRightFlipper())
     {
         
     }
     else{SetRotation(0);}
     
 }
}
