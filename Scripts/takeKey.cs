using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takeKey : MonoBehaviour {

    public GameObject gate;

    private void OnTriggerEnter(Collider other)
    {
        gate.transform.Translate(0, 45, 0);
        Destroy(gameObject);
    }

}
