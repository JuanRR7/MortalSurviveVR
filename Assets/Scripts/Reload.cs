using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reload : MonoBehaviour
{
    public GameObject gun;
    private SphereCollider sphereCol;
    private FireBulletOnActivate gunCode;
    private bool emptyGun = false;
    public AudioClip reloadSound;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        gunCode = gun.GetComponent<FireBulletOnActivate>();
        sphereCol = GetComponent<SphereCollider>();
        audioSource = GetComponent<AudioSource>();

        sphereCol.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        emptyGun = (gunCode.numOfBullet == 0);

        sphereCol.enabled = emptyGun;
    }

    void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Municion")){
            gunCode.numOfBullet += 12;
            audioSource.PlayOneShot(reloadSound);
            Destroy(other.gameObject,1f);
        }
    }
}
