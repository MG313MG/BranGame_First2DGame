using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Levels_Menu : MonoBehaviour
{
    public GameObject StartMenu;
    public GameObject Levels_List;
    
    public void Go_Back()
    {
        StartMenu.SetActive(true);
        Levels_List.SetActive(false);
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
