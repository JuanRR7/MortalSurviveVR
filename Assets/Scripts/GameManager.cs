using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int limiteZombies = 0;
    public TextMeshProUGUI contadorZUI;
    public TextMeshProUGUI killsUI;
    public TextMeshProUGUI hordeUI;
    public bool gameOver = false;
    public int points = 0;
    public int horde = 1;

    // Start is called before the first frame update
    void Start()
    {
        limiteZombies = Random.Range(5,15);
    }

    // Update is called once per frame
    void Update()
    {
        contadorZUI.text = limiteZombies + "";
        killsUI.text = points + "";
        hordeUI.text = horde + "";

        if(limiteZombies == 0) gameOver = true;

        if(limiteZombies < 3) contadorZUI.color = new Color(1.0f, 0.22f, 0.22f);
    }
}
