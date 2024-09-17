using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Buton atamalarý yapýlacak. son haline getirelecek oyun;
public class CharacterMovement : MonoBehaviour
{

    public int hiz;
    public int ziplamaGucu;

    public Transform rayPos;
    public Vector3 rayRotation;
    public float rayLength;

    int yon = 0;
    Rigidbody2D characterRigidbody;
    SpriteRenderer characterSpriteRenderer;
    public AudioSource stepSound, jumpSound;
    public static Animator characterAnimator;
    public static bool zemineDegdiMi;
    public bool OlduMu;
    private void Awake()
    {
        if (!PlayerPrefs.HasKey("level"))
        {
            PlayerPrefs.SetInt("level",0);
        }
        if (PlayerPrefs.GetInt("level")!= SceneManager.GetActiveScene().buildIndex)
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt("level"));
        }
    }
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
            OlduMu = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Sandik")
        {
            collision.gameObject.GetComponent<Animator>().Play("ChestOpening");
            PlayerPrefs.SetInt("level",PlayerPrefs.GetInt("level")+1);
            Invoke("GoToNextLevel",1.5f);
        }
    }


    public void GoToNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    private void Update()
    {
        characterRigidbody.velocity = new Vector2(yon*hiz,characterRigidbody.velocity.y);
        GroundCheckWithRay();
        KeyboardController();
        AnimationController();
    }
    void AnimationController()
    {
        if (OlduMu)
        {
            characterAnimator.Play("Death");
        }
        else if (zemineDegdiMi == true && yon == 0)
        {
            characterAnimator.Play("Idle");
        }
        else if (zemineDegdiMi == true && yon != 0)
        {
            characterAnimator.Play("Run");
        }
        else if (zemineDegdiMi == false && OlduMu == false)
        {
            characterAnimator.Play("Jump");
        }
    }
    public void KeyboardController()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            YonDegis(-1);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            YonDegis(1);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        if (Input.GetKeyUp(KeyCode.D)  || Input.GetKeyUp(KeyCode.A))
        {
            YonDegis(0);
        }

    }
    public void YonDegis(int yeniYon)
    {
        yon = yeniYon;
        if (yeniYon==-1)
        {
            characterSpriteRenderer.flipX = true;
        }
        else if (yeniYon==1) 
        {
            characterSpriteRenderer.flipX = false;
        }
    }
    public void Jump()
    {
        if(zemineDegdiMi==true)
        {
            characterRigidbody.AddForce(ziplamaGucu * Vector2.up);
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

        }
        Debug.DrawRay(rayPos.position, rayRotation * rayLength, Color.green);
    }
}