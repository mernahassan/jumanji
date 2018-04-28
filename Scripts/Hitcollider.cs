using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitcollider : MonoBehaviour {

    public int Damage;
    public EvilMen owner;
    void OnTriggerEnter(Collider col)
    {
        stefaniController somebody = col.gameObject.GetComponent<stefaniController>();
        if (owner.state == "attacking" && somebody != null)
        {
            stefHealth health = somebody.GetComponent<stefHealth>();
            somebody.movementControl("hit_head");
            if (health != null)
            {
                health.TakeDamage(Damage);
            }

        }

    }
}
