using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PantallaPlay : MonoBehaviour
{

    private Vector2 MinPantalla, MaxPantalla;
    private float _Vel;

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
