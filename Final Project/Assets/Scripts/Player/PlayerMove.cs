using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 3;
    public float leftRightSpeed = 4;
    public bool shouldJump = false;
    public bool shouldSlide = false;
    public float moveSpeedMultiplier = 1f;
    public bool shouldStumble = false;
    public Animator myAnimator;

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed * moveSpeedMultiplier, Space.World);


        if (shouldSlide)
        {
            shouldSlide = false;
            myAnimator.SetTrigger("Slide");
            //cool sfx?
        }
        if (shouldJump)
        {
            shouldJump = false;
            myAnimator.SetTrigger("Jump");
            //cool sfx?
        }
        if (shouldStumble)
        {
            shouldStumble = false;
            myAnimator.SetTrigger("Stumble");
            StartCoroutine(StumbleSpeedModifier());
            //maybe take damage? or tick off a "hearts" container? or play game over? yada yada
        }


        if (Input.GetKeyDown(KeyCode.Space))
            shouldJump = true;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        { 
            if (this.gameObject.transform.position.x > LevelBoundary.leftSide)
            {
                transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed);
            }
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (this.gameObject.transform.position.x < LevelBoundary.rightSide)
            {
                transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed * -1);

            }
        }

    }

    IEnumerator StumbleSpeedModifier()
    {
        //speed off
        moveSpeedMultiplier = 0f;
        yield return new WaitForSeconds(3f);
        moveSpeedMultiplier = 1f;
        //speed on
    }
}
