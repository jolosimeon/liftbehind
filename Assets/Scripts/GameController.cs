using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //if wala na hp
		
        //aakyat
        if (GameStats.GoingUp) {
            GameStats.CurrFloor++;

            if (GameStats.CurrFloor == GameStats.Floors) {
                //game over na pag wala na floors
                //nasa taas ka na
            }

            else {

                //clean hallway
                GameObject[] gameObjectArray = GameObject.FindGameObjectsWithTag("Enemy");
                foreach (GameObject go in gameObjectArray) {
                    go.SetActive(false);
                }

                gameObjectArray = GameObject.FindGameObjectsWithTag("Survivor");
                foreach (GameObject go in gameObjectArray)
                {
                    go.SetActive(false);
                }

                System.Random rand = new System.Random();
                int nextLevel = rand.Next(0, 3);

                //spawn stuff
                switch (nextLevel)
                {
                    case 0: //spawn nothing
                        break;
                    case 1: //spawn zombeh
                        gameObjectArray = GameObject.FindGameObjectsWithTag("Enemy");
                        foreach (GameObject go in gameObjectArray)
                        {
                            go.SetActive(false);
                        }
                        break;
                    case 2: //spawn hooman
                        gameObjectArray = GameObject.FindGameObjectsWithTag("Survivor");
                        foreach (GameObject go in gameObjectArray)
                        {
                            go.SetActive(false);
                        }
                        break;
                    case 3: //spawn zommbeh and hooman
                        gameObjectArray = GameObject.FindGameObjectsWithTag("Enemy");
                        foreach (GameObject go in gameObjectArray)
                        {
                            go.SetActive(false);
                        }
                        break;
                        gameObjectArray = GameObject.FindGameObjectsWithTag("Survivor");
                        foreach (GameObject go in gameObjectArray)
                        {
                            go.SetActive(false);
                        }
                        break;
                    default: //lets party
                        break;
                }

            }
        }
	}
}
