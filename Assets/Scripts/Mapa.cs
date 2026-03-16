using UnityEngine;
using UnityEngine.Tilemaps;

public class Mapa : MonoBehaviour
{
    // Referencia al Tilemap que contiene las paredes
    public Tilemap tilemap;

    // Matriz lógica donde guardaremos si una celda es pared (true) o camino (false)
    public bool[,] mapa;

    private int ancho;
    private int alto;
    private BoundsInt bounds;

    void Awake()
    {
        // Al iniciar el juego, leemos el Tilemap y generamos la matriz
        LeerMapa();
    }

    void LeerMapa()
    {
        // Obtenemos los límites del Tilemap
        bounds = tilemap.cellBounds;

        // Calculamos el tamaño del mapa
        ancho = bounds.size.x;
        alto = bounds.size.y;

        // Creamos la matriz del tamaño del mapa
        mapa = new bool[ancho, alto];

        // Recorremos todas las celdas del Tilemap
        for (int x = 0; x < ancho; x++)
        {
            for (int y = 0; y < alto; y++)
            {
                // Convertimos coordenadas locales a coordenadas del Tilemap
                Vector3Int pos = new Vector3Int(bounds.xMin + x, bounds.yMin + y, 0);

                // Si hay un tile → es pared
                mapa[x, y] = tilemap.GetTile(pos) != null;
            }
        }
    }

    // Función pública para saber si una celda es pared
    public bool EsPared(Vector3Int celda)
    {
        // Convertimos coordenadas del mundo a índices de la matriz
        int x = celda.x - bounds.xMin;
        int y = celda.y - bounds.yMin;

        // Si está fuera del mapa, lo consideramos pared
        if (x < 0 || y < 0 || x >= ancho || y >= alto)
            return true;

        // Devolvemos si es pared o no
        return mapa[x, y];
    }
}