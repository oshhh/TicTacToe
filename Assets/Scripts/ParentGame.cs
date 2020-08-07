using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentGame : MonoBehaviour
{
    FullGame Game;
	public int CellNo;
    // Start is called before the first frame update
    void Start()
    {
        Game = GameObject.Find("Game").GetComponent<FullGame>();
        CellNo = gameObject.name[0] - '1';
    }

    // Update is called once per frame
    void Update()
    {
        if(Game.ParentCellGame[CellNo] != 0) return;

        for(int i = 0; i < 3; ++ i) {
            if(Game.CellGame[CellNo, i * 3 + 0] != 0 && Game.CellGame[CellNo, i * 3 + 0] == Game.CellGame[CellNo, i * 3 + 1] && Game.CellGame[CellNo, i * 3 + 1] == Game.CellGame[CellNo, i * 3 + 2]) {
                Finish(Game.CellGame[CellNo, i * 3]);
            } else if(Game.CellGame[CellNo, 0 * 3 + i] != 0 && Game.CellGame[CellNo, 0 * 3 + i] == Game.CellGame[CellNo, 1 * 3 + i] && Game.CellGame[CellNo, 1 * 3 + i] == Game.CellGame[CellNo, 2 * 3 + i]) {
                Finish(Game.CellGame[CellNo, i]);
            }
        }

        if(Game.ParentCellGame[CellNo] != 0) return;

        if(Game.CellGame[CellNo, 0] != 0 && Game.CellGame[CellNo, 0] == Game.CellGame[CellNo, 4] && Game.CellGame[CellNo, 4] == Game.CellGame[CellNo, 8]) {
            Finish(Game.CellGame[CellNo, 0]);
        } else if(Game.CellGame[CellNo, 2] != 0 && Game.CellGame[CellNo, 2] == Game.CellGame[CellNo, 4] && Game.CellGame[CellNo, 4] == Game.CellGame[CellNo, 6]) {
            Finish(Game.CellGame[CellNo, 2]);
        } 

        if(Game.ParentCellGame[CellNo] != 0) return;

        bool full = true;
        for(int i = 0; i < 9; ++ i) {
            if(Game.CellGame[CellNo, i] == 0) full = false;
        }
        if(full) {
            Game.ParentCellGame[CellNo] = 3;
        }

    }

    void Finish(int Player) {
        Game.ParentCellGame[CellNo] = Player;
        for(int j = 0; j < 9; ++ j) {
            Debug.Log((CellNo + 1).ToString() + "." + (j + 1).ToString());
            Destroy(GameObject.Find((CellNo + 1).ToString() + "." + (j + 1).ToString()));
        }
        gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(Game.ParentCellGame[CellNo] == 1 ? "cross" : "circle");
    }
}
