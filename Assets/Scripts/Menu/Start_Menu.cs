using UnityEngine;
using UnityEngine.SceneManagement;

public class Start_Menu : MonoBehaviour
{
    public GameObject StartMenu;
    public GameObject Levels_List;
    public GameObject Store;
    public GameObject Setting;

    public void Play_Game()
    {
        StartMenu.SetActive(false);
        Levels_List.SetActive(true);
    }
    public void Open_Store()
    {
        SceneManager.LoadScene("");
    }
    public void Open_Setting() 
    {
        SceneManager.LoadScene("");
    }
    public void Quit_Game()
    {
        Application.Quit();
    }
}
