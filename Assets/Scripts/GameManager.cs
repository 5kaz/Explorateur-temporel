using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Checkpoint lastSavedCheckpoint;
    [SerializeField]
    ControlsHelper controlsHelper;
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] PastFutureSwitch switchTime;

    [SerializeField]
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.DeleteKey("timePlayed"); // TODO remove this
        //PlayerPrefs.SetInt("timePlayed", 3); // TODO remove this

        int timePlayed = PlayerPrefs.GetInt("timePlayed", -1);

        if (timePlayed == -1) // If never played
        {
            timePlayed = 0;
            SaveCheckpoint(player.transform.position,false);
        }
        else
        {   
            GoBackToLastCheckpoint();
        }
        controlsHelper.DisplayControls(0);
        PlayerPrefs.SetInt("timePlayed", timePlayed + 1);

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveCheckpoint(Vector3 position, bool display)
    {
        PlayerPrefs.SetFloat("cp_x", position.x);
        PlayerPrefs.SetFloat("cp_z", position.z);

        Debug.Log("Saved checkpoint : " + PlayerPrefs.GetFloat("cp_x") + PlayerPrefs.GetFloat("cp_z"));
        if (display)
        {
            controlsHelper.DisplayControls(2);
        }
    }

    public void GoBackToLastCheckpoint()
    {
        CharacterController cc = player.GetComponent<CharacterController>();
        cc.enabled = false;
        player.transform.position = new Vector3(PlayerPrefs.GetFloat("cp_x"), player.transform.position.y, PlayerPrefs.GetFloat("cp_z"));
        cc.enabled = true;
        Invoke("ActivateControls", 0.5f);
    }

    public void ActivateControls()
    {
        playerMovement.enabled = true;
        switchTime.enabled = true;
    }
}
