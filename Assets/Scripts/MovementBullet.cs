using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBullet : MonoBehaviour
{
    private float speed = 30.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Verifica si el objeto con el que colisionó tiene la etiqueta "InitialPoint"
        if (collision.gameObject.CompareTag("InitialPoint"))
        {
            // Destruye la bala
            Destroy(gameObject);
        }
    }    
}
