using UnityEngine;
public class Pellet : MonoBehaviour
{
    public int valor = 10; // puntos que da este pellet

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("hola");
        // Solo reaccionamos si el que entra es Pac-Man
        if (other.CompareTag("Player"))
        {
            // Aquí podrías sumar puntos si tienes un GameManager
            // GameManager.Instance.SumarPuntos(valor);

            Destroy(gameObject); // El pellet desaparece
            
        }
    }
}