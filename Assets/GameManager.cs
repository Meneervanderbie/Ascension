using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameBoard gameBoard;
    public UIManager uiMan;
    public int AscendCost = 100;

    public int faith;

    public God player;
    public Elf temp1;
    public Elf temp2;
    public Elf temp3;

    // get list of 'elves' and put them on the board?

	// Use this for initialization
	void Start () {
        gameBoard.SetupBoard();
        gameBoard.PlaceEntity(player);
        gameBoard.PlaceEntity(temp1);
        gameBoard.PlaceEntity(temp2);
        gameBoard.PlaceEntity(temp3);
        Camera.main.GetComponent<CameraController>().CenterCamera();

        faith = 0;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void gainFaith(int toGain) {
        faith += toGain;
        uiMan.ChangeFaithValue(faith);
    }
}
