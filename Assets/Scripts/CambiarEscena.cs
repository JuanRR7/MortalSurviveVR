using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{
    // Start is called before the first frame update
    public int numeroEscena;

    // Update is called once per frame
    public void cambioEscena()
    {
        SceneManager.LoadScene(numeroEscena);
    }

    public void Salir()
    {
        Application.Quit();
        Debug.Log("Juego Cerrado");
    }
}