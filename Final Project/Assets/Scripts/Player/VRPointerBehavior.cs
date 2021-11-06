using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRPointerBehavior : MonoBehaviour
{
    Renderer myRenderer;
    public Color hoverColor;
    public Color idleColor;

    void Start()
    {
        myRenderer = GetComponent<Renderer>();
    }
    public void UpdatePointer(bool isHoveringOverButton)
    {
        myRenderer.material.color = isHoveringOverButton ? hoverColor : idleColor;
    }
}
