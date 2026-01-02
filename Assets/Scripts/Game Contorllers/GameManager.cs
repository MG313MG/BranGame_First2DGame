using Unity.Properties;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private GameObject Player;
    private GameObject End;
    public GameObject Music;

    public GameObject[] Health;
    public GameObject Win;
    public GameObject Lose;
    public GameObject Pause;
    public GameObject Score;


    [SerializeField] private bool isStop;
    
    void Start()
    {
        Time.timeScale = 1;

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
                    Score.SetActive(true);
                    AudioManager.Instance.PlayUISounds(UISounds.Pause_BG_Music);
                }
                else
                {
                    Time.timeScale = 1;
                    Pause.SetActive(false);
                    Score.SetActive(false);
                    AudioManager.Instance.PlayUISounds(UISounds.UnPause_BG_Music);
                }
                isStop = !isStop;
            }
        }

        if (Player == null)
        {
            Lose.SetActive(true);
            AudioManager.Instance.PlayUISounds(UISounds.LoseMusic);
            Time.timeScale = 0;
            Score.SetActive(true);
            //Music.SetActive(false);
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
            AudioManager.Instance.PlayUISounds(UISounds.WinMusic);
            Time.timeScale = 0;
            Score.SetActive(true);
            //Music.SetActive(true);
        }
    }
}
