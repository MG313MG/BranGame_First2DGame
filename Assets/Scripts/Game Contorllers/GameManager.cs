using Unity.Properties;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private AudioSource MyAudio;

    private GameObject Player;
    private GameObject End;
    public GameObject Music;

    public GameObject[] Health;
    public GameObject Win;
    public GameObject Lose;
    public GameObject Pause;

    [SerializeField] private bool isStop;

    
    void Start()
    {
        Time.timeScale = 1;
        MyAudio = GetComponent<AudioSource>();

        Player = GameObject.FindGameObjectWithTag("Player");
        End = GameObject.FindGameObjectWithTag("End");
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            string Loaded_scene = SceneManager.GetActiveScene().name;
            if (Loaded_scene != "Start_menu")
            {
                if (!isStop)
                {
                    Time.timeScale = 0;
                    Pause.SetActive(true);
                }
                else
                {
                    Time.timeScale = 1;
                    Pause.SetActive(false);
                }
                isStop = !isStop;
            }
        }

        if (Player == null)
        {
            Lose.SetActive(true);
            Time.timeScale = 0;
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
            Time.timeScale = 0;
            Music.SetActive(true);
        }
    }
}
