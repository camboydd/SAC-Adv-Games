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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemy")){
            Debug.Log("Sword Hit Enemy");
            FindObjectOfType<AudioManager>().Play("ZombieHit");
            Destroy(collision.gameObject);
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
