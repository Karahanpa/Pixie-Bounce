using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class characterController : MonoBehaviour
{   
    //speed and jump modifier
    [SerializeField] private float speed = 10f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float climbSpeed = 10f;
    [SerializeField] private AudioSource walkSound;
    [SerializeField] private AudioSource jumpSound;

    //jump and grounded booleans
    public bool isGrounded = false;
    public bool isClimbing = false;
    
    //caching
    private Animator myAnimator;
    private Rigidbody2D myRigidbody;
    private SpriteRenderer mySpriteRenderer;


    private void Awake() //caching the character components
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        myAnimator.SetBool("isGrounded", true);
    }

    private void FixedUpdate() //for physical updates, moving and jumping
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        myRigidbody.velocity = new Vector2(horizontalInput * speed, myRigidbody.velocity.y);

        Debug.Log("Vertical Input: " + verticalInput);
        if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && (isGrounded || isClimbing) && (myRigidbody.velocity == new Vector2(myRigidbody.velocity.x, 0f)))
        {
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
            isGrounded = false;
            myAnimator.SetBool("isGrounded", false);
            myAnimator.SetTrigger("Jump");
            jumpSound.Play();
        }

        // Climbing
        if (isClimbing && verticalInput != 0)
        {
             isGrounded = false;
             myAnimator.SetBool("Climbing", isClimbing);
             myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, verticalInput * climbSpeed);
             myRigidbody.gravityScale = 0.01f;
          
        }
        if (horizontalInput >= 0.1f)
        {
            myAnimator.SetBool("Walking", true);
            mySpriteRenderer.flipX = false;
            if (!walkSound.isPlaying && isGrounded)
            {

                walkSound.Play();
            }
        } else if (horizontalInput <= -0.1f)
        {
            myAnimator.SetBool("Walking", true);
            mySpriteRenderer.flipX = true;
            if (!walkSound.isPlaying && isGrounded)
            {

                walkSound.Play();
            }
        } else if (horizontalInput == 0)
        {
            myAnimator.SetBool("Walking", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            myAnimator.SetBool("isGrounded", true);
            myAnimator.SetBool("Climbing", false);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ladder"))
        {
            isClimbing = true;
            isGrounded = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isClimbing = false;
            myAnimator.SetBool("Climbing", isClimbing);
            myRigidbody.gravityScale = 5f;
        }
    }
}
