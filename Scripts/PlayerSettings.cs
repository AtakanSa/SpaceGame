using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSettings : MonoBehaviour {
    private float screenCenterX;
    Animator anim;
    public Image heart1, heart2, heart3;
    public Text goldCount;
    public GameObject  rightlimit, leftlimit,btncontrol;
    Rigidbody2D body;
    public float ttime;
    public int health = 3,goldcount;
    
    
    public bool sag, sol, start;
    
    // Use this for initialization
    void Start() {

        PlayerPrefs.SetInt("Gold", 8888);//////////////////////////////////



        screenCenterX = Screen.width * 0.5f;
        anim = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        sag = false;
        sol = false;
        
        goldcount = PlayerPrefs.GetInt("Gold", 0);


    }
    

    // Update is called once per frame
    void Update() {
        
        if (start)
        {
            ttime += Time.deltaTime;
            SetAnimator();
            Movement();
            setHealth();
            setText();
        }
    }


    void SetAnimator()
    {
        if (sag)
        {
            anim.SetBool("sag", true);
            anim.SetBool("sol", false);
        }
        else if (sol)
        {
            anim.SetBool("sag", false);
            anim.SetBool("sol", true);
        }
        else
        {
            anim.SetBool("sag", false);
            anim.SetBool("sol", false);
        }
    }

    void setText()
    {
        
        goldCount.text = goldcount.ToString();
    }

    void Movement()
    {

        if (Input.touchCount > 0)
        {

            // get the first one
            Touch firstTouch = Input.GetTouch(0);

            // if it began this frame
            if (firstTouch.phase == TouchPhase.Began || firstTouch.phase == TouchPhase.Stationary)
            {
                if (firstTouch.position.x > screenCenterX)
                {
                    transform.Translate(Vector3.right * 7 * Time.deltaTime);
                    sag = true;
                }
                else if (firstTouch.position.x < screenCenterX)
                {
                    transform.Translate(Vector3.left * 7 * Time.deltaTime);

                    sol = true;
                }
                

        }

        else if (firstTouch.phase == TouchPhase.Ended || firstTouch.phase == TouchPhase.Moved)
            {
                sag = false;
                sol = false;
            }


        }
    }

    void setHealth()
    {
        switch (health)
        {
            case 3:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(true);
                break;
            case 2:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(false);
                break;
            case 1:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                break;
            case 0:
                btncontrol.GetComponent<ButtonControl>().over = true;
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "leftlimit")
            {
                transform.position = new Vector2(rightlimit.transform.position.x - 1f, rightlimit.transform.position.y);
            }
            if (collision.gameObject.tag == "rightlimit")
            {
                transform.position = new Vector2(leftlimit.transform.position.x + 1f, leftlimit.transform.position.y);
            }
        if (collision.gameObject.tag == "gold")
        {
            goldcount++;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "heart")
        {
            if (health <=2)
            {
                health++;
            }
            
            Destroy(collision.gameObject);
        }
    }
    
}
