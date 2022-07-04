using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PrefabSpawningTile : Tile
{
    public int Units;
    public GameObject[] GameObject = new GameObject[3];
    public int[] UnitMinimum = new int[3];

    public int UnitGenerationMinimum;
    public int UnitGenerationMaximum;

    public override void GetTileData(Vector3Int location, ITilemap tilemap, ref TileData tileData)
    {
        for( int i=GameObject.Length - 1; i >= 0; i--)
        {
            if( Units >= UnitMinimum[i])
            {
                tileData.gameObject = GameObject[i];
                return;
            }
        }
    }

#if UNITY_EDITOR
    // The following is a helper that adds a menu item to create a RoadTile Asset
    [MenuItem("Assets/Create/Tiles/Prefab Spawning Tile")]
    public static void CreatePrefabSpawningTile()
    {
        string path = EditorUtility.SaveFilePanelInProject("Save Prefab Spawning Tile", "New Prefab Spawning Tile", "Asset", "Save Prefab Spawning Tile", "Assets");
        if (path == "")
            return;
        AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<PrefabSpawningTile>(), path);
    }
#endif
}
