using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public AK.Wwise.Event SwitchSound;
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
            Debug.Log("oui");
            AkSoundEngine.PostEvent("UI_Clock_toPast", gameObject);
            timeStamp = Time.time + 1;
           // SwitchSound.Post(gameObject);
        }
    }
}
