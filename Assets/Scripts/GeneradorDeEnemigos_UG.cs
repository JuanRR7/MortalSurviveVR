using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorDeEnemigos_UG : MonoBehaviour
{

    public GameObject[] zombiePrefab;
    public Transform[] puntosDeGeneracion;
    public float tiempoDeGeneracion = 2f;
    public int numeroEnemigos;
    public int numeroOleada= 3;

    //public PantallaBalas pantallaBalas;//acceder a otro script
    

    // Start is called before the first frame update
    void Start()
    {
              
       StartCoroutine(AparecerEnemigo(numeroOleada));
       Debug.Log("Nueva Ronda"+ numeroOleada);
          
       
    }

    IEnumerator AparecerEnemigo(int enemigAGenerar)
    {

        //pantallaBalas.IniciaOleada();//mostrar el texto cuando inicia la oleada
        for(int x=0;x<enemigAGenerar;x++)//generar los enemigos que se indiquen
        {

            int indexPuntoDeGeneracion = Random.Range(0,puntosDeGeneracion.Length);
            Transform puntoDeGeneracion = puntosDeGeneracion[indexPuntoDeGeneracion];
            Instantiate(zombiePrefab[indexPuntoDeGeneracion], puntoDeGeneracion.position, puntoDeGeneracion.rotation);

            yield return new WaitForSeconds(tiempoDeGeneracion);
        }

        /*while(true)
        {
            for(int i=0; i<puntosDeGeneracion.Length; i++){
                Transform puntoDeGeneracion = puntosDeGeneracion[i];
                Instantiate(zombiePrefab, puntoDeGeneracion.position, puntoDeGeneracion.rotation);
            }
            yield return new WaitForSeconds(tiempoDeGeneracion);
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        //cuenta de los enemigos en pantalla
        numeroEnemigos = GameObject.FindGameObjectsWithTag("Enemigo").Length;
        //si  llega a 0 se vulven a generar
        if(numeroEnemigos == 0)
        {
            //pantallaBalas.FinOleada();
            numeroOleada+=10;
            StartCoroutine(AparecerEnemigo(numeroOleada));
            Debug.Log("Nueva Ronda"+ numeroOleada);

        }
    }
}
