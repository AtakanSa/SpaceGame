using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawn : MonoBehaviour {
    float dirX,lifeX,goldX;
    float dirY;
    public GameObject Sword, Playerr, shield, life, gold, bosss, 
        flame, bos, secondattack, destroyboss,flamee,star;

    public float SpawnTime=1,lifeSpawnTime,goldSpawnTime,FlameSpawnTime=2,secondattacktime=2,stary;
    public float currentlevel;
    public bool level1, level2, level3, level4, level5, level6,start,boss,bosscreated;
    public float leveltime = 15,spawnstartime;
    public int flamecount = 0,secondattackcount=0;
    public Slider healtbar;
    

    // Use this for initialization
    void Start () {
        stary = Random.Range(-6, 1);
        spawnstartime = Random.Range(2, 6);
        healtbar.gameObject.SetActive(false);
        level1 = true;
        start = false;
        currentlevel = 1;
        bosscreated = true;
        lifeSpawnTime = Random.Range(5, 16);
        goldSpawnTime = Random.Range(4, 10);
        
    }
	
	// Update is called once per frame
	void Update () {
        if (start)
        {
            
            Spawn();
            SpawnStar();
            spawnLife();
            spawnGold();
        }
        if (boss || start)
        {
            SetLevel();
        }
        if (bosscreated == false)
        {
            SpawnFlame();
        }
        
    }

   
    void Spawn()
    {
        SpawnTime -= Time.deltaTime;
        if (SpawnTime <= 0)
        {
            dirX = Random.Range(-3.1f, 3.1f);
            Instantiate(Sword, new Vector2(dirX,-6), Quaternion.identity);
            SpawnTime = currentlevel;
        }
        
    }
    public void shieldSpawn()
    {
        Instantiate(shield, Playerr.transform.position, Quaternion.identity);
    }
    void spawnGold()
    {
        goldSpawnTime -= Time.deltaTime;
        if (goldSpawnTime <= 0)
        {
            goldX = Random.Range(-3, 3);
            Instantiate(gold, new Vector2(goldX, Playerr.transform.position.y), Quaternion.identity);
            goldSpawnTime = Random.Range(4, 10);
        }
    }
    void SpawnStar()
    {
        
        spawnstartime -= Time.deltaTime;
        if (spawnstartime <= 0)
        {

            Instantiate(star, new Vector2(Playerr.transform.position.x+3, Playerr.transform.position.y+ stary), Quaternion.identity);
            spawnstartime = Random.Range(3, 8);
            stary = Random.Range(-6, 1);
        }
    }
    void spawnLife()
    {

        lifeSpawnTime -= Time.deltaTime;
        if (lifeSpawnTime <= 0)
        {
            lifeX = Random.Range(-3, 3);
            Instantiate(life, new Vector2(lifeX, Playerr.transform.position.y), Quaternion.identity);
            lifeSpawnTime = Random.Range(5, 16);
        }
    }

    void SpawnFlame()
    {
        FlameSpawnTime -= Time.deltaTime;
        if (FlameSpawnTime <= 0 && flamecount<15)
        {
           
            Instantiate(flame, new Vector2(bosss.transform.position.x, bosss.transform.position.y+1), Quaternion.identity);
            FlameSpawnTime = 0.5f;
            flamecount++;
        }
        if (flamecount >= 15)
        {
            
            SpawnSecondAttack();
            
        }
    }

    void SpawnSecondAttack()
    {
        secondattacktime -= Time.deltaTime;
        if (secondattackcount < 3 && secondattacktime<=0)
        {
            Instantiate(flamee, new Vector2(bosss.transform.position.x, bosss.transform.position.y + 2.3f), Quaternion.identity);
            Instantiate(flamee, new Vector2(bosss.transform.position.x, bosss.transform.position.y + 2.3f), Quaternion.identity);
            Instantiate(flamee, new Vector2(bosss.transform.position.x, bosss.transform.position.y + 2.3f), Quaternion.identity);
            Instantiate(flamee, new Vector2(bosss.transform.position.x, bosss.transform.position.y + 2.3f), Quaternion.identity);
           
            secondattacktime = 2;
            secondattackcount++;
        }
        if(secondattackcount>=3)
        {
            secondattackcount = 0;
            flamecount = 0;
        }
    }




    void SetLevel()
    {
        leveltime -= Time.deltaTime;
        if (leveltime <= 0)
        {
            if (level1)
            {
                level1 = false;
                level2 = true;
                leveltime = 10;
                currentlevel = 1;
            }
            else if (level2)
            {
                level2 = false;
                level3 = true;
                leveltime = 10;
                currentlevel = 0.8f;
            }
            else if (level3)
            {
                level3 = false;
                level4 = true;
                leveltime = 15;
                currentlevel = 0.5f;
            }
            else if (level4)
            {
                level4 = false;
                level5 = true;
                leveltime = 15;
                currentlevel = 0.3f;
            }
            else if (level5)
            {
                leveltime = 11;
                currentlevel = 0.15f;
                level5 = false;
                boss = true;

            }
            else if (boss)
            {
                start = false;
                if (bosscreated)
                {
                    healtbar.gameObject.SetActive(true);
                    
                    Instantiate(bos, new Vector2(0, -9), Quaternion.identity);
                    bos.GetComponent<BOSS>().currenthealth = 50;
                    
                    
                    bosscreated = false;
                    bosss = GameObject.FindGameObjectWithTag("boss");
                }
                
                
            }
        }
    }


}
