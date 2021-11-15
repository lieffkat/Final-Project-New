using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This script follows the player as they move so it can move independent of the player's LEFT or RIGHT movement, to prevent jumping around.
/// This is currently used for the pedestals (lane switches) / VRControlRegion in Unity, which includes the camera.
/// </summary>
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
