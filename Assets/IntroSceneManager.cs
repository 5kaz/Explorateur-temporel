using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroSceneManager : MonoBehaviour
{
    private string[] introStory = {
    "Mysterieuse prophetie\n\nLasse d’habiter au milieu de l’ocean, lieu morne et pas tres vivant\nA des plombes de toute civilisation, offrant tres peu de distractions\nLe roi viendra a demissionne, et tous les habitants dans la foulee\nDecideront finalement, eux aussi, de se barrer.\nSur notre cite abandonnee, alors que les siecles auront passe,\nUn etrange personnage debarquera, qui dans le temps voyagera\nDejouant les pieges du present, grace a son retourneur de temps,\nEn appuyant sur la touche espace, du temps il enlevera le masque.\nIl voudra voler notre tresor, alors conseil, planquez bien l’or !\nEt toi voleur qui trepigne, qui sera amene a lire un jour ces lignes,\nTu pourras dire si tu reussis, qu’elles etaient vraiment justes, les predictions d’Henry !\nHenry, oracle incompris"  };
    
    [SerializeField] private TextMeshProUGUI text;
    private int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        text.text = introStory[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            
            if (index < 0)
            {
                Debug.Log("HERE");
                index++;
                text.text = introStory[index];
                
            } else
            {
                SceneManager.LoadScene("SampleSceneClem 1");
            }
        }
    }
}
