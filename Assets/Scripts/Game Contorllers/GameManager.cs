using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GameManager : MonoBehaviour
{

    private AudioSource MyAudio;

    private GameObject Player;
    private GameObject End;
    public GameObject Music;

    public GameObject[] Health;
    public GameObject Win;
    public GameObject Lose;

    
    void Start()
    {
        MyAudio = GetComponent<AudioSource>();

        Player = GameObject.FindGameObjectWithTag("Player");
        End = GameObject.FindGameObjectWithTag("End");
    }

    
    void Update()
    {
        if (Player == null)
        {
            Lose.SetActive(true);
            Music.SetActive(false);
        }
        else 
        {
            for (int i = 0; i < Health.Length; i++)
            {
                if (Player.GetComponent<Player>().Health > i)
                {
                    Health[i].SetActive(true);
                }
                else
                {
                    Health[i].SetActive(false);
                }
            }
        }

        if (End == null)
        {
            Win.SetActive(true);
            Music.SetActive(true);
        }
    }
}
