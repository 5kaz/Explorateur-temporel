using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PastFutureSwitch : MonoBehaviour
{
    [SerializeField] public Transform player;
    [SerializeField] public Cinemachine.CinemachineVirtualCamera vcamSwitchObject;

    private float timeStamp;

    // Start is called before the first frame update
    void Start()
    {
        timeStamp = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("space") && timeStamp <= Time.time)
        {

            timeStamp = Time.time + 1;
            //Debug.Log("Switch past / future");

            if (player.position.y > 19)
            {
                vcamSwitchObject.enabled = false;
                player.GetComponent<CharacterController>().enabled = false;
                player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y - 20, player.transform.position.z);
                vcamSwitchObject.LookAt = player;
                vcamSwitchObject.Follow = player;
                vcamSwitchObject.OnTargetObjectWarped(player, new Vector3(0f, -20f, 0f));
                player.GetComponent<CharacterController>().enabled = true;
                vcamSwitchObject.enabled = true;
            }
            else
            {
                vcamSwitchObject.enabled = false;
                player.GetComponent<CharacterController>().enabled = false;
                player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 20, player.transform.position.z);
                vcamSwitchObject.LookAt = player;
                vcamSwitchObject.Follow = player;
                vcamSwitchObject.OnTargetObjectWarped(player, new Vector3(0f, 20f, 0f));
                player.GetComponent<CharacterController>().enabled = true;
                vcamSwitchObject.enabled = true;
            }
        }
    }
}
