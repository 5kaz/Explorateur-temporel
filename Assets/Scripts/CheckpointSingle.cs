using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointSingle : MonoBehaviour
{
    bool activated = false;

    [SerializeField]
    GameManager gameManager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("Player") && !activated)
        {
            gameManager.SaveCheckpoint(this.transform.position, true);
            this.activated = true;
        }
    }
}
