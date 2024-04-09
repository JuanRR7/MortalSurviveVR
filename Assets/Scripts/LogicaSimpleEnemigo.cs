using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LogicaSimpleEnemigo : MonoBehaviour
{
    private Vida vida;
    private Animator animator;
    private Collider collider;
    public bool Vida0 = false;

    // Start is called before the first frame update
    void Start()
    {
        vida = GetComponent<Vida>();
        animator = GetComponent<Animator>();
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
            Destroy(gameObject, 2f); //3f
        }
    }
}
