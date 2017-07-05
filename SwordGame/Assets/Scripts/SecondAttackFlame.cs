using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondAttackFlame : MonoBehaviour {
    Rigidbody2D rb;
    public GameObject playerr, hurtparticle, shield, shieldparticle, red, green, grey, blue;
    int selectedPlayer;
    float dirx;
    void Start()
    {
        dirx=Random.Range(-2,2);
        transform.Rotate(0, 0, 45f);
        rb = GetComponent<Rigidbody2D>();
        transform.Rotate(new Vector3(0, 0, -45));
        rb.AddForce(new Vector3(dirx,2,0) * 2f, ForceMode2D.Impulse);

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
    void Update()
    {

    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            playerr.GetComponent<PlayerSettings>().health--;
            Instantiate(hurtparticle, playerr.transform.position, Quaternion.identity);
            Destroy(gameObject);

        }
        if (collision.gameObject.tag == "toplimit")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "shield")
        {

            Instantiate(shieldparticle, playerr.transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(collision.gameObject);

        }
    }
}
