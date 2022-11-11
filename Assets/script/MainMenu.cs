using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    
    public void playGameorder()
    {
        SceneManager.LoadScene("Cutscene");
    }
    //เอาไว้เล่นเกม
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Closed");
    }
    //เอาไว้ออกเกม
}
