using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullGame : MonoBehaviour
{
	public int Chance;
	public int PrevCell;
	public int[,] CellGame;
	public int[] ParentCellGame;
	public int Game;
    // Start is called before the first frame update
    void Start()
    {
    	CellGame = new int[9, 9];
    	ParentCellGame = new int[9];
    	Chance = 0;
    	PrevCell = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if(Game != 0) return;

        for(int i = 0; i < 3; ++ i) {
            if(ParentCellGame[i * 3 + 0] != 0 && ParentCellGame[i * 3 + 0] == ParentCellGame[i * 3 + 1] && ParentCellGame[i * 3 + 1] == ParentCellGame[i * 3 + 2]) {
                Finish(ParentCellGame[i * 3]);
            } else if(ParentCellGame[0 * 3 + i] != 0 && ParentCellGame[0 * 3 + i] == ParentCellGame[1 * 3 + i] && ParentCellGame[1 * 3 + i] == ParentCellGame[2 * 3 + i]) {
                Finish(ParentCellGame[i]);
            } 
        }

        if(Game != 0) return;

        if(ParentCellGame[0] != 0 && ParentCellGame[0] == ParentCellGame[4] && ParentCellGame[4] == ParentCellGame[8]) {
            Finish(ParentCellGame[0]);
        } else if(ParentCellGame[2] != 0 && ParentCellGame[2] == ParentCellGame[4] && ParentCellGame[4] == ParentCellGame[6]) {
			Finish(ParentCellGame[0]);
        }

        if(Game != 0) return;

        bool full = true;
        for(int i = 0; i < 9; ++ i) {
        	if(ParentCellGame[i] == 0) full = false;
        }

        if(full) {
        	Game = 3;
        }

    }

    void Finish(int Player) {
         Game = Player;
        for(int j = 0; j < 9; ++ j) {
            Destroy(GameObject.Find((j + 1).ToString()));
        }
        gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(Game == 1 ? "cross" : "circle");                   	
    }
}
