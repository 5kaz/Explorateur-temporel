using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    ControlsHelper controlsHelper;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.DeleteKey("timePlayed"); // TODO remove this
        int timePlayed = PlayerPrefs.GetInt("timePlayed", -1);

        if (timePlayed == -1) // If never played
        {
            timePlayed = 0;
        }
        controlsHelper.DisplayControls(0);
        PlayerPrefs.SetInt("timePlayed", timePlayed + 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
