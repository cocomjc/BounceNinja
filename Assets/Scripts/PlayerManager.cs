using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    Vector3 moveDirection = Vector3.zero;
    [SerializeField] PlayerRules playerRules;
    [SerializeField] Animator ninjaAnimator;
    private bool canJump = true;


    public void OnCollisionEnter(Collision collision) {
        Debug.Log("OnColliderEnter");
        if (collision.gameObject.tag == "Wall")
        {
            moveDirection = Vector3.zero;
            ninjaAnimator.SetTrigger("Grab");
            canJump = true;
        }
    }

    public void MovePlayer(Vector3 touchPos)
    {
        if (canJump)
        {
            ninjaAnimator.SetTrigger("Jump");
            canJump = false;
            moveDirection = (touchPos - transform.position).normalized;
            Debug.Log("direction: " + moveDirection);
            transform.forward = -moveDirection;
        }
    }

    private void Update()
    {
        transform.position += moveDirection * playerRules.speed * Time.deltaTime;
    }
}
