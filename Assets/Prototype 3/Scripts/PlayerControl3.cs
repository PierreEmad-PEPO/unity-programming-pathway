using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl3 : MonoBehaviour
{
    private float jumpForce = 700;
    private new Rigidbody rigidbody;
    private Animator animator;
    private bool isOnGround = true;
    private float gravityModifier = 2.3f;
    private AudioSource audioSource;

    public bool isGameOver = false;
    public ParticleSystem explosion;
    public ParticleSystem dirt;
    public AudioClip jumpMusic;
    public AudioClip crashMusic;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver && isOnGround && Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            animator.SetTrigger("Jump_trig");
            audioSource.PlayOneShot(jumpMusic);
            dirt.Stop();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !isGameOver)
        {
            isOnGround = true;
            dirt.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            isGameOver = true;
            animator.SetBool("Death_b", true);
            animator.SetInteger("DeathType_int", 1);
            dirt.Stop();
            explosion.Play();
            audioSource.PlayOneShot(crashMusic);
        }
    }
}
