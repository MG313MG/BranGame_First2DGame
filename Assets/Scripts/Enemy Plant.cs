using System.Collections;
using UnityEngine;

public class EnemyPlant : MonoBehaviour
{
    [Header("Collision")]
    [SerializeField] private LayerMask layerplayer;
    [SerializeField] private float PlayerCheckDistance;

    [SerializeField] private bool isPlayer;
    [SerializeField] private bool Ammo_is_Loaded;
    public bool BullethasSpawn;

    private Animator anim;

    public GameObject Bullet;

    [SerializeField] private float Attakoridle;

    public Bullet bullet;
    
    void Start()
    {
        Ammo_is_Loaded = true;
        BullethasSpawn = false;

        Attakoridle = 0;

        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        anim.SetFloat("Attakoridle", Attakoridle);
        

        HandleAnimate();

        Collision();

        
    }

    private void HandleAnimate()
    {
        if (isPlayer && Ammo_is_Loaded)
        {
            Attakoridle = 1;
            if (!BullethasSpawn && isPlayer && Ammo_is_Loaded)
            {
                BullethasSpawn = true;
                StartCoroutine(Spawn_Bullet());
            }
            
            StartCoroutine(Ammo_Loading());
        }
        else if (!isPlayer || !Ammo_is_Loaded)
        {

            BullethasSpawn = false;
            Attakoridle = 0;
            
        }
       
    }

    public GameObject SpawnObject(Vector3 position, Quaternion rotation)
    {
        return Instantiate(Bullet, position, rotation);
    }

    private void Collision()
    {
        isPlayer = Physics2D.Raycast(transform.position, Vector2.left, PlayerCheckDistance, layerplayer);
    }

    private IEnumerator Ammo_Loading()
    {
        yield return new WaitForSeconds(0.8f);
        Ammo_is_Loaded = false;
        yield return new WaitForSeconds(1.2f);
        Ammo_is_Loaded = true;
    }
    private IEnumerator Spawn_Bullet()
    {
        yield return new WaitForSeconds(0.4f);
        SpawnObject(new Vector3(transform.position.x, transform.position.y + 0.3f, transform.position.z), Quaternion.identity);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, new Vector2(transform.position.x - PlayerCheckDistance, transform.position.y));
    }
}
