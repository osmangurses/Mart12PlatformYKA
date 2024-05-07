using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ayakkabi : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CharacterMovement.zemineDegdiMi = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        CharacterMovement.zemineDegdiMi = false;
        CharacterMovement.characterAnimator.Play("Jump");
    }
}
