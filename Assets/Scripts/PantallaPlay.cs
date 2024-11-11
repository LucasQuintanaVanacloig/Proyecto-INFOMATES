using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PantallaPlay : MonoBehaviour
{

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
        if (Input.GetKeyDown(KeyCode.E)) // La tecla E para interactuar
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
