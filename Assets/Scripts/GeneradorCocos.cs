using UnityEngine;
using UnityEngine.Tilemaps;

public class GeneradorPellets : MonoBehaviour
{
    public Tilemap tilemapPellets;   // Tilemap donde colocas los puntos
    public GameObject prefabPellet;  // Prefab del pellet

    void Start()
    {
        GenerarPellets();
    }

    void GenerarPellets()
    {
        foreach (Vector3Int celda in tilemapPellets.cellBounds.allPositionsWithin)
        {
            if (tilemapPellets.HasTile(celda))
            {
                Vector3 pos = tilemapPellets.GetCellCenterWorld(celda);
                Instantiate(prefabPellet, pos, Quaternion.identity);
            }
        }

        // Opcional: borrar el tilemap después de generar los pellets
        // tilemapPellets.ClearAllTiles();
    }
}