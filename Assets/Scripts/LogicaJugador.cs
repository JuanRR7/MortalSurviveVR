using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class LogicaJugador : MonoBehaviour
{
    public Vida vida;
    public bool Vida0 = false;
    [SerializeField]
    private Animator animadorPerder;
    protected AudioSource audioSource;
    public bool tienePoweUp;
    public bool tieneMasVida;
    public float tiempoPowerUp = 10f;
    private float duracionPowerUp = 20f;
    public float velocidadPowerUp = 15f;
    public PlayerController caminarRapido;


    [SerializeField] 
    public event EventHandler MuerteJugador;
    // Start is called before the first frame update
    void Start()
    {
        vida = GetComponent<Vida>();
        audioSource = GetComponent<AudioSource>();
        caminarRapido = GetComponent<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {
        RevisarVida();
    }

    void RevisarVida()
    {
        if (Vida0) return;
        if (vida.valor <= 0)
        {
             MuerteJugador?.Invoke(this, EventArgs.Empty);//Se llama al evento
            Vida0 = true;
        }
    }

    void ReiniciarJuego()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MasVelo"))//desaparecer powerUp
        {
            tienePoweUp = true;
            tiempoPowerUp = duracionPowerUp;
            audioSource.Play();
            Destroy(other.gameObject);

        }

        if (other.CompareTag("MenorVelo"))//desaparecer powerUp
        {
            tienePoweUp = true;
            audioSource.Play();
            Destroy(other.gameObject);
            caminarRapido.AlterarVelocidad(3f, 5f);// primer parametro: velocidad y segundo: duracion
        }
        
        if (other.CompareTag("MayorDaño"))//desaparecer powerUp
        {
            tienePoweUp=true;
            tieneMasVida=true;
            audioSource.Play();
            Destroy(other.gameObject);
            vida.valor=100;
        }


    }


}
