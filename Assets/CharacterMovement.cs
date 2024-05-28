using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    public int hiz;
    public int ziplamaGucu;
    public Transform rayPos;
    public Vector3 rayRotation;
    public float rayLength;

    Rigidbody2D characterRigidbody;
    SpriteRenderer characterSpriteRenderer;
    public static Animator characterAnimator;
    public static bool zemineDegdiMi;
    public static bool OlduMu;

    private void Start()
    {
        characterRigidbody = GetComponent<Rigidbody2D>(); 
        characterSpriteRenderer = GetComponent<SpriteRenderer>();
        characterAnimator = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Engel")
        {
            characterAnimator.Play("Death");
            OlduMu = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Sandik")
        {
            collision.gameObject.GetComponent<Animator>().Play("ChestOpening");
        }
    }

    private void Update()
    {
        if (OlduMu==false)
        {
            if (Input.GetKey(KeyCode.D))
            {
                characterRigidbody.velocity = new Vector2(hiz, characterRigidbody.velocity.y);
                if (characterSpriteRenderer.flipX == true)
                {
                    characterSpriteRenderer.flipX = false;
                }
                if (zemineDegdiMi == true)
                {
                    characterAnimator.Play("Run");
                }
            }
            else if (Input.GetKey(KeyCode.A))
            {
                characterRigidbody.velocity = new Vector2(-hiz, characterRigidbody.velocity.y);
                if (characterSpriteRenderer.flipX == false)
                {
                    characterSpriteRenderer.flipX = true;
                }
                if (zemineDegdiMi == true)
                {
                    characterAnimator.Play("Run");
                }
            }
            else
            {
                characterRigidbody.velocity = new Vector2(0, characterRigidbody.velocity.y);
                if (zemineDegdiMi == true)
                {
                    characterAnimator.Play("Idle");
                }
            }




            if (Input.GetKeyDown(KeyCode.Space) && zemineDegdiMi == true)
            {
                characterRigidbody.AddForce(new Vector2(0, ziplamaGucu));
                characterAnimator.Play("Jump");
            }
            GroundCheckWithRay();
        }
        
    }
    void GroundCheckWithRay()
    {
        RaycastHit2D hit = Physics2D.Raycast(rayPos.position, rayRotation, rayLength);

        if (hit.collider != null)
        {
            zemineDegdiMi = true;
        }
        else
        {
            zemineDegdiMi = false;
            characterAnimator.Play("Jump");
        }
        Debug.DrawRay(rayPos.position, rayRotation * rayLength, Color.green);
    }
}
