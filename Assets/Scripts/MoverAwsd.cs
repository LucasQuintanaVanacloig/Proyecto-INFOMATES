using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverPersonaje : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidad del personaje
    private Animator animator;  // Controlador de animaciones
    private SpriteRenderer spriteRenderer; // Para voltear el sprite

    void Start()
    {
        // Obtiene los componentes necesarios
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Obt�n la entrada del jugador
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // Calcula el movimiento
        Vector2 movement = new Vector2(horizontal, vertical).normalized;

        // Mueve al personaje
        transform.Translate(movement * moveSpeed * Time.deltaTime);

        // Control de animaciones
        if (movement != Vector2.zero) // Si se est� moviendo
        {
            animator.SetBool("IsRunning", true);

            // Control de direcci�n horizontal
            if (horizontal != 0)
            {
                animator.Play("Caminar"); // Animaci�n lateral
                spriteRenderer.flipX = horizontal < 0; // Voltea el sprite si es necesario
            }

            // Control de direcci�n vertical
            if (vertical > 0) // Movimiento hacia arriba
            {
                animator.Play("caminararriba");
            }
            else if (vertical < 0) // Movimiento hacia abajo
            {
                animator.Play("caminarabajo");
            }
        }
        else // Si no se est� moviendo
        {
            animator.SetBool("IsRunning", false); // Volver a Idle
        }
    }
}
