using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 1;
    [SerializeField] private string keyColor;   

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotationSpeed, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerKeySystem PlayerKeyScript = other.gameObject.GetComponent<PlayerKeySystem>();
        if (PlayerKeyScript != null)
        {
 
            PlayerKeyScript.GetKey(keyColor);

            Destroy(gameObject);
        }
    }
}
