using UnityEngine;

public class GyroController : MonoBehaviour
{
    public Camera cam; // C�mara principal
    public LayerMask layerMask; // Capas con las que colisionar� el Raycast
    public Transform cannon; // Referencia al ca��n (parte que rota en X)
    public float rotationSpeed = 10f; // Velocidad de rotaci�n
    public float minAngle = -10f; // �ngulo m�nimo de inclinaci�n del ca��n
    public float maxAngle = 30f; // �ngulo m�ximo de inclinaci�n del ca��n

    void Update()
    {
        ApuntarHaciaMouse();
    }

    private void ApuntarHaciaMouse()
    {
        // Lanza un Raycast desde la c�mara hacia donde est� el mouse
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            Vector3 targetPoint = hit.point; // Punto de impacto del Raycast

            // --- Rotaci�n en Y (Gyro) ---
            Vector3 directionY = targetPoint - transform.position;
            directionY.y = 0; // Bloquear cambios en el eje Y para evitar inclinaciones raras
            if (directionY != Vector3.zero)
            {
                Quaternion targetRotationY = Quaternion.LookRotation(directionY);
                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotationY, Time.deltaTime * rotationSpeed);
            }

            // --- Rotaci�n en X (Cannon) ---
            Vector3 directionX = targetPoint - cannon.position;
            float angleX = Vector3.SignedAngle(transform.forward, directionX, transform.right); // �ngulo respecto al eje X
            angleX = Mathf.Clamp(angleX, minAngle, maxAngle); // Limitar la rotaci�n del ca��n

            cannon.localRotation = Quaternion.Lerp(
                cannon.localRotation,
                Quaternion.Euler(angleX, 0, 0),
                Time.deltaTime * rotationSpeed
            );
        }
    }
}
