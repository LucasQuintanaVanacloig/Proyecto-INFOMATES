using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PantallaPlay : MonoBehaviour
{
    public GameObject panel;
    private Vector2 MinPantalla, MaxPantalla;
    private float _Vel;
    public float distanciaInteraccion = 5f; // Define la distancia del raycast
    // Start is called before the first frame update
    void Start()
    {
        _Vel = 8;
        MinPantalla = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        MaxPantalla = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
    }

    // Update is called once per frame
    void Update()
    {
        movimientoPJ();
        panel.SetActive(false);
        if (Input.GetKeyDown(KeyCode.F)) // La tecla F para interactuar
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, distanciaInteraccion))
            {
                if (hit.collider.CompareTag("Interactivo")) // Asegúrate de que el objeto tenga la etiqueta "Interactivo"
                {
                    var objetoInteractivo = hit.collider.GetComponent<Examen>();
                    if (objetoInteractivo != null)
                    {
                        objetoInteractivo.Interactuar(); // Llama al método en el objeto
                    }
                }
            }
        }
    
}
    private void OnTriggerStay2D(Collider2D other)
    {
        // Verificar si el objeto que colisiona tiene el tag "Personaje"
        if (other.gameObject.CompareTag("Personaje")) // Cambiado el tag a "Personaje"
        {
            // Cargar la nueva escena automáticamente al acercarse
            SceneManager.LoadScene("PantallaMapa");
        }
    }
    private void movimientoPJ()
    {
        //Todo esto para que se mueva el jugador y para que la camara tenga limites.
        float DireccionIndicadaX = Input.GetAxisRaw("Horizontal");
        float DireccionIndicadaY = Input.GetAxisRaw("Vertical");
        //Debug.Log("X: " + DireccionIndicadaX + " - Y: " + DireccionIndicadaY);

        Vector2 DireccionIndicada = new Vector2(DireccionIndicadaX, DireccionIndicadaY).normalized;

        Vector2 NuevaPos = transform.position;
        NuevaPos = NuevaPos + DireccionIndicada * _Vel * Time.deltaTime;

        Debug.Log(NuevaPos);

        NuevaPos.x = Mathf.Clamp(NuevaPos.x, MinPantalla.x, MaxPantalla.x);
        NuevaPos.y = Mathf.Clamp(NuevaPos.y, MinPantalla.y, MaxPantalla.y);

        transform.position = NuevaPos;
    }
}
