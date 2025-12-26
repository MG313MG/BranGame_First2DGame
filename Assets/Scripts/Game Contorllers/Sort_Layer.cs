using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Sort_Layer : MonoBehaviour
{
    public string sortingLayerName = "Default"; // ??? ????
    public int sortingOrder = 0;                // ????? ???? ????

    void Awake()
    {
        Renderer rend = GetComponent<Renderer>();
        rend.sortingLayerName = sortingLayerName;
        rend.sortingOrder = sortingOrder;
    }
}
