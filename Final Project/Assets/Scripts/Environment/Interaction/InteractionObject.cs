using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DoInteractionBehavior(other);
        }
    }

    protected virtual void DoInteractionBehavior(Collider other)
    {
        Debug.Log("I hit the player!");
    }
}
