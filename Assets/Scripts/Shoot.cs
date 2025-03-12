using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject balaPrefab; // Prefab de la bala
    public Transform puntoDisparo; // Punto desde donde se dispara la bala
    public float fuerzaDisparo = 20f; // Velocidad inicial de la bala

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Disparar con clic izquierdo
        {
            Disparar();
        }
    }

    private void Disparar()
    {
        if (balaPrefab != null && puntoDisparo != null)
        {
            // Instanciar la bala en la misma posición y rotación del punto de disparo
            GameObject bala = Instantiate(balaPrefab, puntoDisparo.position, puntoDisparo.rotation);

            // Obtener el Rigidbody de la bala para aplicarle la fuerza
            Rigidbody rb = bala.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.useGravity = true; // Asegurar que la bala cae con gravedad
                rb.velocity = puntoDisparo.forward * fuerzaDisparo; // Aplicar fuerza en la dirección en la que apunta el objeto
            }
        }
    }
}
