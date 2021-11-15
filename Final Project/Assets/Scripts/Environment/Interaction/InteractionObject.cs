using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This InteractionObject represents all things that can interact with the player in the game.
/// Every object can collide with the player via a trigger and will do some behavior.
/// Ex: see JumpRegion, StumbleRegion, etc
/// </summary>
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
