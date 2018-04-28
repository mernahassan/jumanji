using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tigercollider : MonoBehaviour {

    public int Damage;
    public Tiger owner;
    void OnTriggerEnter(Collider other)
    {
        stefaniController somebody = other.gameObject.GetComponent<stefaniController>();
        if (somebody != null && owner.state=="hit")
        {
            stefHealth health = somebody.GetComponent<stefHealth>();
            if (health != null)
            {
                health.TakeDamage(Damage);
            }

        }

    }
}
