using Godot;
using System;


public class KinematicBody2D : Godot.KinematicBody2D
{

    const float gravity = 200.0f;
    private const int V = 30;
    private const int V1 = 10;
    private bool pulled = false;
    private bool canPull = true;
    private Vector2 initPos;
    private Vector2 velocity;
    private float distancePulled;
    private float velModifier;
    private float resetDistance;
    int i;
// Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        initPos = this.Position;
    }
    public override void _PhysicsProcess(float delta)
    {
        

        if (Input.IsActionPressed("pull_plunger") && canPull == true)
        {
            pulled = true;
            if(i<30)
            {
                velocity.y = delta * gravity * 10;
                distancePulled += velocity.y;
                velModifier -= V;
                i++;
            }
        }
        
        else if(this.Position.y > initPos.y-20)
        {
            velocity.y = velModifier;
            

        }
        else
        {
            resetDistance = initPos.y - this.Position.y;
            velocity.y = 0;
            distancePulled = 0;
            velModifier = 0;
            i=0;
            MoveAndCollide(new Vector2(0,resetDistance));
            canPull = false;
        }

        if(canPull == false)
        {
            if(this.Position.y == initPos.y)
            {
                canPull = true;
            }
        }

        // We don't need to multiply velocity by delta because "MoveAndSlide" already takes delta time into account.

        // The second parameter of "MoveAndSlide" is the normal pointing up.
        // In the case of a 2D platformer, in Godot, upward is negative y, which translates to -1 as a normal.
        MoveAndSlide(velocity);
    }
}


