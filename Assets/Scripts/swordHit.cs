using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class swordHit : MonoBehaviour
{

    public bool didHit = false;

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("SwordPullOut");
    }

    // Update is called once per frame
    void Update()
    {

    }

    bool doDamage = true;
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("enemy") && doDamage){
            //Debug.Log("Sword Hit Enemy");
            FindObjectOfType<AudioManager>().Play("ZombieHit");
            Destroy(collision.gameObject);
            GetStats.setTotalZombies(GetStats.getTotalZombies() - 1);
            doDamage = false;
            Debug.Log(GetStats.getTotalZombies());
            
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            doDamage = true;

        }
    }

    public bool getHit()
    {
        return didHit;
    }

    public void setHit(bool hold)
    {
        didHit = hold;
    }
}
