using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField] private string keyColor;
    [SerializeField] private GameObject doorLeftPoint;
    [SerializeField] private GameObject doorRightPoint;

    private bool openDoor = false;
    [SerializeField] private int maxRotataion = 120;
    private int rotation = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (openDoor)
        {
            rotation += 1;
            doorLeftPoint.transform.Rotate(0, -1, 0);
            doorRightPoint.transform.Rotate(0, 1, 0);

            if (rotation > maxRotataion)
            {
                openDoor = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Check door");
        PlayerKeySystem PlayerKeyScript = other.gameObject.GetComponent<PlayerKeySystem>();
        if (PlayerKeyScript != null)
        {
            
            if ( PlayerKeyScript.CanUseKey(keyColor))
            {
                Debug.Log("door open");
                openDoor = true;
            }  
        }
    }
}
