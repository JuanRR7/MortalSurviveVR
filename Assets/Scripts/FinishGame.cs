using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinishGame : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject gameOverScreen;
    public TextMeshProUGUI score;
    public TextMeshProUGUI hordes;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setGameOverOn(){
        gameManager.gameOver = true;
        hordes.text = "Hordas resistidas: " + hordes;
        score.text = "Zombies aniquilados: " + score;
        gameOverScreen.SetActive(true);
    }
}
