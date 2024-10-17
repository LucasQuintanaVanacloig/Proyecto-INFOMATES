using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstruccionesButton : MonoBehaviour
{
    public void AnarAEscenaJugant()
    {
        SceneManager.LoadScene("PantallaInstrucciones");
    }
}
