using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public float timeDegrade = 5.0f;
    float timeLeft;

    GameObject[] zombies;
    GameObject[] survivors;
    GameObject[] activeObjects;

    public Image healthBar;

    public double MIN_ZOMBIE_X = -3.5;
    public double MIN_ZOMBIE_Z = -13.1;
    public double MAX_ZOMBIE_X = -0.8;
    public double MAX_ZOMBIE_Z = -8.4;
    public double ZOMBIE_Y = -1.9;

    public double MIN_SURV_X = -3.1;
    public double MIN_SURV_Z = -7.2;
    public double MAX_SURV_X = -1.0;
    public double MAX_SURV_Z = -5.9;
    public double SURV_Y = -0.7;

    // Use this for initialization
    void Start () {
        zombies = GameObject.FindGameObjectsWithTag("Enemy");
        survivors = GameObject.FindGameObjectsWithTag("Survivor");

        GameStats.Hp = GameStats.MaxHp;
        timeLeft = timeDegrade;

        clearFloor();
        spawnNPCs();
    }
	
	// Update is called once per frame
	void Update () {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            takeDamage(10);
            timeLeft = timeDegrade;
        }

        //if wala na hp
		
        //aakyat
        if (GameStats.GoingUp) {
            GameStats.CurrFloor++;

            if (GameStats.CurrFloor == GameStats.Floors) {
                //game over na pag wala na floors
                //nasa taas ka na
            }

            else {

                clearFloor();
                spawnNPCs();
               
                GameStats.GoingUp = false;
            }
        }
	}

    public void takeDamage (float dmg)
    {
        GameStats.Hp -= dmg;

        healthBar.fillAmount = GameStats.Hp / GameStats.MaxHp;
    }

    public void spawn(GameObject obj)
    {
        double x = 0, y = 0, z = 0;
        if (obj.CompareTag("Enemy"))
        {
            Debug.Log("Yo zombie");
            x = GetRandomNumber(MIN_ZOMBIE_X, MAX_ZOMBIE_X);
            y = ZOMBIE_Y;
            z = GetRandomNumber(MIN_ZOMBIE_Z, MAX_ZOMBIE_Z);
        }
        else if (obj.CompareTag("Survivor"))
        {
            Debug.Log("Survivor po");
            x = GetRandomNumber(MIN_SURV_X, MAX_SURV_X);
            y = SURV_Y;
            z = GetRandomNumber(MIN_SURV_Z, MAX_SURV_Z);
        }

        Vector3 pos = new Vector3((float) x, (float) y, (float) z);

        //while (Physics.CheckSphere(pos, 5))
        //{
        // pos = new Vector3((float)x, (float)ZOMBIE_Y, (float)z);
        //}
        Debug.Log(pos.ToString());
        obj.transform.position = pos;
        Debug.Log(obj.transform.position);
        Vector3 euler = obj.transform.eulerAngles;
        euler.y = Random.Range(0f, 360f);
        obj.transform.eulerAngles = euler;

        obj.SetActive(true);
        
    }

    public void clearFloor()
    {
        //clean hallway

        foreach (GameObject go in zombies)
        {
            go.SetActive(false);
        }

        foreach (GameObject go in survivors)
        {
            go.SetActive(false);
        }
    }

    public void spawnNPCs()
    {
        System.Random rand = new System.Random();
        int nextLevel = rand.Next(0, 3);
        Debug.Log("SPAWN!!!!!!!");
        //spawn stuff
        switch (nextLevel)
        {
            case 0: //spawn nothing
                break;
            case 1: //spawn zombeh
                foreach (GameObject go in zombies)
                {
                    spawn(go);
                }
                break;
            case 2: //spawn hooman
                foreach (GameObject go in survivors)
                {
                    spawn(go);
                }
                break;
            case 3: //spawn zommbeh and hooman
                foreach (GameObject go in zombies)
                {
                    spawn(go);
                }
                foreach (GameObject go in survivors)
                {
                    spawn(go);
                }
                break;
            default: //lets party
                break;
        }
    }

    public double GetRandomNumber(double minimum, double maximum)
    {
        System.Random random = new System.Random();
        return random.NextDouble() * (maximum - minimum) + minimum;
    }
}
