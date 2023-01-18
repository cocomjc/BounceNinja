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
        if (collision.gameObject.tag == "Wall")
        {
            moveDirection = Vector3.zero;
            transform.forward = - (collision.contacts[0].point - transform.position).normalized;
            ninjaAnimator.SetTrigger("Grab");
            canJump = true;
        }
    }

    public void MovePlayer(Vector3 touchPos)
    {
        if (canJump)
        {
            moveDirection = (touchPos - transform.position).normalized;
            CheckDirection();
        }
    }

    private void Update()
    {
        if (moveDirection == Vector3.zero)
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            return;
        }
        transform.position += moveDirection * playerRules.speed * Time.deltaTime;
    }

    private void CheckDirection()
    {
        GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");

        foreach (GameObject wall in walls)
        {
            if (wall.GetComponent<BoxCollider>().bounds.Contains(transform.position + moveDirection * 1.5f))
            {
                Debug.Log("HUH");
                moveDirection = Vector3.zero;
                return;
            }
        }
        ninjaAnimator.SetTrigger("Jump");
        transform.forward = -moveDirection;
        canJump = false;
    }
}
