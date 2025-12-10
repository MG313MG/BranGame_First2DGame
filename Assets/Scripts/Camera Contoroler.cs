using UnityEngine;

public class CameraContoroler : MonoBehaviour
{
    private GameObject Targert;
    [SerializeField] private float Speed;

    
    void Start()
    {
        Targert = GameObject.FindGameObjectWithTag("Player");
    }

    
    void Update()
    {
        if (Targert == null)
            return;

        if (transform.position.y < 7 || transform.position.y > -31)
            transform.position = Vector3.Lerp(transform.position, new Vector3(Targert.transform.position.x, Targert.transform.position.y, transform.position.z), Speed * Time.deltaTime);
        else
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z), Speed * Time.deltaTime);
        } 

    }
}
