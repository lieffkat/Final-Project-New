using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This overrides PlayerMove to use VR camera raycasts to assist with LEFT / RIGHT movement.
/// 
/// </summary>
public class PlayerVRMove : PlayerMove
{
    public Camera vrCamera;
    public VRPointerBehavior vrPointer;
    public LayerMask moveTargetLayer;
    public float defaultPointerDistance = 2.5f;

    float _maxDistance = 100f;
    GameObject _gazedAtObject;
    float desiredXPos = 0;

    protected override void HorizontalMovementController()
    {
        base.HorizontalMovementController();
        RaycastTargetUpdate();
        MoveTowardDesiredPosition();

    }
    /// <summary>
    /// Based on the current X position, this method moves the player towards a desired X position (RIGHT or LEFT).
    /// At some speed, scaled by time, and clamped between two extremes (-1.1 and 1.1).
    /// </summary>
    void MoveTowardDesiredPosition()
    {
        Vector3 desiredDirection = Vector3.zero;

        float currentXPos = transform.position.x;
        float nextXPosition = Mathf.Lerp(currentXPos, desiredXPos, Time.deltaTime * leftRightSpeed);
        desiredDirection = new Vector3(nextXPosition, 0, 0);
        float positionDifference = nextXPosition - currentXPos;
        transform.Translate(Vector3.right * positionDifference);

        float clampedPosX = Mathf.Clamp(transform.position.x, -1.1f, 1.1f);
        transform.position = new Vector3(clampedPosX, transform.position.y, transform.position.z);
       
    }

    /// <summary>
    /// This method uses Raycasting to let the player select their desired lane of movement (ex: lane Left, Middle, Right).
    /// A Raycast is a line from one point to another which reports any physics collision made along the path.
    /// A physics layer (MoveTargetLayer) allows us to only Raycast towards the objects of interest (ex: lane switches).
    /// We saved the most recent Raycasted object (ex: a lane switch) to a variable called GazedAtObject.
    /// </summary>
    void RaycastTargetUpdate()
    {

        RaycastHit hit;
        if (Physics.Raycast(vrCamera.transform.position, vrCamera.transform.forward, out hit, _maxDistance, moveTargetLayer))
        {
            Debug.Log("I think I hit something..." + hit.transform.name);
            vrPointer.UpdatePointer(true);
            // GameObject detected in front of the camera.
            // GazedAtObject is used for animating lane switches and storing desired X position.
            // If the stored/previous GazedAtObject is different from what was just hit, then...
            if (_gazedAtObject != hit.transform.gameObject)
            {
                // ...if the previous GazedAtObject was not null or invalid, then tell it to stop it's hover animation.
                if (_gazedAtObject != null)
                {
                    _gazedAtObject.GetComponent<VRLaneObject>().UpdateLaneHover(false);
                }
                // ...if the current hit object is a movement target, then store it as the new GazedAtObject and tell it to play the hover animation.
                if (hit.transform.gameObject.CompareTag("MovementTarget"))
                {
                    _gazedAtObject = hit.transform.gameObject;
                    Debug.Log("I hit... " + hit.transform.name);
                    desiredXPos = _gazedAtObject.transform.position.x;

                    _gazedAtObject.GetComponent<VRLaneObject>().UpdateLaneHover(true);
                }
                
            }

            // If we have a VR pointer ball/dot, tell it to change color
            if (vrPointer != null)
            {
                float distance = Vector3.Distance(vrCamera.transform.position, hit.point);
                //vrPointer.transform.localPosition = new Vector3(0,0,distance);
                vrPointer.transform.localPosition = new Vector3(0, 0, defaultPointerDistance);
            }
        }
        else
        {
            Debug.Log("I ain't hit a thang!");
            if (_gazedAtObject != null)
            {
                _gazedAtObject.gameObject.GetComponent<VRLaneObject>().UpdateLaneHover(false);
                _gazedAtObject = null;
            }
            vrPointer.UpdatePointer(false);
            vrPointer.transform.localPosition = new Vector3(0, 0, defaultPointerDistance);
        }

    }
}
