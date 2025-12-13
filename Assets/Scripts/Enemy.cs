using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb;

    [Header("Movement")]
    [SerializeField] private float Speed;

    [Header("Collision")]
    [SerializeField] private float GroundCheckDistance;
    [SerializeField] private float WallCheckDistance;
    [SerializeField] private Transform CheckNoGroundTransform;
    [SerializeField] private LayerMask LayerGround;

    public bool isGrounded;
    public bool CheckNoGround;
    public bool isWall;

    private bool faceRight = false;
    private float faceDir = -1;

    private float xScale;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        xScale = transform.localScale.x;
    }

    
    void Update()
    {

        rb.linearVelocity = new Vector2 (faceDir * Speed, rb.linearVelocity.y);

        HandleFlip();
        HandleCollision();
    }

    private void HandleCollision()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, GroundCheckDistance, LayerGround);
        CheckNoGround = Physics2D.Raycast(CheckNoGroundTransform.transform.position, Vector2.down, GroundCheckDistance, LayerGround);
        isWall = Physics2D.Raycast(transform.position, Vector2.right * faceDir, WallCheckDistance, LayerGround);
    }

    private void HandleFlip()
    {
        if (isGrounded)
        {
            if (isWall || !CheckNoGround)
            {
                faceRight = !faceRight;
            }
        }

        if (faceRight)
        {
            faceDir = 1;
            transform.localScale = new Vector3(-xScale, transform.localScale.y, transform.localScale.z);
        }
        else if (!faceRight)
        {
            faceDir = -1;
            transform.localScale = new Vector3(xScale, transform.localScale.y, transform.localScale.z);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position,new Vector2(transform.position.x, transform.position.y - GroundCheckDistance));
        Gizmos.DrawLine(CheckNoGroundTransform.position, new Vector2(CheckNoGroundTransform.position.x, CheckNoGroundTransform.position.y - GroundCheckDistance));
        Gizmos.DrawLine(transform.position, new Vector2(transform.position.x + (faceDir * WallCheckDistance), transform.position.y));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null)
        {
            collision.GetComponent<Player>().Hit();
        }
    }
}
