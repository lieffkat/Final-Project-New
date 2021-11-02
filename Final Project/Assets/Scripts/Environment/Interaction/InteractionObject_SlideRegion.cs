using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject_SlideRegion : InteractionObject
{
    protected override void DoInteractionBehavior(Collider other)
    {
        if (other.GetComponent<PlayerMove>())
        {
            other.GetComponent<PlayerMove>().shouldSlide = true;
        }
    }
}
