using UnityEngine;
using UnityEngine.SceneManagement; // Para manejar la carga de escenas.

public class CambiarEscena : MonoBehaviour
{
    // Nombre de la escena que se cargar�
    [SerializeField] private string nombreEscena;

    // M�todo que se ejecuta al colisionar
    

    // Para triggers en lugar de colisiones f�sicas
    private void OnTriggerEnter2D(Collider2D other)
    {
       // if(other.gameObject.tag =="Personaje")
        if (other.CompareTag("Personaje"))
        {
            SceneManager.LoadScene(nombreEscena);
        }
    }
}
