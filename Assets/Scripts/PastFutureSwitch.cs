using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PastFutureSwitch : MonoBehaviour
{
    [SerializeField] public Transform player;
    [SerializeField] public Cinemachine.CinemachineVirtualCamera vcamSwitchObject;
    [SerializeField] public PastFutureSwitchPP pastFutureSwitchPP;

    [SerializeField] public GameObject PastGroup;
    [SerializeField] public GameObject FutureGroup;



    private float timeStamp;

    public AK.Wwise.Event UI_Clock_toPast;
    public AK.Wwise.Event UI_Clock_toPresent;
    public AK.Wwise.Event UI_Clock_Cooldown;
    /*public AK.Wwise.Event SET_PAST;
    public AK.Wwise.Event SET_PRESENT;*/

    private GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        timeStamp = Time.time;
        gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey("space") )//&& timeStamp <= Time.time)
        {
            if (timeStamp <= Time.time)
            {
                timeStamp = Time.time + 1;
                //Debug.Log("Switch past / future");

                if (player.position.y > 19) // TO PAST
                {
                    PastGroup.SetActive(true);
                    Vector3 childPosition = player.transform.Find("playerRealPosition").gameObject.transform.position;
                    Collider[] hitColliders = Physics.OverlapSphere(new Vector3(childPosition.x, childPosition.y - 19, childPosition.z), 0);

                    if (hitColliders.Length == 0)
                    {
                        //PastGroup.SetActive(true);
                        FutureGroup.SetActive(false);
                        vcamSwitchObject.enabled = false;
                        player.GetComponent<CharacterController>().enabled = false;
                        player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y - 19, player.transform.position.z);
                        vcamSwitchObject.LookAt = player;
                        vcamSwitchObject.Follow = player;
                        vcamSwitchObject.OnTargetObjectWarped(player, new Vector3(0f, -19f, 0f));
                        player.GetComponent<CharacterController>().enabled = true;
                        vcamSwitchObject.enabled = true;
                        UI_Clock_toPast.Post(gameObject);
                        //SET_PAST.Post(gameObject);
                        gm.RunFutureSound();
                        PostProcessingEffects(1);
                    }
                    else
                    {
                        PastGroup.SetActive(false);
                        UI_Clock_Cooldown.Post(gameObject);
                        Debug.Log("CANT SWAP");
                    }


                }
                else // TO PRESENT
                {
                    FutureGroup.SetActive(true);
                    Vector3 childPosition = player.transform.Find("playerRealPosition").gameObject.transform.position;
                    Collider[] hitColliders = Physics.OverlapSphere(new Vector3(childPosition.x, childPosition.y + 19, childPosition.z), 0);

                    if (hitColliders.Length == 0)
                    {
                        PastGroup.SetActive(false);
                        //FutureGroup.SetActive(true);
                        vcamSwitchObject.enabled = false;
                        player.GetComponent<CharacterController>().enabled = false;
                        player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 19, player.transform.position.z);
                        vcamSwitchObject.LookAt = player;
                        vcamSwitchObject.Follow = player;
                        vcamSwitchObject.OnTargetObjectWarped(player, new Vector3(0f, 21f, 0f));
                        player.GetComponent<CharacterController>().enabled = true;
                        vcamSwitchObject.enabled = true;
                        UI_Clock_toPresent.Post(gameObject);
                        //SET_PRESENT.Post(gameObject);
                        gm.RunPastSound();
                        PostProcessingEffects(0);
                    }
                    else
                    {
                        FutureGroup.SetActive(false);
                        Debug.Log("CANT SWAP");
                        UI_Clock_Cooldown.Post(gameObject);
                    }


                }
            } else //Cooldown
            {
                //rend pas très bien
                //UI_Clock_Cooldown.Post(gameObject);
            }

            
        }
    }

    private void PostProcessingEffects(int direction)
    {
        switch (direction)
        {
            case 0: // PAST ==> FUTURE
                pastFutureSwitchPP.StartTransition(true);
                break;
            case 1: // FUTURE ==> PAST
                pastFutureSwitchPP.StartTransition(false);
                break;
        }
    }
}
