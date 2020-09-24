using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RandomPieceCoordinates : MonoBehaviour
{
    public GameObject SpawningObject;

    public Tilemap ObjTilemap;

    [Range(0, 100)]
    public int maxPieceAmount;

    void Start()
    {
        var pieceAmount=0;
        for (pieceAmount=0; pieceAmount < maxPieceAmount; pieceAmount++)
        {
            SpawnObject();
        }
    }

    public void SpawnObject()
    {
        int randomX = Random.Range(-64, 64);
        int randomY = Random.Range(-64, 64);

        Vector3Int cellPosition = new Vector3Int(randomX, randomY, 0);
        //Vector3 position = new Vector3(randomX, randomY, 0);

        Vector3 position = ObjTilemap.CellToWorld(cellPosition);

        Instantiate(SpawningObject, position, Quaternion.identity);
        Debug.Log("Piece spawned at" + " " + position);
    }
}

/*
// Start is called before the first frame update
void Start()
{
    var pieceAmount = 0;
    int randomX = Random.Range(-64, 64);
    int randomY = Random.Range(-64, 64);
    Vector3 position = new Vector3(randomX, randomY, 0);

    function SpawnObject()
    {
        for (pieceAmount < maxPieceAmount; pieceAmount++)
    }

    Instantiate(SpawningObject, position, Quaternion.identity);
    Debug.Log("Piece spawned at" + " " + position);
}*/
