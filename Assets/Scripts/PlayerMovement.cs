using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   [SerializeField] private CharacterController controller;
   [SerializeField] private float speed = 12f;
    //[SerializeField] PlayerAnimation playerAnim;
    private PlayerAnimation animationObject;
    private Vector2 old_direction = Vector2.zero;
    private GameManager gm;
    private float timeStamp;

    // Start is called before the first frame update
    void Start()
    {
        animationObject = FindObjectOfType<PlayerAnimation>();
        gm = FindObjectOfType<GameManager>();
        timeStamp = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        //MOVE
        float z = Input.GetAxis("Horizontal");
        float x = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z + new Vector3(0,-1,0);

        controller.Move(move * speed * Time.deltaTime);

        //ANIM


        if (z > 0)
            z = 1;
        else if (z < -0)
            z = -1;

        if (x > 0)
            x = 1;
        else if (x < 0)
            x = -1;

        Vector2 direction = new Vector2(z, x);

        if (direction.magnitude > 0)
        {
            if (timeStamp <= Time.time)
            {
                timeStamp = Time.time + 0.25f;
                gm.RunFootstepsSound();
            }
        }
        if (direction != old_direction)
        {
            animationObject.SetDirection(direction);
        }

        old_direction = direction;        

    }
}
