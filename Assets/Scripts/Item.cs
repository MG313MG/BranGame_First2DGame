using UnityEngine;

public class Item : MonoBehaviour
{
    public GameObject EffectPerfab;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null)
        {
            Instantiate(EffectPerfab, transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
