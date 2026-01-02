using System.Collections;
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
        AudioManager.Instance.Click_on_Buttons();
    }
    public void Back_to_Start_Menu()
    {
        Start_menu.SetActive(true);
        Play_List.SetActive(false);
        Store_menu.SetActive(false);
        Setting_menu.SetActive(false);
        AudioManager.Instance.Click_on_Buttons();
    }
    public void Back_to_Play_List_from_Levels()
    {
        SceneManager.LoadScene("Start_menu");
        AudioManager.Instance.Click_on_Buttons();
    }
    public void Open_store_menu()
    {
        Start_menu.SetActive(false);
        Store_menu.SetActive(true);
        AudioManager.Instance.Click_on_Buttons();
    }
    public void Open_Setting()
    {
        Start_menu.SetActive(false);
        Setting_menu.SetActive(true);
        AudioManager.Instance.Click_on_Buttons();
    }
    public void Open_Level_1()
    {
        SceneManager.LoadScene("Level 1");
        AudioManager.Instance.Click_on_Buttons();
    }
    public void Open_Level_2()
    {
        SceneManager.LoadScene("Level 2");
        AudioManager.Instance.Click_on_Buttons();
    }
    public void Open_Level_3()
    {
        SceneManager.LoadScene("Level 3");
        AudioManager.Instance.Click_on_Buttons();
    }
    public void Reload_Level()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        AudioManager.Instance.Click_on_Buttons();
    }
    public void Quit_Game()
    {
        Application.Quit();
        AudioManager.Instance.Click_on_Buttons();
    }
}
