using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Levels_Menu : MonoBehaviour
{
    public void Go_Back()
    {
        SceneManager.LoadScene("Start_Menu");
    }
    public void level_1()
    {
        SceneManager.LoadScene("Level_1");
    }
    public void level_2()
    {
        SceneManager.LoadScene("Level_2");
    }
    public void level_3()
    {
        SceneManager.LoadScene("Level_3");
    }
}
