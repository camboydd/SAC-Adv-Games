using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{

    [SerializeField] public GameObject SliderTEST;
    [SerializeField] public GameObject canvasRestart;
    [SerializeField] public static int maxHealth;
    [SerializeField] public static int Health;
    [SerializeField] private int Damage;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject stats;
    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        Health = maxHealth;
        Health = GetStats.getHealth();
        maxHealth = Health;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F))
        {

            GetStats.setHealth((GetStats.getHealth()) + 20);
            Health = GetStats.getHealth();
            maxHealth = Health;
            Debug.Log(maxHealth);
            //ApplyHealing();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            DamageHealth();
        }

        slider.value = Health;
    }

    public void DamageHealth()
    {
        if(Health > 0)
        {
            Health = Health - Damage;
            if(Health <= 0)
            {
                canvasRestart.SetActive(true);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }

    void ApplyHealing()
    {
        if (Health < maxHealth)
        {
            Health = Health + Damage;
        }
    }

    public int getHealth()
    {
        return Health;
    }

    public void setHealth(int x)
    {
        Health = x;
    }

    public void destroyPlayer()
    {
        Destroy(player);
    }

    public static void updateHealth()
    {
        GetStats.setHealth((GetStats.getHealth()) + 20);
        int x = GetStats.getHealth();
        Health = x;
        maxHealth = Health;
    }

    private void Awake()
    {
        DontDestroyOnLoad(stats);
    }
}
