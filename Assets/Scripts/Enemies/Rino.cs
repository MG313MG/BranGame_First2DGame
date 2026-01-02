using System.Collections;
using UnityEngine;

public class Rino : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    [Header("Movement")]
    [SerializeField] private float Speed;

    [Header("Health")]
    public int Health;

    [Header("Collosion")]
    [SerializeField] private float GroundCheckDistance;
    [SerializeField] private float WallCheckDistance;
    [SerializeField] private float PlayerCheckDistance;
    [SerializeField] private Transform CheckNoGroundtransform;
    [SerializeField] private LayerMask LayerGround;
    [SerializeField] private LayerMask LayerPlayer;
    [SerializeField] private float Speed1;
    [SerializeField] private bool PlayerisHere;



    private bool damaged = false;
    private bool isHit;
    public bool isGrounded;
    public bool CheckNoGround;
    public bool isWall;
    public bool isPlayer;
    public GameObject Perfab;


    private bool FaceRight = false;
    private float FaceDir = -1;
    private float WalkorRun = 0;

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
        Destroyer();

        Damage();

        HandleAnimation();

        if (!PlayerisHere)
            HandelFlip();

        Collision();
    }

    private void Destroyer()
    {
        if (Health == 0)
        {
            Destroy(gameObject);
            Instantiate(Perfab, transform.position, Quaternion.identity);
        }
    }

    private void Damage()
    {
        if (damaged)
            return;

        if (PlayerisHere && isWall)
        {
            AudioManager.Instance.PlayEnemiesSound(EnemiesSounds.Cast_Rino_to_Wall);
            damaged = true;
            anim.SetTrigger("isHit");
            Health -= 1;
            PlayerCheckDistance = 1;
            StartCoroutine(Hitting());
        }
    }

    private void HandleAnimation()
    {
        if (isPlayer && !FaceRight)
        {
            PlayerisHere = true;
            Speed1 = 2.5f;
        }
        if (isPlayer && FaceRight)
        {
            PlayerisHere = true;
            Speed1 = 2.5f;
        }
        if (PlayerisHere)
        {
            WalkorRun = 1;
            anim.SetFloat("WalkorRun", WalkorRun);
            StartCoroutine(PlayerHere());
        }
        else if (!PlayerisHere)
        {
            WalkorRun = 0;
            anim.SetFloat("WalkorRun", WalkorRun);
        }

        rb.linearVelocity = new Vector2(Speed * Speed1 * FaceDir, rb.linearVelocity.y);
    }

    private void HandelFlip()
    {
        if (!CheckNoGround || isWall)
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
        CheckNoGround = Physics2D.Raycast(CheckNoGroundtransform.transform.position, Vector2.down, GroundCheckDistance, LayerGround);
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, GroundCheckDistance, LayerGround);
        isPlayer = Physics2D.Raycast(transform.position, Vector2.right * FaceDir, PlayerCheckDistance, LayerPlayer);
    }

    private IEnumerator PlayerHere()
    {
        yield return new WaitForSeconds(1.2f);
        PlayerisHere = false;
        Speed1 = 1;
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
        PlayerCheckDistance = 9;
        damaged = false;
        Speed1 = 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null)
        {
            collision.GetComponent<Player>().Hit();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, new Vector2(transform.position.x, transform.position.y - GroundCheckDistance));
        Gizmos.DrawLine(transform.position, new Vector2(transform.position.x + WallCheckDistance * FaceDir, transform.position.y));
        Gizmos.DrawLine(CheckNoGroundtransform.transform.position, new Vector2(CheckNoGroundtransform.position.x,CheckNoGroundtransform.position.y - GroundCheckDistance));
        Gizmos.DrawLine(transform.position, new Vector2(transform.position.x + PlayerCheckDistance * FaceDir, transform.position.y));
    }
}
