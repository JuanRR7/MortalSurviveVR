using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PantallaBalas : MonoBehaviour
{

    public Text texto;
    public Text textoMensajeLogro;
    public Text textoNuevaO;
    public LogicaArma logicaArma;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (logicaArma.restablecer) {
            texto.text = logicaArma.balasEnCartucho + "/" + logicaArma.tamañoDeCartucho + "\n" + logicaArma.balasRestantes;
            
        } else {
            texto.text = logicaArma.balasEnCartucho + "/" + logicaArma.tamañoDeCartucho + "\n" + logicaArma.balasRestantes;
        }
    }

        public void FinOleada()
    {
        textoMensajeLogro.gameObject.SetActive(true);
          // Llamar a DesactivarTextoNuevaO después de 2 segundos
        Invoke("DesactivarTextoFinOleada", 2f);
    }

    // Método para desactivar el textoNuevaO
    void DesactivarTextoFinOleada()
    {
        textoNuevaO.gameObject.SetActive(false);
    }


    public void IniciaOleada()
    {
        textoNuevaO.gameObject.SetActive(true);
          // Llamar a DesactivarTextoNuevaO después de 2 segundos
        Invoke("DesactivarTextoNuevaO", 2f);
    }

    // Método para desactivar el textoNuevaO
    void DesactivarTextoNuevaO()
    {
        textoNuevaO.gameObject.SetActive(false);
    }
}
