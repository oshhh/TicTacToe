using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Winner : MonoBehaviour
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
        } else {
        	gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Button");
        }
    }
}
