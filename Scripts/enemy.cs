using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {

    public GameObject[] obj;
    public GameObject here;
    public int size;
    int randEnemy;
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        randEnemy = Random.Range(0, size);
        GameObject e = (GameObject)Instantiate(obj[randEnemy],here.transform.position,here.transform.rotation);
        e.transform.Translate(5f, 0, 0);
       
    }
}
