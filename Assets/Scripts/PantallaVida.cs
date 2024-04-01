using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PantallaVida : MonoBehaviour
{
    public Text texto;
    public Vida vida;
    public LogicaJugador logicaJugador;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (logicaJugador.tieneMasVida) {
            texto.text = vida.valor + "/100";
        }else{
                texto.text = vida.valor + "/100";

        }
    }
}
