using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Examen : MonoBehaviour
{
    public GameObject panel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Interactuar();
        transform.Rotate(Vector3.up, 20 * Time.deltaTime); // Rota el objeto constantemente
    }
    public void Interactuar()
    {
        Debug.Log("¡El personaje ha interactuado con el objeto!");
        panel.SetActive(true);

        // Aquí puedes añadir la lógica de lo que debe suceder al interactuar
        // Ejemplos:
        // Activar una animación
        // Cambiar el color o estado del objeto
        // Destruir el objeto
        // Dar un mensaje al jugador, etc.
    }

}
