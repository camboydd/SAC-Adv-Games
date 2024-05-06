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
        if(currentSceneN == "Tower")
        {
            SceneManager.LoadScene("TowerALT");
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("TowerALT"));
        }
        else
        {
            SceneManager.LoadScene("Tower");
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("Tower"));

        }
        
        //SceneManager.LoadScene(currentSceneN);
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
