using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadScreen : MonoBehaviour
{
    private CanvasGroup cg;
    private bool display = false;
    private bool dead = false;
    private float fadeSpeed = 1.0f;
    private float timeStamp;
    private string[] deathSamplePhrases;

    [SerializeField] PlayerMovement player;
    [SerializeField] PastFutureSwitch switchTime;
    [SerializeField] GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        cg = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        if (display && cg.alpha <= 1)
        {
            cg.alpha += 0.01f * fadeSpeed;
        }
        else if (!display && cg.alpha >= 0)
        {
            cg.alpha -= 0.01f * fadeSpeed;
        }
        if (Input.GetKey("space") && dead && (timeStamp + 2.0f) <= Time.time)
        {
            display = false;
            gameManager.GoBackToLastCheckpoint();
            dead = false;
        }
    }

    public void DisplayDeadScreen()
    {
        display = true;
        player.enabled = false;
        switchTime.enabled = false;
        timeStamp = Time.time;
        dead = true;
    }
    
}
