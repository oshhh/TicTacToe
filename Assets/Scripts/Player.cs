using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	int PlayerNo;
	FullGame Game;
	int Chance;
    // Start is called before the first frame update
    void Start()
    {
    	PlayerNo = gameObject.name[6] - '1';
        Game = GameObject.Find("Game").GetComponent<FullGame>();
        Chance = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(Game.Chance == PlayerNo) {
        	gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(PlayerNo == 0 ? "Player1Chance" : "Player2Chance");
        } else {
        	gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(PlayerNo == 0 ? "Player1" : "Player2");        	
        }
    }
}
