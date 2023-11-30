using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class BlueShiftBlockScript : BlockScript
{



    //private float direction = 1;
    private bool direction = true;
    public float speed = 0.3f;

    public Vector2 p1;
    public Vector2 p2;

    public Vector2 Position { 
        get => (Vector2)transform.position; 
        set => transform.position = value;
    }


    protected override void Start()
    {
        base.Start();
        Position = p1;
        
        speed = Random.value * 0.1f;
        if (Random.value > 0.5)
        {
            Position = p1;
            direction = true;
        }
        else
        {
            Position = p2;
            direction = false;
        }
    }

    void Update()  {

        float velocity = speed* Time.timeScale;
        if (Position == p1 || Position == p2)
        {
            direction = !direction;
        }
        if (direction)
        {
            Position = Vector2.MoveTowards(Position, p1, velocity);
        }
        else
        {
            Position = Vector2.MoveTowards(Position, p2, velocity);
        }
    }

}

