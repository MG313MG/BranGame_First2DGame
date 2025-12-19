using UnityEngine;

public class Item : MonoBehaviour
{
    public GameObject EffectPerfab;

    private GameObject FindPlayer;

    [SerializeField] private float Add_score;

    private Player player;

    private void Start()
    {
        FindPlayer = GameObject.FindWithTag("Player");
        player = FindPlayer.GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null)
        {
            player.Score += Add_score;
            Debug.Log(player.Score);
            Instantiate(EffectPerfab, transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
