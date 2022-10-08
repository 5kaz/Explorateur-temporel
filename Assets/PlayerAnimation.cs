using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    private Animator anim;
    private string[] staticDirections = { "Static N", "Static NW", "Static W", "Static SW", "Static S", "Static SE", "Static E", "Static NE" };
    private string[] runDirections = { "Run N", "Run NW", "Run W", "Run SW", "Run S", "Run SE", "Run E", "Run NE" };

    int lastDirection;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //anim.Play
    }

    public void SetDirection( Vector2 _direction)
    {
        string[] directionArray = null;

        if (_direction.magnitude < 0.01)
        {
            directionArray = staticDirections;
        } else
        {
            directionArray = runDirections;

            lastDirection = DirectionToIndex(_direction);
        }


        anim.Play(directionArray[lastDirection]);
    }
    private int DirectionToIndex(Vector2 _direction)
    {

        Vector2 norDir = _direction.normalized;
        if (_direction == Vector2.up)
        {
            return 0;
        }
        else if (_direction == new Vector2(1, 1))
        {
            return 1;
        }
        else if (_direction == Vector2.right)
        {
            return 2;
        }
        else if (_direction == new Vector2(1, -1))
        {
            return 3;
        }
        else if (_direction == Vector2.down)
        {
            return 4;
        }
        else if (_direction == new Vector2(-1, -1))
        {
            return 5;
        }
        else if (_direction == Vector2.left)
        {
            return 6;
        }
        else if (_direction == new Vector2(-1, 1))
        {
            return 7;
        }
        else
        {
            return 0;
        }

    }
}
