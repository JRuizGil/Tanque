using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    public float velocidad = 10f;   // Velocidad de movimiento
    public float velocidadRotacion = 100f; // Velocidad de rotaci�n

    void Update()
    {
        Movimiento();
    }

    private void Movimiento()
    {
        float moveZ = 0f;
        float rotationY = 0f;

        // Movimiento adelante y atr�s
        if (Input.GetKey(KeyCode.W))
            moveZ = 1;
        if (Input.GetKey(KeyCode.S))
            moveZ = -1;

        // Rotaci�n izquierda y derecha
        if (Input.GetKey(KeyCode.A))
            rotationY = -1;
        if (Input.GetKey(KeyCode.D))
            rotationY = 1;

        // Aplicar movimiento y rotaci�n
        transform.Translate(Vector3.forward * moveZ * velocidad * Time.deltaTime);
        transform.Rotate(Vector3.up * rotationY * velocidadRotacion * Time.deltaTime);
    }
}
