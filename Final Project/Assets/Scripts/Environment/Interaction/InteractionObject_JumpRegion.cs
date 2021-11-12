using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This overrides InteractionObject.
/// When interactions occur, it triggers the Jump animation in PlayerMove
/// </summary>
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
