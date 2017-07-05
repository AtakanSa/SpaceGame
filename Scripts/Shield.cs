using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour {
    Animator anim;
    public GameObject player;
    public int healt;
	// Use this for initialization
	void Start () {
        transform.localScale = new Vector3(0.5f, 0.5f,1);
        //transform.gameObject.ScriptComponent.Animator.runtimeAnimatorController = Resources.Load("soldier_walk1") as RuntimeAnimatorController;
        anim = gameObject.GetComponent<Animator>();
        anim.runtimeAnimatorController = Resources.Load("sun2") as RuntimeAnimatorController;
        player = GameObject.FindGameObjectWithTag("player");
        healt = 1;
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = player.transform.position;

        if (healt == 0)
        {
            Destroy(gameObject);
        }
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "sword")
        {
            Destroy(gameObject);

        }
    }
}
