using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed = 5f; // Velocidad del enemigo
    public float stoppingDistance = 1f; // Distancia mínima al personaje principal
    public bool flipSprite = true; // Si se debe voltear el sprite al cambiar de dirección

    private Transform player;
    private Vector3 lastPosition;

    void Start()
    {
        // Busca al personaje principal por el tag "Personaje"
        GameObject playerObject = GameObject.FindGameObjectWithTag("Personaje");

        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        else
        {
            Debug.LogError("No se encontró un objeto con el tag 'Personaje'.");
        }

        lastPosition = transform.position;
    }

    void Update()
    {
        if (player != null)
        {
            // Calcular la distancia al personaje principal
            float distance = Vector3.Distance(transform.position, player.position);

            // Si la distancia es mayor al stoppingDistance, el enemigo se mueve hacia el personaje
            if (distance > stoppingDistance)
            {
                Vector3 direction = (player.position - transform.position).normalized;
                transform.position += direction * speed * Time.deltaTime;

                // Si flipSprite está activado, cambia la dirección del sprite
                if (flipSprite)
                {
                    FlipSprite(direction.x);
                }
            }
        }
    }

    private void FlipSprite(float directionX)
    {
        // Cambia la escala en X si el enemigo cambia de dirección
        if (directionX > 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z); // Mirando derecha
        }
        else if (directionX < 0)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z); // Mirando izquierda
        }
    }
}
