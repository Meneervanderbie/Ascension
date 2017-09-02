using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoard : MonoBehaviour {

    public GameObject groundPrefab;
    public Vector2 worldSize;

    Tile[,] boardState;
    GameObject[,] board;

	public void SetupBoard () {
        // set up a grid with size equal to one unit per square and set up an n x n grid of tiles to populate the world
        // zero is set to current coordinates.
        board = new GameObject[(int)worldSize.x, (int)worldSize.y];
        boardState = new Tile[(int)worldSize.x,(int)worldSize.y];
        for(int i = 0; i < worldSize.x; i++) {
            for(int j = 0; j < worldSize.y; j++) {
                GameObject temp = Instantiate(groundPrefab, new Vector3(i, 0, j), Quaternion.identity, gameObject.transform);
                board[i, j] = temp;
                // later we need to set the characteristics of this tile.
                boardState[i, j] = board[i,j].GetComponent<Tile>();
            }
        }
	}

    public void PlaceEntity(Entity ent) {
        // Currently places unit at random
        int randomX = Random.Range(0, (int)worldSize.x);
        int randomY = Random.Range(0, (int)worldSize.y);
        ent.transform.position = new Vector3(randomX, 1, randomY);
        ent.tile = boardState[randomX, randomY];
    }
}
