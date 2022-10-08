using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsHelper : MonoBehaviour
{
    [SerializeField]
    public GameObject controlsCanvas;
    [SerializeField]
    public GameObject movementsCanvas;
    [SerializeField]
    public GameObject switchCanvas;
    [SerializeField]
    public GameObject checkpointCanvas;

    CanvasGroup cg;
    bool disappear = false;
    float fadeSpeed = 0.5f;
    float displayDuration = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        cg = controlsCanvas.transform.GetComponent<CanvasGroup>();
        cg.alpha = 0.0f;
    }

    public void DisplayControls(int control)
    {
        disappear = false;
        if (control == 0) // MOVE
        {
            if (PlayerPrefs.GetInt("timePlayed", -1) <= 2)
            {
                movementsCanvas.SetActive(true);
                switchCanvas.SetActive(false);
                checkpointCanvas.SetActive(false);
                Invoke("HideControls", displayDuration);
            }
            else
            {
                movementsCanvas.SetActive(false);
            }
        }
        else if (control == 1) // SWITCH
        {
            if (PlayerPrefs.GetInt("timePlayed", -1) <= 2)
            {
                switchCanvas.SetActive(true);
                movementsCanvas.SetActive(false);
                checkpointCanvas.SetActive(false);
                Invoke("HideControls", displayDuration);
            }
            else
            {
                switchCanvas.SetActive(false);
            }
        }
        else if (control == 2) // CHECKPOINT
        {
            checkpointCanvas.SetActive(true);
            movementsCanvas.SetActive(false);
            switchCanvas.SetActive(false);
            Invoke("HideControls", displayDuration);
        }
    }

    private void HideControls()
    {
        disappear = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (disappear && cg.alpha >= 0)
        {
            cg.alpha -= 0.01f * fadeSpeed;
        }
        else if (!disappear && cg.alpha <= 1)
        {
            cg.alpha += 0.01f * fadeSpeed;
        }
    }
}
