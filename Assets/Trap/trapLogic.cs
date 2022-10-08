using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapLogic : MonoBehaviour
{
    [SerializeField] private GameObject pics;
    private bool movePics = false;
    [SerializeField] private float maxPicsMove = 2;
    private float picsMove = 0;
    // Start is called before the first frame update
    void Start()
    {
        
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
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {  
        if (other.tag == "Player")
        {
            movePics = true;
            Debug.Log("PLAYER DEAD");
        }
    }
}
