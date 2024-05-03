using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{

    [SerializeField] public GameObject canvasRestart;
    public void pressRestart()
    {
        print("restart");
        string currentSceneN = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneN);
        //SceneManager.SetActiveScene(SceneManager.GetSceneByName("TestDugen"));
    }

    public void pressQuit()
    {
        SceneManager.LoadScene("Start Screen");
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Start Screen"));
    }

    public void hideMenu()
    {
        canvasRestart.SetActive(false);
    }
}
