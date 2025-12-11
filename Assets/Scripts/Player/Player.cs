using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    [Header("Health")]
    public int Health = 3;

    [Header("Movement speed")]
    [SerializeField] private float Speed;
    [SerializeField] private float Jump;

    [Header("Collision")]
    [SerializeField] private float GroundCheckDistance;
    [SerializeField] private float WallCkeckDistance;
    [SerializeField] private LayerMask LayerGround;

    [Header("Prefab")]
    [SerializeField] private GameObject DieEffect; 

    private bool IsGrounded;
    private bool IsWall;
    private bool IsWallJumping;
    private bool isHit;
    private bool DontHit;

    private float xInput;
    private bool FaceRight = true;
    private float FaceDir = 1;

    private float xScale;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        xScale = transform.localScale.x;

        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Health <= 0)
        {
            Instantiate(DieEffect, transform.position,Quaternion.identity);
            Destroy(gameObject);
        }

        xInput = Input.GetAxisRaw("Horizontal");

        if (IsWall)
        {
            rb.linearDamping = 8;
        }
        else
        {
            rb.linearDamping = 0;
        }
        if (isHit)
            return;
        if (Input.GetKeyDown(KeyCode.E))
        {
            Hit();
        }

        Movement();
        FlipFace();
        Jump_key();
        Anim_idle_run();
        HandleCollision();
    }

    private void HandleCollision()
    {
        IsGrounded = Physics2D.Raycast(transform.position, Vector2.down, GroundCheckDistance, LayerGround);
        IsWall = Physics2D.Raycast(transform.position, Vector2.right * FaceDir, WallCkeckDistance, LayerGround);
    }

    private void Jump_key()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, Jump);
        }
        if (Input.GetKeyDown(KeyCode.Space) && !IsGrounded && IsWall)
        {
            if (FaceRight)
            {
                FaceRight = false;
                FaceDir = -1;
                transform.localScale = new Vector3(-xScale, transform.localScale.y, transform.localScale.z);
                rb.linearVelocity = new Vector2(-6, Jump);
            }
            else if (!FaceRight)
            {
                FaceDir = 1;
                FaceRight = true;
                transform.localScale = new Vector3(xScale, transform.localScale.y, transform.localScale.z);
                rb.linearVelocity = new Vector2(6, Jump);
            }
            StopAllCoroutines();
            DontHit = false;
            GetComponent<SpriteRenderer>().enabled = true;
            StartCoroutine(WallJumping());
        }
    }
    private IEnumerator WallJumping()
    {
        IsWallJumping = true;
        yield return new WaitForSeconds(0.7f);
        IsWallJumping = false;
    }

    private void Anim_idle_run()
    {
        anim.SetBool("IsGrounded", IsGrounded);
        anim.SetBool("IsWall",IsWall);
        anim.SetFloat("xVelocity", rb.linearVelocity.x);
        anim.SetFloat("yVelocity", rb.linearVelocity.y);
    }

    //Flip face to right and left
    private void FlipFace()
    {
        if (IsWallJumping)
            return;

        if (xInput == -1)
        {
            FaceRight = false;
            FaceDir = -1;
            transform.localScale = new Vector3(-xScale, transform.localScale.y, transform.localScale.z);
        }
        if (xInput == 1)
        {
            FaceDir = 1;
            FaceRight = true;
            transform.localScale = new Vector3(xScale, transform.localScale.y, transform.localScale.z);
        }
    }

    //Move with A and D button
    private void Movement()
    {
        if (IsWall)
            return;

        if (IsWallJumping)
            return;

        if (isHit) 
            return;
    
        rb.linearVelocity = new Vector2(xInput * Speed, rb.linearVelocityY);
    }

    public void Hit()
    {
        if (isHit) 
            return;
        if (DontHit) 
            return;

        Health -= 1;
        anim.SetTrigger("isHit");

        IsWallJumping = false;

        if (FaceRight)
        {
            rb.linearVelocity = new Vector2(-4, rb.linearVelocity.y);
        }
        else if (!FaceRight)
        {
            rb.linearVelocity = new Vector2(4, rb.linearVelocity.y);
        }
        StopAllCoroutines();
        StartCoroutine(Hitting());
    }

    private IEnumerator Hitting()
    {
        isHit = true;
        yield return new WaitForSeconds(0.3f);
        isHit = false;
        StartCoroutine(Hitting_Animation());
    }

    private IEnumerator Hitting_Animation()
    {
        DontHit = true;
        GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(0.1f);
        DontHit = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Trap")
        {
            Hit();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, new Vector2(transform.position.x, transform.position.y - GroundCheckDistance));
        Gizmos.DrawLine(transform.position, new Vector2(transform.position.x + (WallCkeckDistance * FaceDir), transform.position.y));
    }
}
