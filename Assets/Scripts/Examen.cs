using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Examen : MonoBehaviour
{
    public GameObject panel;
    public int respuesta;
    public TextMeshProUGUI problemaText;
    public TMP_InputField respuestaUsuario;
    public bool iscorrect = false;
    bool isplayerColliding = false;
    public Contador contador;
    // Start is called before the first frame update
    void Start()
    {
        respuesta = 0;
        iscorrect = false;
        panel.SetActive(false);
       
    }

    // Update is called once per frame
    void Update()
    {
        if (isplayerColliding)
        {
            Respuesta();
        }

        if (iscorrect)
        {
         //   panel.SetActive (false);

        }
        //Respuesta();

        //Interactuar();
        //transform.Rotate(Vector3.up, 100 * Time.deltaTime); // Rota el objeto constantemente
    }
    public void Interactuar()
    {
        Debug.Log("�El personaje ha interactuado con el objeto!");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // if(other.gameObject.tag =="Personaje")
        if (other.CompareTag("Personaje") && !iscorrect)
        {
           // Interactuar();   // aqui pasa algo de generar y abrir examen
            GenerarExamen();
            // Respuesta();
            isplayerColliding = true;
            // abrir panel del folio del examen en si
            panel.SetActive(true);
        }
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // if(other.gameObject.tag =="Personaje")
        if (other.CompareTag("Personaje"))
        {
            isplayerColliding = false;
            // cerrar panel del folio del examen en si
            panel.SetActive(false);
        }
    }

    private void Respuesta()
    {
        if(respuestaUsuario.text == respuesta.ToString())
        {
            iscorrect = true;
            isplayerColliding = false;
            panel.SetActive(false);
            contador.IncreaseScore(1);
            //resolver examen que sume y tal
        } else
        {
            iscorrect = false;
            //GenerarExamen();
            // de momento nada, a futuro que se cabree el fantasma
        }
    }

    private void GenerarExamen()
    {
        System.Random rnd = new System.Random();
        int num1 = rnd.Next(0, 10);
        int num2 = rnd.Next(0, 10);
        int operacion = rnd.Next(3);
        
        switch (operacion)
        {
            case 0:
                respuesta = num1 + num2;
                problemaText.text = num1 + " + " + num2 +" =";
                break;
            case 1:
                respuesta = num1 - num2;
                problemaText.text = num1 + " - " + num2 + " =";
                break;
            case 2:
                respuesta = num1 * num2;
                problemaText.text = num1 + " x " + num2 + " =";
                break;
        }
        

    }

}
