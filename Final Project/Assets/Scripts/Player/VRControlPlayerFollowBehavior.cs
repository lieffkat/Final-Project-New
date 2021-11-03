using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRControlPlayerFollowBehavior : MonoBehaviour
{
    public Transform playerTarget;
    void Update()
    {
        this.transform.position =
            new Vector3(
                this.transform.position.x,
                this.transform.position.y,
                playerTarget.transform.position.z
                );
    }
}
