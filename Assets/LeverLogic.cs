using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverLogic : MonoBehaviour
{
    private GameObject[] player;
    [SerializeField] private int MaxDistance = 2;
    [SerializeField] private GameObject BridgePoint;
    [SerializeField] private GameObject LeverPoint;

    private bool moveBridge = false;
    private bool moveLever = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (player.Length != 0 && Vector3.Distance(transform.position, player[0].transform.position) < MaxDistance)
            {
                moveBridge = true;
                moveLever = true;
            }
        }

        if (moveBridge)
        {
            if (BridgePoint.transform.rotation.z > 0)
            {
                BridgePoint.transform.Rotate(0, 0, -1);
            } 
            else
            {
                moveBridge = false;
            } 
        }

        if (moveLever)
        {
            if (LeverPoint.transform.rotation.z < 0.6)
            {
                LeverPoint.transform.Rotate(0, 0, 6);
            }
            else
            {
                moveLever = false;
            }
        }
    }
}
