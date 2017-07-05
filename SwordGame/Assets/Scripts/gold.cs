using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gold : MonoBehaviour {
    public float lifetime;
    Animator anim;
    // Use this for initialization
    void Start()
    {
        lifetime = 3;
        anim = gameObject.GetComponent<Animator>();
        anim.runtimeAnimatorController = Resources.Load("gold_4") as RuntimeAnimatorController;
    }

    // Update is called once per frame
    void Update()
    {
        lifetime -= Time.deltaTime;
        if (lifetime < 0)
        {
            Destroy(gameObject);
        }
    }
}