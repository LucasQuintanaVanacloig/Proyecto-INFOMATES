using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwsdPj : MonoBehaviour
{
    public Animator animator; // Referencia al Animator del personaje
    public float speed = 3f;  // Velocidad del personaje

    private Vector2 movement; // Dirección de movimiento
    private Rigidbody2D rb;   // Referencia al Rigidbody2D

    private void Start()
    {
        // Obtén el componente Rigidbody2D del personaje
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Detecta la entrada de las teclas WASD
        movement.x = Input.GetAxisRaw("Horizontal"); // A/D o flechas izquierda/derecha
        movement.y = Input.GetAxisRaw("Vertical");   // W/S o flechas arriba/abajo

        // Actualiza el parámetro "IsRunning" en el Animator
        if (movement.magnitude > 0)
        {
            animator.SetBool("IsRunning", true); // Activar animación de correr
        }
        else
        {
            animator.SetBool("IsRunning", false); // Volver a la animación de Idle
        }
    }

    private void FixedUpdate()
    {
        // Mueve al personaje aplicando la velocidad
        rb.velocity = movement.normalized * speed;
    }
}

