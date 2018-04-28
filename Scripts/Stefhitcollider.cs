using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stefhitcollider : MonoBehaviour {

    public int Damage;
    public stefaniController owner;
    void OnTriggerEnter(Collider other)
    {
        EvilMen somebody = other.gameObject.GetComponent<EvilMen>();
        THEvilController somebody2 = other.gameObject.GetComponent<THEvilController>();
        
        if (somebody != null)
        {
            Health health = somebody.GetComponent<Health>();
            if (health != null)
            {
               
                health.TakeDamage(Damage);
            }

        }else if(somebody2!=null)
        {
            Health health = somebody2.GetComponent<Health>();
            if (health != null)
            {

                health.TakeDamage(Damage);
            }
        }

    }
}
