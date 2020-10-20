using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SpawnerScript2 : MonoBehaviour
{
    Rigidbody2D rb2D;

    public Grid grid;
    public Tilemap IsoGroundMap;
    //public Transform spawnPos;
    public GameObject Player;
    private GameData _gameData;
    /*
    public void setBool()
        {
        playerSpawned = true;
        }
        */
    void Update()
    {
        bool gameActive = true;
        bool playerSpawned = false;
        if (gameActive == true)
        {
            if (playerSpawned == false)/*(Input.GetKeyDown(KeyCode.Keypad1))*/
            {
                Debug.Log("Gstartet");
                _gameData = GameObject.FindWithTag("GameData").GetComponent<GameData>();
                Debug.Log(_gameData.GetWidth());

                IsoGroundMap.CompressBounds();

                for (int x = 0; x < _gameData.GetWidth(); x++)
                {

                    for (int y = 0; y < _gameData.GetHeight(); y++)
                    {
                        var feld = _gameData.GetFeld(x, y);
                        Debug.Log(_gameData.GetFeld(x, y));
                        if (feld.Terrain == FeldTerrain.Wiese)
                        {
                            Player.layer = 6;
                            Instantiate(Player, IsoGroundMap.GetCellCenterWorld(new Vector3Int(x, y, 0)), Quaternion.identity);
                            Debug.Log("Player was spawned at X: " + (IsoGroundMap.GetCellCenterWorld(new Vector3Int(x, y, 0)).x) + " Y: " + (IsoGroundMap.GetCellCenterWorld(new Vector3Int(x, y, 0)).y) + "Q: " + (Quaternion.identity) + "!");
                            //playerActive = true;
                            return;
                           
                        }
                    }
                }
            }
        }
        playerSpawned = true;
    }
}


