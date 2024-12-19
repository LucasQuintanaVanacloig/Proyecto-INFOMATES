using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // El transform del jugador
    public Vector3 offset; // Offset opcional entre la cámara y el jugador
    public float smoothSpeed = 0.125f; // Velocidad de suavizado

    void FixedUpdate()
    {
        if (player != null)
        {
            // Calcula la posición deseada con el offset
            Vector3 desiredPosition = player.position + offset;

            // Suaviza la transición de la cámara
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Actualiza la posición de la cámara
            transform.position = smoothedPosition;
        }
        else
        {
            Debug.LogWarning("No se ha asignado el jugador a la cámara.");
        }
    }
}
