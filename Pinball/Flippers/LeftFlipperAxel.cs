using Godot;
using System;

public class LeftFlipperAxel : Node2D
{
    [Export] public int RotationSpeed;
    
    public int GetRotationSpeed()
    {
        return RotationSpeed;
    }

    public void SetRotationSpeed(int value) => RotationSpeed = value;

    //Checks for key press and rotates if down
    public bool RotateLeftFlipper()
    {
        if(Input.GetActionStrength("move_left_flipper")>0)
        {
            return true;
        }
        return false;
    }
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        RotationSpeed = -5;
    }

 // Called every frame. 'delta' is the elapsed time since the previous frame.
 public override void _PhysicsProcess(float delta)
 {
     if(RotateLeftFlipper() && RotationDegrees > -20)
     {
        Rotation += RotationSpeed * delta;
     } 
     else if(RotateLeftFlipper())
     {

     }
     else{SetRotation(0);}
     
 }
}
