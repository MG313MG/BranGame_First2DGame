using UnityEngine;
using UnityEngine.SceneManagement;

public class Start_Menu_Game_Manager : MonoBehaviour
{
    public GameObject Start_menu;
    public GameObject Play_List;
    public GameObject Store_menu;
    public GameObject Setting_menu;

    public void Open_Play_List()
    {
        Start_menu.SetActive(false);
        Play_List.SetActive(true);
    }
    public void Back_to_Start_Menu()
    {
        Start_menu.SetActive(true);
        Play_List.SetActive(false);
        Store_menu.SetActive(false);
        Setting_menu.SetActive(false);
    }
    public void Open_store_menu()
    {
        Start_menu.SetActive(false);
        Store_menu.SetActive(true);
    }
    public void Open_Setting()
    {
        Start_menu.SetActive(false);
        Setting_menu.SetActive(true);
    }
    public void Open_Level_1()
    {
        SceneManager.LoadScene("Level 1");
    }
    public void Open_Level_2()
    {
        SceneManager.LoadScene("Level 2");
    }
    public void Open_Level_3()
    {
        SceneManager.LoadScene("Level 3");
    }
    public void Quit_Game()
    {
        Application.Quit();
    }
}
