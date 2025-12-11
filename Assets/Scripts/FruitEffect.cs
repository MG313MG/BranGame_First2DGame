using System.Collections;
using UnityEngine;

public class FruitEffect : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(DestroyEffect());
    }
    private IEnumerator DestroyEffect()
    {
        yield return new WaitForSeconds(5.0f);
        Destroy(gameObject);
    }
}
