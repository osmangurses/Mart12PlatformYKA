using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    public CharacterMovement characterScript;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Kare")
        {
            if (!characterScript.OlduMu)
            {
                GetComponent<Rigidbody2D>().AddForce(Vector3.up * 300);
            }
        }
    }
}
