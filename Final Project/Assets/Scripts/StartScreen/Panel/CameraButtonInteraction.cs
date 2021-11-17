using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraButtonInteraction : MonoBehaviour
{
    public Camera vrCamera;
    float _maxDistance = 1000f;
    public LayerMask buttonLayer;
    ButtonController _lastButtonController;

    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(vrCamera.transform.position, vrCamera.transform.forward, out hit, _maxDistance, buttonLayer))
        {
            if (hit.transform.gameObject.GetComponent<ButtonController>())
            {
                if (_lastButtonController == null)
                {
                    _lastButtonController = hit.transform.gameObject.GetComponent<ButtonController>();
                    _lastButtonController.SetHover(true);
                }
                else if (_lastButtonController.transform != hit.transform)
                {
                    if (_lastButtonController)
                    {
                        _lastButtonController.SetHover(false);
                    }
                    _lastButtonController = hit.transform.gameObject.GetComponent<ButtonController>();
                    _lastButtonController.SetHover(true);
                }
            }
        }
        else
        {
            if (_lastButtonController)
            {
                _lastButtonController.SetHover(false);
                _lastButtonController = null;
            }
        }
    }
}
