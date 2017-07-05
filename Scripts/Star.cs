using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour {
    public float destroytime;
	// Use this for initialization
	void Start () {
        destroytime = 3;

    }
	
	// Update is called once per frame
	void Update () {
        Movement();
        Destroy();
    }
    void Movement()
    {
        transform.Translate(new Vector3(-0.1f, -0.1f, 0) * 40 * Time.deltaTime);
    }
    void Destroy()
    {
        destroytime -= Time.deltaTime;
        if (destroytime < 0)
        {
            Destroy(gameObject);
        }
    }
}
