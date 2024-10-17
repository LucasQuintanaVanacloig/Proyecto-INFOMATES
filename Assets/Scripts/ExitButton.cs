using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
    public void ExitGame()
    {
        // Si estamos en el editor de Unity
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #else
            // Si es una build, cierra la aplicación
            Application.Quit();
            #endif
    }
}
