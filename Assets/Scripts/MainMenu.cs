using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
    
    public GameObject continuer;
    void Start(){
        if (PlayerPrefs.GetFloat("cp_x", 9999.99f) != 9999.99f) // No current game saved
        {
            continuer.GetComponent<Button>().interactable = true;
        }
    }

    public void ResetGame()
    {
        PlayerPrefs.DeleteAll();
    }
    public void startGame()
    {
        SceneManager.LoadScene(0);
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
