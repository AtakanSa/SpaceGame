using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterMenu : MonoBehaviour {
    public Text textBlue,textRed,textGreen,textGrey;
    public int selectedPlayer;
    public GameObject goldgrey, goldblue, goldgreen;
    public int  prefGold, redControl, blueControl, greenControl, greyControl,defaultPlayer;
    // Use this for initialization
    void Start () {
        blueControl = PlayerPrefs.GetInt("blueControl", 0);
        greyControl = PlayerPrefs.GetInt("greyControl", 0);
        greenControl = PlayerPrefs.GetInt("greenControl", 0);
        prefGold = PlayerPrefs.GetInt("Gold", 0);
        defaultPlayer = PlayerPrefs.GetInt("Player", 0);

        if (blueControl == 1)
        {
            goldblue.SetActive(false);
            textBlue.text = "";
        }
        if (greenControl == 1)
        {
            goldgreen.SetActive(false);
            textGreen.text = "";
        }
        if (greyControl == 1)
        {
            goldgrey.SetActive(false);
            textGrey.text = "";
        }
        


        switch (defaultPlayer)
        {
            case 0:
                textRed.text = "Selected";
                textRed.color = Color.green;
                break;
            case 1:
                textGrey.text = "Selected";
                textGrey.color = Color.green;
                break;
            case 2:
                textGreen.text = "Selected";
                textGreen.color = Color.green;
                break;
            case 3:
                textBlue.text = "Selected";
                textBlue.color = Color.green;
                break;
        }



        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Buttons(int i)
    {
        switch (i)
        {
            case 4:

                PlayerPrefs.SetInt("Player", 0);//red

                textRed.text = "Selected";
                textRed.color = Color.green;
                if (blueControl == 1)
                {
                    textBlue.text = "";
                    goldblue.SetActive(false);
                }
                    
                if (greenControl == 1)
                {
                    textGreen.text = "";
                    goldgreen.SetActive(false);
                }
                if (greyControl == 1)
                {
                    textGrey.text = "";
                    goldgrey.SetActive(false);
                }


                break;
            case 5:
                if (prefGold >= 50 || greyControl == 1)
                {
                    PlayerPrefs.SetInt("Player", 1);//grey
                    textGrey.text = "Selected";
                    textGrey.color = Color.green;
                    if (blueControl == 1)
                    {
                        textBlue.text = "";
                        goldblue.SetActive(false);
                    }
                    if (greenControl == 1)
                    {
                        textGreen.text = "";
                        goldgreen.SetActive(false);
                    }
                    textRed.text = "";
                    if (greyControl == 0)
                    {
                        prefGold -= 50;
                        goldgrey.SetActive(false);
                        PlayerPrefs.SetInt("Gold", prefGold);
                        prefGold = PlayerPrefs.GetInt("Gold", 0);
                        PlayerPrefs.SetInt("greyControl", 1);
                    }
                }
                break;
            case 6:
                if (prefGold >= 50 || greenControl == 1)
                {
                    PlayerPrefs.SetInt("Player", 2);//green
                    textGreen.text = "Selected";
                    textGreen.color = Color.green;
                    if (blueControl == 1)
                    {
                        textBlue.text = "";
                        goldblue.SetActive(false);
                    }
                    textRed.text = "";
                    if (greyControl == 1)
                    {
                        textGrey.text = "";
                        goldgrey.SetActive(false);
                    }
                    if (greenControl == 0)
                    {
                        prefGold -= 50;
                        goldgreen.SetActive(false);
                        PlayerPrefs.SetInt("Gold", prefGold);
                        prefGold = PlayerPrefs.GetInt("Gold", 0);
                        PlayerPrefs.SetInt("greenControl", 1);
                    }
                }
                break;
            case 7:
                if (prefGold >= 50 || blueControl == 1)
                {
                    PlayerPrefs.SetInt("Player", 3);//blue
                    textBlue.text = "Selected";
                    textBlue.color = Color.green;
                    textRed.text = "";
                    if (greenControl == 1)
                    {
                        textGreen.text = "";
                        goldgreen.SetActive(false);
                    }
                    if (greyControl == 1)
                    {
                        textGrey.text = "";
                        goldgrey.SetActive(false);
                    }
                    if (blueControl == 0)
                    {
                        goldblue.SetActive(false);
                        prefGold -= 50;
                        PlayerPrefs.SetInt("Gold", prefGold);
                        prefGold = PlayerPrefs.GetInt("Gold", 0);
                        PlayerPrefs.SetInt("blueControl", 1);
                    }
                }
                break;
            case 8:
                SceneManager.LoadScene("1");
                break;
        }
    }
}
