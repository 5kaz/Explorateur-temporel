using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueTriggerLevier : MonoBehaviour
{
    [SerializeField] public GameObject text;
    private void OnTriggerEnter(Collider other)
    {
        DisplayDialogue();
    }

    private void DisplayDialogue()
    {
        text.SetActive(true);
        text.GetComponent<TextMeshProUGUI>().text = "Attention. En poussant ce levier, vous abaisserez les ponts et multiplierez le risque d’invasion. Reflechissez-y a deux fois, surtout si vous avez force sur la boisson. Pour limiter la frequence des accidents, le pont menant au centre-ville a ete deconnecte du reste du reseau. (F)";
        Invoke("HideDialogue", 4.0f);
    }
    private void HideDialogue()
    {
        text.SetActive(false);
    }
}
