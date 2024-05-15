using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LogicaSimpleEnemigo : MonoBehaviour
{
    private Vida vida;
    private Animator animator;
    //private Collider collider;
    public bool Vida0 = false;
    public float daño = 20f;
    public ParticleSystem blood;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        vida = GetComponent<Vida>();
        animator = GetComponent<Animator>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        RevisarVida();
    }

    void RevisarVida()
    {
        if(Vida0)return;
        if(vida.valor <= 0)
        {
            Vida0 = true;
            animator.CrossFadeInFixedTime("Vida0", 0.1f);
            gameManager.points += 1;
            Destroy(gameObject, 2f); //3f
        }
    }

    void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Bala")){
            blood.Stop();
            blood.Play();
            vida.RecibirDaño(daño);
            Destroy(other.gameObject);
        }
    }


}
