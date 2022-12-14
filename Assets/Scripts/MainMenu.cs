using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
    
    public  AK.Wwise.Event menuMusic;
    public GameObject continuer;
    void Start(){
        if (PlayerPrefs.GetFloat("cp_x", 9999.99f) != 9999.99f) // No current game saved
        {
            continuer.GetComponent<Button>().interactable = true;
        }
        menuMusic.Post(gameObject);
    }

    public void ResetGame()
    {
        PlayerPrefs.DeleteAll();
    }
    public void startGame()
    {
        menuMusic.Stop(gameObject);
        SceneManager.LoadScene("Intro");
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
