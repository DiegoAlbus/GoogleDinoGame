using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	[SerializeField] private float jumpForce;
	private Rigidbody2D rb;
	private Animator anim;
	private bool isGrounded;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float checkRadius;
    [SerializeField] private LayerMask ground;
	public static int score;
	public static int highscore = 0;
    private int saveScore = 0;
	[SerializeField] private BoxCollider2D bc1;
	[SerializeField] private BoxCollider2D bc2;

    [SerializeField] private AudioSource deathSound;
    [SerializeField] private AudioSource jumpSound;
    [SerializeField] private AudioSource startSound;

    // Use this for initialization
    void Start () {
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

		if (!GameManager.instance.GameOver)
		{
			GameManager.instance.PlayerStarted();

			isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, ground);

			if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
			{
                jumpSound.Play();
                anim.SetBool("isJumping", true);
				rb.velocity = Vector2.up * jumpForce;
				isGrounded = false;
			}
			else
			{
				anim.SetBool("isJumping", false);
			}

			if (Input.GetKey(KeyCode.S) && isGrounded)
			{
				bc1.enabled = false;
				bc2.enabled = true;
				anim.SetBool("isCrouching", true);
			}
			else
			{
				bc2.enabled = false;
				bc1.enabled = true;
				anim.SetBool("isCrouching", false);
			}

            score += (int) Time.deltaTime + 1;

        }

		if (GameManager.instance.GameOver && Input.GetKeyDown(KeyCode.Space))
		{
			anim.SetBool("isJumping", true);
			rb.velocity = Vector2.up * jumpForce;
			isGrounded = false;
			GameManager.instance.EnterGame();
			GameManager.instance.PlayerStarted();
            startSound.Play();
            score = 0;
        }
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Obstacle"))
		{
            deathSound.Play();

            saveScore = score;

            if (saveScore >= PlayerPrefs.GetInt("highscore"))
			{
				PlayerPrefs.SetInt("highscore", saveScore);
				score = saveScore;
			} else
			{
				score = saveScore;
			}
			GameManager.instance.ShowMenu();
			GameManager.instance.PlayerCollided();
		}
	}

}
