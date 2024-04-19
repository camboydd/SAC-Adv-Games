using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordHit : MonoBehaviour
{

    public bool didHit = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemy")){
            Debug.Log("Sword Hit Enemy");
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
