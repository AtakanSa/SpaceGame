using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldParticles : MonoBehaviour {

    public float time = 3;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        destroy();

    }
    void destroy()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            Destroy(gameObject);
        }
    }
}
