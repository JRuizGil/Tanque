using UnityEngine;
using UnityEngine.UI; // Necesario para acceder a la UI de texto

public class Contador : MonoBehaviour
{
    private int contador = 0; // Contador de objetivos destruidos
    public Text contadorTexto; // Referencia al componente de texto (UI)

    void Start()
    {
        // Asegúrate de que haya un texto asignado en el Inspector
        if (contadorTexto == null)
        {
            Debug.LogError("ContadorTexto no asignado en el Inspector");
        }
        else
        {
            // Inicializa el contador al inicio (opcional)
            ActualizarTexto();
        }
    }

    void Update()
    {
        // Aquí puedes agregar cualquier otra lógica si es necesario
    }

    // Método para sumar al contador
    public void SumarContador()
    {
        contador++; // Incrementar el contador
        ActualizarTexto(); // Actualizar el texto en pantalla
    }

    // Método para actualizar el texto del contador en la UI
    private void ActualizarTexto()
    {
        if (contadorTexto != null)
        {
            contadorTexto.text = "Objetivos Destruidos: " + contador; // Actualizar el texto con el valor del contador
        }
    }
}
