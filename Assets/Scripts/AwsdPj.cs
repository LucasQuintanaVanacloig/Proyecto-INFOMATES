using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwsdPj : MonoBehaviour
{
    public Animator animator; // Referencia al Animator del personaje
    public float speed = 3f;  // Velocidad del personaje

    private Vector2 movement; // Direcci�n de movimiento
    private Rigidbody2D rb;   // Referencia al Rigidbody2D

    private void Start()
    {
        // Obt�n el componente Rigidbody2D del personaje
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Detecta la entrada de las teclas WASD
        movement.x = Input.GetAxisRaw("Horizontal"); // A/D o flechas izquierda/derecha
        movement.y = Input.GetAxisRaw("Vertical");   // W/S o flechas arriba/abajo

        // Actualiza el par�metro "IsRunning" en el Animator
        if (movement.magnitude > 0)
        {
            animator.SetBool("IsRunning", true); // Activar animaci�n de correr
        }
        else
        {
            animator.SetBool("IsRunning", false); // Volver a la animaci�n de Idle
        }
    }

    private void FixedUpdate()
    {
        // Mueve al personaje aplicando la velocidad
        rb.velocity = movement.normalized * speed;
    }
}

