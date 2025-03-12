using UnityEngine;

public class Objetivos : MonoBehaviour
{
    public Transform player; // Referencia al jugador
    public float velocidadRotacion = 5f; // Velocidad de seguimiento

    void Update()
    {
        if (player != null)
        {
            // Direcci�n hacia el jugador
            Vector3 direccion = player.position - transform.position;
            direccion.y = 0; // Opcional: Mantiene la rotaci�n solo en el eje Y

            if (direccion != Vector3.zero)
            {
                // Crear una rotaci�n hacia el jugador
                Quaternion rotacionObjetivo = Quaternion.LookRotation(direccion);
                // Aplicar rotaci�n suavemente
                transform.rotation = Quaternion.Lerp(transform.rotation, rotacionObjetivo, Time.deltaTime * velocidadRotacion);
            }
        }
    }
}

