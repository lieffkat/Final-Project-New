using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject_StumbleRegion : InteractionObject
{
   protected override void DoInteractionBehavior(Collider other)
    {
        if (other.GetComponent<PlayerMove>())
        {
            other.GetComponent<PlayerMove>().shouldStumble = true;
        }
    }
}
