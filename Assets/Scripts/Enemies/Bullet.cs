using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject Damage;

    private Rigidbody2D rb;

    public EnemyPlant enemyplant;

    [SerializeField] private float Speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //enemyplant = GetComponent<EnemyPlant>();
        StartCoroutine(Destroy_Bullet());
    }

    
    void Update()
    {
        rb.linearVelocity = new Vector2(-Speed,rb.linearVelocity.y);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null)
        {
            Instantiate(Damage, transform.position, Quaternion.identity);
            collision.GetComponent<Player>().Hit();
            Destroy(gameObject);
            
        }
    }
    private IEnumerator Destroy_Bullet() 
    {
        yield return new WaitForSeconds(4);
        AudioManager.Instance.PlayEnemiesSound(EnemiesSounds.Cast_Bullot);
        Destroy(gameObject);
    }

}
