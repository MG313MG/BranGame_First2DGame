using UnityEngine;
using UnityEngine.SceneManagement;

public class Start_Menu : MonoBehaviour
{
    public void Play_Game()
    {
        SceneManager.LoadScene("Select_Level");
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
