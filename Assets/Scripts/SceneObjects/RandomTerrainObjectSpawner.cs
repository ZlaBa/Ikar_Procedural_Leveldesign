using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RandomTerrainObjectSpawner : MonoBehaviour
{
    public GameObject[] RandomObject = new GameObject[4];

    public Tilemap ObjTilemap;

    bool triggerDetector = false;

    [Range(0, 100000)]
    public int maxPieceAmount;
    [Range(0, 10)]
    public float colRadSize;

    public LayerMask mask;

    public Collider2D[] colliders;

    public float overlapRad;

    void Start()
    {
        foreach (GameObject go in RandomObject)
        {
            go.GetComponent<CircleCollider2D>().radius = colRadSize;
        }

        SpawnObject();
    }

    public int SpawnObject()
    {
        int pieceAmount = 0;

        Vector3 position = new Vector3(0, 0, 0);
        Vector3Int cellPosition = new Vector3Int(0, 0, 0);
        
        
        if (!triggerDetector)//! = false
        {
            //while (pieceAmount < maxPieceAmount)
            for (pieceAmount = 0; pieceAmount < maxPieceAmount; pieceAmount++)
            {
                int randomX = Random.Range(-64, 64);
                int randomY = Random.Range(-64, 64);
                cellPosition = new Vector3Int(randomX, randomY, 0);
                position = ObjTilemap.CellToWorld(cellPosition);

                var randomInt = Random.Range(0, 4);

                bool restartChecker = false;
                triggerDetector = PreventSpawnOverlap(position);

                if (triggerDetector)//equals == true
                {
                    Debug.Log("Something is triggering" + " " + position);
                    //Restart();
                    restartChecker = true;
                    pieceAmount = pieceAmount-1;
                    continue;
                }
               
                if (restartChecker == false) { 
                    GameObject newObject = Instantiate(RandomObject[randomInt], position, Quaternion.identity) as GameObject;
                    newObject.name = "TerrainObject" + pieceAmount;
                    Debug.Log("TerrainObject: " + RandomObject[randomInt] + "spawned at: " + position);
                    //pieceAmount = pieceAmount + 1;
                }
            }
        }
        return pieceAmount;
    }

    void Restart()
    {
        SpawnObject();
    }

    bool PreventSpawnOverlap(Vector3 _position)
    {
        colliders = Physics2D.OverlapCircleAll(_position, overlapRad, mask);
        Debug.Log("Anzahl Collider: " + colliders.Length);
        for (int colCount = 0; colCount < colliders.Length; colCount++)
        {
            Vector3 centerPoint = colliders[colCount].bounds.center;
            float width = colliders[colCount].bounds.extents.x;
            float height = colliders[colCount].bounds.extents.y;

            float leftExtent = centerPoint.x - width;
            float rightExtent = centerPoint.x + width;
            float lowerExtent = centerPoint.y - height;
            float upperExtent = centerPoint.y + height;

            if (_position.x >= leftExtent && _position.x <= rightExtent)
            {
                if (_position.y >= lowerExtent && _position.y <= upperExtent)
                {
                    return false;
                } 
            }
            Debug.Log("Something is triggering at: " + _position + ". Collider Name: " + colliders[colCount].name + colliders[colCount].transform.position);
            return true;
        }
        return false;
    }
}

