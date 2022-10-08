using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PastFutureSwitch : MonoBehaviour
{
    [SerializeField] public Transform pastPlayer;
    [SerializeField] public Transform futurePlayer;
    [SerializeField] public Cinemachine.CinemachineVirtualCamera vcamSwitchObject;

    private float timeStamp;

    // Start is called before the first frame update
    void Start()
    {
        timeStamp = Time.time + 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("space") && timeStamp <= Time.time)
        {

            timeStamp = Time.time + 1;
            Debug.Log("Switch past / future");

            if (vcamSwitchObject.Follow == pastPlayer)
            {
                vcamSwitchObject.enabled = false;
                vcamSwitchObject.LookAt = futurePlayer;
                vcamSwitchObject.Follow = futurePlayer;
                vcamSwitchObject.OnTargetObjectWarped(futurePlayer, new Vector3(0f, 20f, 0f));
                vcamSwitchObject.enabled = true;

            }
            else
            {
                vcamSwitchObject.enabled = false;
                vcamSwitchObject.LookAt = pastPlayer;
                vcamSwitchObject.Follow = pastPlayer;
                vcamSwitchObject.OnTargetObjectWarped(pastPlayer, new Vector3(0f, -20f, 0f));
                vcamSwitchObject.enabled = true;

            }
        }
    }
}
