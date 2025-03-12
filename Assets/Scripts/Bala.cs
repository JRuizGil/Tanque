using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float tiempoVida = 5f; // Tiempo antes de que la bala se destruya automáticamente
    private Contador contador; // Referencia al script Contador

    void Start()
    {
        // Buscar el objeto con el script Contador en la escena (asegurarse que solo hay uno)
        contador = FindObjectOfType<Contador>();

        Destroy(gameObject, tiempoVida); // Destruir la bala después de un tiempo si no impacta nada
    }

    void OnCollisionEnter(Collision collision)
    {
        // Si la bala impacta contra un objeto con el tag "Objetivo"
        if (collision.gameObject.CompareTag("Objetivo"))
        {
            // Destruir el objetivo
            Destroy(collision.gameObject);

            // Llamar al método que incrementa el contador
            if (contador != null)
            {
                contador.SumarContador(); // Llamar la función que suma al contador
            }

            // Destruir la bala
            Destroy(gameObject);
        }
        else
        {
            // Destruir la bala al impactar con cualquier otra cosa
            Destroy(gameObject);
        }
    }
}

