using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PressPlay () 
    {
        print("new scene");
        SceneManager.LoadScene("TestDugen");
    }

    public void QuitGame(){
        Debug.Log("Quit");
        Application.Quit();
    }
}
