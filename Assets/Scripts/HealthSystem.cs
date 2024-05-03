using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{

    [SerializeField] public GameObject SliderTEST;
    [SerializeField] public GameObject canvasRestart;
    [SerializeField] private int maxHealth;
    [SerializeField] private int Health;
    [SerializeField] private int Damage;
    [SerializeField] private GameObject player;
    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        Health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ApplyHealing();
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

    public void destroyPlayer()
    {
        Destroy(player);
    }
}
