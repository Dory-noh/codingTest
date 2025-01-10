using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ui_manager_athome : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void play_main_game()
    {
        SceneManager.LoadScene(1);
    }
    public void quit_game()
    {
        PlayerPrefs.DeleteKey("Username");
        PlayerPrefs.Save();
        Application.Quit();
    }
}
