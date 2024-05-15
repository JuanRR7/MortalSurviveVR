using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FireBulletOnActivate : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnPoint;
    public float fireSpeed = 25;
    public AudioClip shoot;
    public AudioClip withoutBullets;
    private AudioSource audioSource;
    public ParticleSystem shootParticle;
    public int numOfBullet = 12;
    public TextMeshProUGUI numOfBulletUI;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        numOfBulletUI.text = numOfBullet + "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FireBullet()
    {
        if(numOfBullet > 0){
            GameObject spawnedBullet = Instantiate(bullet);
            shootParticle.Stop();
            shootParticle.Play();
            audioSource.PlayOneShot(shoot);
            spawnedBullet.transform.position = spawnPoint.position;
            spawnedBullet.GetComponent<Rigidbody>().velocity = spawnPoint.forward * fireSpeed;
            Destroy(spawnedBullet, 5);
            numOfBullet--;
        }else{
            audioSource.PlayOneShot(withoutBullets);
        }

        numOfBulletUI.text = numOfBullet + "";
    }
}