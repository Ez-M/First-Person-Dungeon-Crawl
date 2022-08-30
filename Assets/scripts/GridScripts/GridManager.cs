using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int width, height;

    [SerializeField] private Tile tile;

    void Start() {
        GenerateGrid();
    }

    void GenerateGrid() {
        for (int x = 0; x < width; x++) {
            for (int z = 0; z < height; z++){
                Vector3 tileLoc = new Vector3 (0.5f, 0f, 0.5f) + new Vector3(x,0,z);
                var spawnedTile = Instantiate(tile, tileLoc, Quaternion.identity, this.gameObject.transform);
                spawnedTile.name = $"Tile {x} {z}";
            }
        }
    }

}
