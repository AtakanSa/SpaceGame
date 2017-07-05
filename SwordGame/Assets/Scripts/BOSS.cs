using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BOSS : MonoBehaviour {

    public bool firstposition;
    public float dirX, dirY;
    public float time = 3,maxhealth=50,currenthealth;
    public GameObject rightlimit, leftlimit,buttonControl;
    public Slider healtbar;
    // Use this for initialization
    public GameObject bar;
    

    void Start () {
        if (GameObject.FindGameObjectWithTag("healtbar"))
        {
            healtbar = (Slider)FindObjectOfType(typeof(Slider));
        }
        //  buttonControl = GameObject.FindWithTag("ButtonControl");

        buttonControl = GameObject.FindGameObjectWithTag("ButtonControl");
        

        currenthealth = maxhealth;
        healtbar.value = CalculateHealth();
        
        firstposition = true;
        
       // healtbar.value = CalculateHealth();
    }
	
	// Update is called once per frame
	void Update () {
        FirstPosition();
        Movement();
        healtbar.value = CalculateHealth();
    }

    float CalculateHealth()
    {
        currenthealth -= Time.deltaTime;
        if (currenthealth <= 0)
        {
            if (buttonControl != null && currenthealth<=0)
            {
                buttonControl.GetComponent<ButtonControl>().nextLevelPanel.SetActive(true);
                buttonControl.GetComponent<ButtonControl>().inGamePanel.SetActive(false);
                Time.timeScale = 0;
            }
            
            
        }
        return currenthealth / maxhealth;
    }

    void Movement()
    {
        time -= Time.deltaTime;
        transform.Translate(new Vector3(dirX, 0, 0) * 1.7f * Time.deltaTime);
        if (time<0){

            random();
        }
        
    }
    void random()
    {
        dirX = Random.Range(-5f, 5f);
        time = 1.1f;
    }
    
    void FirstPosition()
    {
        if (transform.position.y<=-3.5f)
        {
            transform.Translate(Vector3.up * 1.5f * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bosleft")
        {
            
            transform.position = new Vector2(4.1f,transform.position.y);
        }
        if (collision.gameObject.tag == "bosright")
        {
            
            transform.position = new Vector2(-4.1f, transform.position.y);
        }

    }
    }
