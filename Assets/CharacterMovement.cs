using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    public int hiz;
    public int ziplamaGucu;

    Rigidbody2D characterRigidbody;
    SpriteRenderer characterSpriteRenderer;
    public static Animator characterAnimator;
    public static bool zemineDegdiMi;

    private void Start()
    {
        characterRigidbody = GetComponent<Rigidbody2D>(); 
        characterSpriteRenderer = GetComponent<SpriteRenderer>();
        characterAnimator = GetComponent<Animator>();
    }
    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        zemineDegdiMi = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        zemineDegdiMi = false;
        characterAnimator.Play("Jump");
    }*/

    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            characterRigidbody.velocity = new Vector2(hiz, characterRigidbody.velocity.y);
            if (characterSpriteRenderer.flipX==true)
            {
                characterSpriteRenderer.flipX = false;
            }
            if (zemineDegdiMi==true)
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
            if (zemineDegdiMi==true)
            {
                characterAnimator.Play("Idle");
            }
        }




        if (Input.GetKeyDown(KeyCode.Space) && zemineDegdiMi==true)
        {
            characterRigidbody.AddForce(new Vector2(0,ziplamaGucu));
            characterAnimator.Play("Jump");
        }
    }
}
