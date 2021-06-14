using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float jumpVelocity = 2f;
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] AudioClip jumpSound;

    // Start is called before the first frame update

    private bool isGrounded;
    public Transform feetPosition;
    public float checkRadius;
    public LayerMask whatIsGround;
    private Rigidbody2D rb;
    private float moveInput;

    private Animator anim;
    Coroutine kickingRoutine;
    GameStatus gameStatus;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        gameStatus = FindObjectOfType<GameStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        IsPlayerGrounded();
        if (gameStatus.enablePlayerInput) {
            Move();
            Jump();
            Kick();
        }
    }

    private void Move() {
        if (gameObject.tag == "Player 1") {
            moveInput = Input.GetAxis("Horizontal2");
            rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        }
        if (gameObject.tag == "Player 2") {
            moveInput = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        }
        //var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        //var newPosX = Mathf.Clamp((transform.position.x + deltaX), xMin, xMax);
        //transform.position = new Vector2(newPosX, transform.position.y);
    }

    private void Jump() {
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded) {
            if (gameObject.tag == "Player 1") {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0f, jumpVelocity);
                PlayBlockDestroySFX();
            }
        } if (Input.GetKeyDown(KeyCode.W) && isGrounded) {
            if (gameObject.tag == "Player 2") {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0f, jumpVelocity);
                PlayBlockDestroySFX();
            }
        }
    }

    private void IsPlayerGrounded() {
        isGrounded = Physics2D.OverlapCircle(feetPosition.position, checkRadius, whatIsGround);
    }

    //private void Kick() {
    //    if (Input.GetKeyDown(KeyCode.Space)) {
    //        anim.SetBool("isKicked", true);
    //    } else {
    //        //anim.SetBool("isKicked", false);
    //    }
    //}

    private void Kick() {
        if (gameObject.tag == "Player 1") {
            if (Input.GetButtonDown("Kick")) {
                kickingRoutine = StartCoroutine(KickAnim());
            }
            if (Input.GetButtonUp("Kick")) {
                StopCoroutine(kickingRoutine);
                anim.SetBool("isKicked", false);
            }
        }
        if (gameObject.tag == "Player 2") {
            if (Input.GetButtonDown("Kick2")) {
                kickingRoutine = StartCoroutine(KickAnim());
            }
            if (Input.GetButtonUp("Kick2")) {
                StopCoroutine(kickingRoutine);
                anim.SetBool("isKicked", false);
            }
        }
    }

    IEnumerator KickAnim() {
        //while (true) {
        anim.SetBool("isKicked", true);
        yield return new WaitForSeconds(1f);
        //}
    }

    private void PlayBlockDestroySFX() {
        AudioSource.PlayClipAtPoint(jumpSound, Camera.main.transform.position);
    }
}
