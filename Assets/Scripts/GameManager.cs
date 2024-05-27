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
    public GameObject gameOverScreen;
    public TextMeshProUGUI score;
    public TextMeshProUGUI hordes;
    private GameObject bulletsGroup;
    public GameObject bulletsGenerator;
    private GenerateMoreBullets generateMoreBullets;

    // Start is called before the first frame update
    void Start()
    {
        limiteZombies = Random.Range(5,15);
        bulletsGroup = GameObject.Find("--DYNAMIC--");
        generateMoreBullets = bulletsGenerator.GetComponent<GenerateMoreBullets>();
    }

    // Update is called once per frame
    void Update()
    {
        contadorZUI.text = limiteZombies + "";
        killsUI.text = points + "";
        hordeUI.text = horde + "";

        if(limiteZombies < 3) contadorZUI.color = new Color(1.0f, 0.22f, 0.22f);

        if(limiteZombies == 0){
            gameOver = true;
            hordes.text = "Hordas resistidas: " + horde;
            score.text = "Zombies aniquilados: " + points;
            gameOverScreen.SetActive(true);
        }

        if(bulletsGroup.transform.childCount == 1)
        {
            Destroy(bulletsGroup);
            generateMoreBullets.generateBullets();
            bulletsGroup = GameObject.Find("--DYNAMIC--(Clone)");
        }
    }
}
