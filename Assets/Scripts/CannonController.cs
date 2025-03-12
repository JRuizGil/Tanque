using UnityEngine;

public class GyroController : MonoBehaviour
{
    public Camera cam; // Cámara principal
    public LayerMask layerMask; // Capas con las que colisionará el Raycast
    public Transform cannon; // Referencia al cañón (parte que rota en X)
    public float rotationSpeed = 10f; // Velocidad de rotación
    public float minAngle = -10f; // Ángulo mínimo de inclinación del cañón
    public float maxAngle = 30f; // Ángulo máximo de inclinación del cañón

    void Update()
    {
        ApuntarHaciaMouse();
    }

    private void ApuntarHaciaMouse()
    {
        // Lanza un Raycast desde la cámara hacia donde está el mouse
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            Vector3 targetPoint = hit.point; // Punto de impacto del Raycast

            // --- Rotación en Y (Gyro) ---
            Vector3 directionY = targetPoint - transform.position;
            directionY.y = 0; // Bloquear cambios en el eje Y para evitar inclinaciones raras
            if (directionY != Vector3.zero)
            {
                Quaternion targetRotationY = Quaternion.LookRotation(directionY);
                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotationY, Time.deltaTime * rotationSpeed);
            }

            // --- Rotación en X (Cannon) ---
            Vector3 directionX = targetPoint - cannon.position;
            float angleX = Vector3.SignedAngle(transform.forward, directionX, transform.right); // Ángulo respecto al eje X
            angleX = Mathf.Clamp(angleX, minAngle, maxAngle); // Limitar la rotación del cañón

            cannon.localRotation = Quaternion.Lerp(
                cannon.localRotation,
                Quaternion.Euler(angleX, 0, 0),
                Time.deltaTime * rotationSpeed
            );
        }
    }
}
