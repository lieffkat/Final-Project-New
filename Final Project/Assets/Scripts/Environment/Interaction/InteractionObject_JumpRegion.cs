using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject_JumpRegion : InteractionObject
{
   protected override void DoInteractionBehavior(Collider other)
    {
        if (other.GetComponent<PlayerMove>())
        {
            other.GetComponent<PlayerMove>().shouldJump = true;
        }
    }
}
