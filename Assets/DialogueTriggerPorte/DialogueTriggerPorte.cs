using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueTriggerPorte : MonoBehaviour
{
    [SerializeField] public GameObject text;
    private void OnTriggerEnter(Collider other)
    {
        DisplayDialogue();
    }

    private void DisplayDialogue()
    {
        text.SetActive(true);
        text.GetComponent<TextMeshProUGUI>().text = "Partis en weekend teambuilding. En cas d’urgence, on a laisse la cle quelque part, mais comme on est presses d’aller picoler, on a la flemme de faire un plan. A + ! La garde.";
        Invoke("HideDialogue", 4.0f);
    }
    private void HideDialogue()
    {
        text.SetActive(false);
    }
}
