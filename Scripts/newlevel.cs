using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class newlevel : MonoBehaviour {
    public int index;
    public float x,y,z;
    GameObject stef;
    GameObject pausemenu;
    void Start()
    {
        stef = GameObject.FindWithTag("Player");
        pausemenu = GameObject.FindWithTag("Pause");
    }
    
    void OnTriggerEnter(Collider col)
    {
        stef.transform.position = new Vector3(x,y, z);
        DontDestroyOnLoad(stef);
        DontDestroyOnLoad(pausemenu);
        SceneManager.LoadScene(index);
    }
}
