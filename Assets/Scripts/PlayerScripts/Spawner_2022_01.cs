using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Spawner_2022_01 : MonoBehaviour
{
    //Player Spawn Data START
    public GameObject SpawningObject;
    public Tilemap ObjTilemap;
    public int maxPlayerAmount = 1;
    //Player Spawn Data END

    void Start()
    {
        //Player Spawn void Start() START
        var playerAmount = 0;
        for (playerAmount = 0; playerAmount < maxPlayerAmount; playerAmount++)
        {
            SpawnPlayer();
        }
        //Player Spawn void Start() END
    }

    //Player Spawn Function START
    public void SpawnPlayer()
    {
        int randomX = Random.Range(-64/4, 64/4);
        int randomY = Random.Range(-64/4, 64/4);

        Vector3Int cellPosition = new Vector3Int(randomX, randomY, 0);

        Vector3 position = ObjTilemap.CellToWorld(cellPosition);

        Instantiate(SpawningObject, position, Quaternion.identity);
        //Debug.Log("Piece spawned at" + " " + position);
    }
    //Player Spawn Function END
}
