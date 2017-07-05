using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonControl : MonoBehaviour
{
    Button StartGame;
    public GameObject startPanel, inGamePanel, playerr, Spawn, GameOverPanel, red, grey, green, blue,pausePanel,nextLevelPanel,background,bg2,backupbg;
    public int gold, score, highscore, selectedPlayer;
    public Text ScoreText, goldText, HighscoreText;
    public bool over;
    bool isPaused = false;
    // Use this for initialization
    void Start()
    {
        nextLevelPanel.SetActive(false);
        pausePanel.SetActive(false);
        inGamePanel.SetActive(false);
        GameOverPanel.SetActive(false);
        over = false;
        highscore = PlayerPrefs.GetInt("Highscore", 0);



    }

    // Update is called once per frame
    void Update()
    {
        if (playerr != null)
        {
            Continue();
            gold = playerr.GetComponent<PlayerSettings>().goldcount;
            score = (Int32)playerr.GetComponent<PlayerSettings>().ttime;
            if (over)
            {
                playerr.GetComponent<PlayerSettings>().start = false;
                Spawn.GetComponent<EnemySpawn>().start = false;
                GameOverPanel.SetActive(true);
                inGamePanel.SetActive(false);
                ScoreText.text = score.ToString();
                goldText.text = gold.ToString();
                Time.timeScale = 0;
                PlayerPrefs.SetInt("Gold", gold);

                if (score > highscore)
                {
                    PlayerPrefs.SetInt("Highscore", score);
                    highscore = score;

                }
                HighscoreText.text = highscore.ToString();
            }
        }

    }


    public void Buttons(int i)
    {
        switch (i)
        {
            case 0:
                selectedPlayer = PlayerPrefs.GetInt("Player", 0);

                switch (selectedPlayer)
                {
                    case 0:
                        print("asd");
                        red.transform.position = new Vector3(0, 2.85f, 0);
                        green.transform.position = new Vector3(8, -8, 0);
                        grey.transform.position = new Vector3(8, -8, 0);
                        blue.transform.position = new Vector3(8, -8, 0);
                        green.gameObject.tag = "EditorOnly";
                        grey.gameObject.tag = "EditorOnly";
                        blue.gameObject.tag = "EditorOnly";

                        playerr = red;
                        break;
                    case 1:
                        grey.transform.position = new Vector3(0, 2.85f, 0);
                        green.transform.position = new Vector3(8, -8, 0);
                        red.transform.position = new Vector3(8, -8, 0);
                        blue.transform.position = new Vector3(8, -8, 0);
                        green.gameObject.tag = "EditorOnly";
                        red.gameObject.tag = "EditorOnly";
                        blue.gameObject.tag = "EditorOnly";


                        playerr = grey;
                        break;
                    case 2:
                        green.transform.position = new Vector3(0, 2.85f, 0);
                        red.transform.position = new Vector3(8, -8, 0);
                        grey.transform.position = new Vector3(8, -8, 0);
                        blue.transform.position = new Vector3(8, -8, 0);
                        red.gameObject.tag = "EditorOnly";
                        grey.gameObject.tag = "EditorOnly";
                        blue.gameObject.tag = "EditorOnly";

                        playerr = green;
                        break;
                    case 3:
                        blue.transform.position = new Vector3(0, 2.85f, 0);
                        green.transform.position = new Vector3(8, -8, 0);
                        grey.transform.position = new Vector3(8, -8, 0);
                        red.transform.position = new Vector3(8, -8, 0);
                        green.gameObject.tag = "EditorOnly";
                        grey.gameObject.tag = "EditorOnly";
                        red.gameObject.tag = "EditorOnly";

                        playerr = blue;
                        break;
                }
                StartCoroutine(ScaleOverTime(1));
                //backupbg.SetActive(false);
                bg2.GetComponent<Background>().start = true;
                background.GetComponent<Background>().start = true;
                Spawn.GetComponent<EnemySpawn>().Playerr = playerr;
                startPanel.SetActive(false);
                inGamePanel.SetActive(true);
                playerr.GetComponent<PlayerSettings>().ttime = 0;
                playerr.GetComponent<PlayerSettings>().start = true;
                Spawn.GetComponent<EnemySpawn>().start = true;

                Time.timeScale = 1;

                break;
            case 1:
                if (gold >= 15)
                {
                    Spawn.GetComponent<EnemySpawn>().shieldSpawn();
                    playerr.GetComponent<PlayerSettings>().goldcount -= 15;
                }
                else
                {
                    //wrong sound
                }
                break;
            case 3:
                SceneManager.LoadScene("1");
                break;
            case 4:
                Time.timeScale = 1;
                SceneManager.LoadScene("charactermenu");
                break;
            case 5:
                OnApplicationPause(true);
                
                break;

        }

    }
   
   

void Pause()
    {
        if (isPaused)
        {
            Time.timeScale = 0;
        }
    }
 

    void Continue()
    {
        if (Input.GetMouseButtonDown(0) && isPaused)
        {
            pausePanel.SetActive(false);
            isPaused = false;
            Time.timeScale = 1;
        }
    }
   
    private void OnApplicationPause(bool pause)
    {

        {
            isPaused = true;
            pausePanel.SetActive(true);
            Pause();
        }
    }
    IEnumerator ScaleOverTime(float time)
    {
        Vector3 originalScale = backupbg.transform.localScale;
        Vector3 destinationScale = new Vector3(0f, 0f, 0f);

        float currentTime = 0.0f;

        do
        {
            backupbg.transform.localScale = Vector3.Lerp(originalScale, destinationScale, currentTime / time);
            currentTime += Time.deltaTime;
            yield return null;
        } while (currentTime <= time);

        Destroy(backupbg);
    }
}
