using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // all the linked items with variables 
    private Rigidbody playerRb;
    private Animator playerAnim;
    private AudioSource playerAudio;
    public ParticleSystem explosionParticle;
    public ParticleSystem DirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    public float jumpForce = 10;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        // gives the player animations audio and gravityw
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;

    }

    // Update is called once per frame
    void Update()
    {
        // detects whe the player presses the space key
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            // makes the player jump and activate the jump animation when you press space
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            
            // gives the player particles
            DirtParticle.Stop();
            
            // gives the jump audio
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
    }

    // detects when the player collides with a object
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            // detects if the player is on the ground
            isOnGround = true;
            DirtParticle.Play();
        }
        else if(collision.gameObject.CompareTag("Obstacle"))
        {
            // gives the game over message
            Debug.Log("Game Over");
            gameOver = true;
            
            // gives the player animations
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
           
            // gives the player particle effects/sounds
            explosionParticle.Play();
            DirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
    }
}
