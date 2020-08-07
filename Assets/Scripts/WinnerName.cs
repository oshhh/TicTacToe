using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinnerName : MonoBehaviour
{
	FullGame Game;
    // Start is called before the first frame update
    void Start()
    {
        Game = GameObject.Find("Game").GetComponent<FullGame>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Game.Game == 0) {
        	gameObject.GetComponent<SpriteRenderer>().sprite = null;
        } else if(Game.Game == 1) {
        	gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Player1Winner");
        }
 		else if(Game.Game == 2) {
        	gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Player2Winner");
        }
 		else if(Game.Game == 3) {
        	gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Tie");
        }
    }
}
