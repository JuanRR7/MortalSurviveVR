using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int limiteZombies = 0;
    public TextMeshProUGUI contadorZ;
    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        limiteZombies = Random.Range(5,15);
    }

    // Update is called once per frame
    void Update()
    {
        contadorZ.text = limiteZombies + "";

        if(limiteZombies == 0) gameOver = true;
    }
}
