using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetStats : MonoBehaviour
{

    public static int addedSpeed;
    public static int addedHealth;
    public static int totalZombies;


    // Start is called before the first frame update
    void Start()
    {
        addedSpeed = 3;
        addedHealth = 100;
        totalZombies = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static int getSpeed()
    {
        return addedSpeed;
    }

    public static void setSpeed(int x)
    {
        addedSpeed = x;
    }

    public static int getHealth()
    {
        return addedHealth;
    }

    public static void setHealth(int x)
    {
        addedHealth = x;
    }

    public static void setTotalZombies(int x)
    {
        totalZombies = x;
    }

    public static int getTotalZombies()
    {
        return totalZombies;
    }


}
