using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UpgradeScripts : MonoBehaviour
{
    [SerializeField] public GameObject canvasRestart;

    public void upgradeHealth()
    {
        HealthSystem.updateHealth();
        //Debug.Log(GetStats.getHealth());
        string currentSceneN = SceneManager.GetActiveScene().name;
        if (currentSceneN == "Tower")
        {
            SceneManager.LoadScene("TowerALT");
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("TowerALT"));
        }
        else
        {
            SceneManager.LoadScene("Tower");
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("Tower"));

        }
    }

    public void upgradeSpeed()
    {
        FPSController.upgradeSpeed();
        //Debug.Log(GetStats.getSpeed());
        string currentSceneN = SceneManager.GetActiveScene().name;
        if (currentSceneN == "Tower")
        {
            SceneManager.LoadScene("TowerALT");
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("TowerALT"));
        }
        else
        {
            SceneManager.LoadScene("Tower");
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("Tower"));

        }
    }

}
