using System.Collections;
using UnityEngine;

public class Pig : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    [Header("Movement")]
    [SerializeField] private float Speed;
    [Header("Health")]
    [SerializeField] private int Health;

    [Header("Collision")]
    [SerializeField] private float PlayerCheckDistance1;
    [SerializeField] private float PlayerCheckDistance2;
    [SerializeField] private float GrondCheckDistance;
    [SerializeField] private float WallCheckDistance;
    [SerializeField] private float Speed1;
    [SerializeField] private Transform CheckNoGroundTransform;
    [SerializeField] private LayerMask LayerGround;
    [SerializeField] private LayerMask LayerPlayer;

    [SerializeField] private bool isPlayer1;
    [SerializeField] private bool isPlayer2;
    [SerializeField] private bool isWall;
    [SerializeField] private bool isGrounded;
    [SerializeField] private bool CheckNoGround;
    [SerializeField] private GameObject Perfab;

    private float FaceDir = -1;
    private float WalkorRun = 0;
    private bool FaceRight = false;
    private bool Damaged = false;

    private float xScale;



    
    void Start()
    {
        Speed1 = 1;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        xScale = transform.localScale.x;
    }


    void Update()
    {
        if (!Damaged)
        {
            rb.linearVelocity = new Vector2(Speed * Speed1 * FaceDir, rb.linearVelocity.y);
        }
        anim.SetFloat("WalkorRun", WalkorRun);

        if (Health == 0)
        {
            Destroy(gameObject);
            Instantiate(Perfab, transform.position, Quaternion.identity);
        }

        Attak();

        HandelFlip();

        Collision();
    }

    private void Attak()
    {
        if (isPlayer1 && !Damaged)
        {
            WalkorRun = 1;
            Speed1 = 3;
        }
        else if (Damaged)
        {
            WalkorRun = 0;
        }
        else if (!isPlayer1)
        {
            //new WaitForSeconds(1);
            WalkorRun = -1;
            Speed1 = 1;
        }
    }

    private void HandelFlip()
    {
        if (isWall || !CheckNoGround)
        {
            FaceRight = !FaceRight;
        }
        if (FaceRight)
        {
            FaceDir = 1;
            transform.localScale = new Vector3(-xScale, transform.localScale.y, transform.localScale.z);
        }
        else if (!FaceRight)
        {
            FaceDir = -1;
            transform.localScale = new Vector3(xScale, transform.localScale.y, transform.localScale.z);
        }
    }

    private void Collision()
    {
        isWall = Physics2D.Raycast(transform.position, Vector2.right * FaceDir, WallCheckDistance, LayerGround);
        isPlayer1 = Physics2D.Raycast(transform.position, Vector2.right * FaceDir, PlayerCheckDistance1, LayerPlayer);
        isPlayer2 = Physics2D.Raycast(transform.position, Vector2.up, PlayerCheckDistance2, LayerPlayer);
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, GrondCheckDistance, LayerGround);
        CheckNoGround = Physics2D.Raycast(CheckNoGroundTransform.transform.position, Vector2.down, GrondCheckDistance, LayerGround);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null && isPlayer2 && !Damaged)
        {
            anim.SetTrigger("isHit");
            Speed1 = 0;
            Health -= 1;
            Damaged = true;
            StartCoroutine(Hitting());
        }
        else if (collision.GetComponent<Player>() != null && !Damaged)
        {
            collision.GetComponent<Player>().Hit();
        }
    }

    private IEnumerator Hitting()
    {
        Speed1 = 0;
        yield return new WaitForSeconds(0.3f);
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
        yield return new WaitForSeconds(5);
        PlayerCheckDistance1 = 11;
        Speed1 = 1;
        Damaged = false;
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, new Vector2(transform.position.x + (PlayerCheckDistance1 * FaceDir), transform.position.y));
        Gizmos.DrawLine(transform.position, new Vector2(transform.position.x, transform.position.y + PlayerCheckDistance2));
        Gizmos.DrawLine(transform.position, new Vector2(transform.position.x + (WallCheckDistance * FaceDir), transform.position.y));
        Gizmos.DrawLine(transform.position, new Vector2(transform.position.x, transform.position.y - GrondCheckDistance));
        Gizmos.DrawLine(CheckNoGroundTransform.transform.position, new Vector2(CheckNoGroundTransform.position.x, CheckNoGroundTransform.position.y - GrondCheckDistance));
    }
}
