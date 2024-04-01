using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class MenuGameOver : MonoBehaviour
{
    public int numeroEscena;
    [SerializeField] 
    private GameObject menuGameOver;
    private LogicaJugador logicaJugador;
    // Start is called before the first frame update
    private 
    void Start()
    {
        logicaJugador = GameObject.FindGameObjectWithTag("Player").GetComponent <LogicaJugador>();
        logicaJugador.MuerteJugador += ActivarMenu;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ActivarMenu(object sender, EventArgs e)
    {
        menuGameOver.SetActive(true);
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void ReiniciarJuego()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

     public void cambioEscena()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(numeroEscena);
    }

    public void Salir()
    {
        Application.Quit();
        Debug.Log("Juego Cerrado");
    }
}
