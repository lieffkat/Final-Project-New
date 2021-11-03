using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVRMove : PlayerMove
{
    public Camera vrCamera;
    public GameObject vrPointer;
    public LayerMask moveTargetLayer;

    float _maxDistance = 100f;
    public GameObject _gazedAtObject;
    public float desiredXPos = 0;

    protected override void HorizontalMovementController()
    {
        base.HorizontalMovementController();
        RaycastTargetUpdate();
        MoveTowardDesiredPosition();

    }

    void MoveTowardDesiredPosition()
    {
        Vector3 desiredDirection = Vector3.zero;
        if (transform.position.x > desiredXPos)
        {
            desiredDirection = Vector3.right;
        }
        if (transform.position.x < desiredXPos)
        {
            desiredDirection = Vector3.left;
        }
        transform.Translate(desiredDirection * Time.deltaTime * leftRightSpeed * -1);
    }

    void RaycastTargetUpdate()
    {
        /*
        if (vrPointer != null)
        {
            vrPointer.transform.position = vrCamera.transform.position;
            vrPointer.transform.rotation = Quaternion.Euler(vrCamera.transform.eulerAngles.x, vrCamera.transform.eulerAngles.y, 0);
            vrPointer.transform.Translate(new Vector3(0, 0, 1), Space.Self);
        }
        else { Debug.LogWarning("Hey bud, you need a VR Pointer");
        }*/
        RaycastHit hit;        if (Physics.Raycast(vrCamera.transform.position, vrCamera.transform.forward, out hit, _maxDistance, moveTargetLayer))        {
            Debug.Log("I think I hit something..." + hit.transform.name);
            // GameObject detected in front of the camera.
            if (_gazedAtObject != hit.transform.gameObject)            {
                
                    if (hit.transform.gameObject.CompareTag("MovementTarget"))
                    {
                        _gazedAtObject = hit.transform.gameObject;
                        Debug.Log("I hit... " + hit.transform.name);
                        desiredXPos = _gazedAtObject.transform.position.x;
                    }
                            }            if (vrPointer != null)
            {
                float distance = Vector3.Distance(vrCamera.transform.position, hit.point);
                vrPointer.transform.localPosition = new Vector3(0,0,distance);
            }        }
        else
        {
            Debug.Log("I ain't hit a thang!");
            vrPointer.transform.localPosition = new Vector3(0, 0, 2f);
        }

    }
}
