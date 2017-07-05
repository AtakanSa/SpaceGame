using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondAttatck : MonoBehaviour {
    public GameObject playerr, hurtparticle, shield, shieldparticle, red, green, grey, blue;
    int selectedPlayer;
    // Use this for initialization
    void Start () {
        selectedPlayer = PlayerPrefs.GetInt("Player", 0);
        switch (selectedPlayer)
        {
            case 0:

                playerr = red;
                break;
            case 1:

                playerr = grey;
                break;
            case 2:

                playerr = green;
                break;
            case 3:

                playerr = blue;
                break;
        }

    }

    // Update is called once per frame
    void Update () {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        

    }
    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.tag == "shield")
        {

            Instantiate(shieldparticle, playerr.transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(other.gameObject);

        }
    }
    private void OnParticleTrigger()
    {

        
            playerr.GetComponent<PlayerSettings>().health--;
            Instantiate(hurtparticle, playerr.transform.position, Quaternion.identity);
            Destroy(gameObject);
        
    }
    
}
