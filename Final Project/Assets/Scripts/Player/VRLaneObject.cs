using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRLaneObject : MonoBehaviour
{
    public Transform myPedestal;

    private void Awake()
    {
        UpdateLaneHover(false);
    }

    public void UpdateLaneHover(bool isHovered)
    {
        myPedestal.transform.localPosition = !isHovered ? new Vector3(0, 0.2f, 0) : Vector3.zero;
    }
}
