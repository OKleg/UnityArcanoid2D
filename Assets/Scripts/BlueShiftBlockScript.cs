using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class BlueShiftBlockScript : BlockScript
{


    private float xMax;
    private float xMin;
    //private float direction = 1;
    private bool direction = true;
    public float speed = 0.4f;

    public Vector2 p1;
    public Vector2 p2;

    public Vector2 Position { get => (Vector2)transform.position; 
        set => transform.position = value;
    }


    protected override void Start()
    {
        base.Start();
        Position = p1;
        
        speed = Random.value + 0.5f;
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
        // xMax = Camera.main.orthographicSize * Camera.main.aspect * 0.85f - 2;
        // xMin = Camera.main.orthographicSize * Camera.main.aspect * 0.85f * -1 + 2;
    }

    void Update()  {
        /*var pos = transform.position;
        if (pos.x+0.1 >= xMax || pos.x-0.1 <= xMin)
            direction *= -1 * speed;
        pos.x += direction;
        transform.position = pos;*/

        float velocity = speed * Time.deltaTime;
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

