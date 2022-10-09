using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeadScreen : MonoBehaviour
{
    private CanvasGroup cg;
    private bool display = false;
    private bool dead = false;
    private float fadeSpeed = 1.0f;
    private float timeStamp;
    private string[] deathSamplePhrases = {
         "Bien fait pour vous ! Votre ame hantera desormais ces murs pour l’eternite, dans la solitude et le froid. Heureusement pour vous, vous ne ressentirez pas le froid.",
         "Les fantomes du passe se sont acharnes sur votre ame. Faute de richesses, vous ne connaitrez que le neant. Ca vous apprendra, a essayer de piller honteusement les ressources archeologiques !",
         "En vous reveillant, vous vous retrouvez au milieu d’ectoplasmes qui se foutent de votre gueule. Il semblerait que vous ne soyez pas le premier a avoir essaye de piller le tresor… Ils vous tendent une biere fantome et vous accueille chaleureusement. Ce n’est pas si mal finalement : a defaut d’argent et de revoir un jour votre famille, vous vous etes faits de nouveaux amis.",
         "Serieusement ? Vous n’aviez pas vu ce piege ? Pensez a vous acheter des lunettes avant la prochaine exploration. Ah oui. Il n’y en aura pas de prochaine.",
         "Soyez contents : peu d’aventuriers ont connu une mort aussi rapide. Vous ne l’etes pas ? Dommage ! Vous ne pouvez vous en prendre qu’a vous-meme… et recommencer.",
    };

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
        transform.GetChild(0).transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = this.deathSamplePhrases[Random.Range(0, 5)];
        display = true;
        player.enabled = false;
        switchTime.enabled = false;
        timeStamp = Time.time;
        dead = true;
    }
    
}
