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
        transform.Rotate(Vector3.up, 100 * Time.deltaTime); // Rota el objeto constantemente
    }
    public void Interactuar()
    {
        Debug.Log("¡El personaje ha interactuado con el objeto!");


        // Aquí puedes añadir la lógica de lo que debe suceder al interactuar
        // Ejemplos:
        // Activar una animación
        // Cambiar el color o estado del objeto
        // Destruir el objeto
        // Dar un mensaje al jugador, etc.
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // if(other.gameObject.tag =="Personaje")
        if (other.CompareTag("Personaje"))
        {
            // aqui pasa algo de generar y abrir examen



            // abrir panel del folio del examen en si
            panel.SetActive(true);
        }
    }

}
