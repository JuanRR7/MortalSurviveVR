using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullet : MonoBehaviour
{
    public GameObject bullet;
    private ButtonPowerUp buttonPowerUpScript;
    private Turret turretScript;
    private AudioSource sound;
    public float timer = 0.001f; // Tiempo entre disparos
    public int maxCounter = 500; // Número máximo de disparos
    private int currentCounter = 0; // Contador de disparos
    private float nextFireTime = 0f; // Tiempo para el siguiente disparo
    public float bulletLifeTime = 5.0f; // Tiempo de vida de la bala

    // Start is called before the first frame update
    void Start()
    {
        buttonPowerUpScript = GameObject.Find("ColliderHelper").GetComponent<ButtonPowerUp>();
        turretScript = GameObject.Find("MGMain").GetComponent<Turret>();
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (buttonPowerUpScript.isActiveHelper && turretScript.targetFound)
        {
            // Verifica si es tiempo de disparar
            if (Time.time >= nextFireTime && currentCounter < maxCounter)
            {
                // Dispara una bala
                GameObject newBullet = Instantiate(bullet, transform.position, transform.rotation);
                Destroy(newBullet, bulletLifeTime);
                sound.Play();
                // Actualiza el tiempo para el próximo disparo
                nextFireTime = Time.time + timer;
                // Incrementa el contador
                currentCounter++;
            }
        }
        else
        {
            // Reinicia el contador y el temporizador si no se cumplen las condiciones
            currentCounter = 0;
            nextFireTime = Time.time;
        }
    }
}
