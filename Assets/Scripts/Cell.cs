using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
	FullGame FullGame;
	ParentGame ParentGame;
	public int CellNo;

    void Start()
    {
    	FullGame = GameObject.Find("Game").GetComponent<FullGame>();
    	ParentGame = GameObject.Find(gameObject.name.Substring(0,1)).GetComponent<ParentGame>();
    	CellNo = gameObject.name[2] - '1';
    }

	void OnMouseDown(){
		Debug.Log("clicked");
	    if(FullGame.PrevCell == CellNo || FullGame.CellGame[ParentGame.CellNo, CellNo] != 0) {
	    	return;
	    }
	    FullGame.CellGame[ParentGame.CellNo, CellNo] = FullGame.Chance + 1;
	    if(FullGame.Chance == 0) {
	    	Debug.Log("adding");
	    	gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load <Sprite>("cross"); 
	    } else {
	    	Debug.Log("adding");
	    	gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load <Sprite>("circle"); 
	    }
		FullGame.Chance = 1 - FullGame.Chance;
		FullGame.PrevCell = CellNo;	    
	}
}
