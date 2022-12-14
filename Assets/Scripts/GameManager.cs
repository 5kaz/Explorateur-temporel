using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public AK.Wwise.Event Start_LVL;
    public AK.Wwise.Event SetFutureTime;
    public AK.Wwise.Event SetPastTime;    
    public AK.Wwise.Event Footsteps;
    public AK.Wwise.Event TrapWise;

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
        AkSoundEngine.SetRTPCValue("PAST_PRES", 0.0f, AkSoundEngine.AK_INVALID_GAME_OBJECT);


        //INIT SOUNDS
        Start_LVL.Post(gameObject);
        //SetFutureTime.Post(gameObject);
        RunFutureSound();

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
        if (Input.GetKey("escape")){
            SceneManager.LoadScene("Menu");
        }
    }

    public void RunFootstepsSound()
    {
        Footsteps.Post(gameObject);
    }
    public void RunTrapSound()
    {
        //Footsteps.Post(gameObject);
        //TrapWise.Post(gameObject);
    }
    public void RunPastSound()
    {
        //SetPastTime.Post(gameObject);
        //Footsteps.Post(gameObject);
        SetPastTime.Post(gameObject);
    }

    public void RunFutureSound()
    {
        SetFutureTime.Post(gameObject);
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

    public void Win()
    {

    }
}
