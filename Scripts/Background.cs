using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {

    public bool start;
	// Use this for initialization
	void Start () {
        start = false;
	}
	
	// Update is called once per frame
	void Update () {
        Movement();

    }

    void Movement()
    {
        if (start)
        {
            transform.Translate(new Vector3(0f, -0.1f, 0) * 2 * Time.deltaTime);
             
        }
    }
}
