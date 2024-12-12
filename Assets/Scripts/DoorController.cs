using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{
    public GameObject door; // Referencia al objeto de la puerta
    public Examen examen1;  // Referencia al script Examen
    public Examen2 examen2; // Referencia al script Examen2
    public Examen3 examen3; // Referencia al script Examen3
    public bool examensCorrectes = false;

    
    private void Update()
    {
        // Debug.Log(examen1.iscorrect +" - " +examen2.correct2 + " - " + examen3.correct);
        Debug.Log("examensCorrectes=" + examensCorrectes);
        // Verifica los valores de los booleanos en los scripts de los exámenes
        if (examen1.iscorrect && examen2.correct2 && examen3.correct)
        {
                examensCorrectes |= true;
                }
    }
        
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Personaje"))
        {
            if (examensCorrectes == true)
            {
                SceneManager.LoadScene("PantallaFinal");

            }
        }
        
    }

}
