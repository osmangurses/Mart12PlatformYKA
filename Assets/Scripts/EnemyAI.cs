using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] float speed;

    [Header ("Raycast")]
    [SerializeField] float rayLenght;

    [Header("Raycast Left")]
    [SerializeField] Vector3 leftRayPos;
    [SerializeField] Vector3 leftRayRot;

    [Header("Raycast Right")]
    [SerializeField] Vector3 rightRayPos;
    [SerializeField] Vector3 rightRayRot;


    Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        RaycastCheck();
    }
    void RaycastCheck()
    {
        RaycastHit2D leftHit = Physics2D.Raycast(transform.position+leftRayPos,leftRayRot,rayLenght);
        Debug.DrawRay(transform.position + leftRayPos,       leftRayRot* rayLenght,        Color.red);


        RaycastHit2D rightHit = Physics2D.Raycast(transform.position+rightRayPos,rightRayRot,rayLenght);
        Debug.DrawRay(transform.position + rightRayPos, rightRayRot * rayLenght, Color.red);

        if (leftHit.collider!=null && leftHit.collider.gameObject.tag=="Player")
        {
            rb.velocity =Vector3.up*rb.velocity.y+ Vector3.left * speed;
        }
        else if (rightHit.collider!=null && rightHit.collider.gameObject.tag == "Player")
        {
            rb.velocity = Vector3.up * rb.velocity.y + Vector3.right * speed;
        }
        else
        {
            rb.velocity= Vector3.up * rb.velocity.y;
        }

    }
}
