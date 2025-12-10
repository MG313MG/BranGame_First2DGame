using UnityEngine;

public class Abbys : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Rino>() != null)
        {
            collision.GetComponent<Rino>().Health = 0;
        }

        if (collision.GetComponent<Player>() != null)
        {
            collision.GetComponent<Player>().Health = 0;
        }
    }
}
