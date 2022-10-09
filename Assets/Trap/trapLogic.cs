using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapLogic : MonoBehaviour
{
    public AK.Wwise.Event Trap_Sound;

    [SerializeField] private GameObject pics;
    private bool movePics = false;
    [SerializeField] private float maxPicsMove = 2;
    private float picsMove = 0;
    private bool reset = false;
    private float initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = pics.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (movePics)
        {
            
            pics.transform.position += new Vector3(0,0.4f,0);
            picsMove += 0.4f;
            
            if (picsMove > maxPicsMove)
            {
                movePics = false;
                picsMove = 0;
            }
        }
        if (reset)
        {
            pics.transform.position += new Vector3(0,initialPosition,0);
            reset = false;
        }
    }


    private void ResetTrap()
    {
        reset = true;   
    }
    private void OnTriggerEnter(Collider other)
    {  
        if (other.tag == "Player")
        {
            movePics = true;
            Trap_Sound.Post(gameObject);
            DeadScreen p = FindObjectOfType<DeadScreen>();
            p.DisplayDeadScreen();
            Invoke("ResetTrap", 2.0f);
        }
    }
}
