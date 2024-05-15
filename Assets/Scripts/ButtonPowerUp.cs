using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonPowerUp : MonoBehaviour
{
    public int lifeTime;
    public int loadTime;
    private int lifeTimeAux;
    private int loadTimeAux;
    public Material offMaterial;
    public Material onMaterial;
    public bool isActive = false;
    public bool isReady = false;
    public TextMeshProUGUI timer;
    public GameObject push;
    private Renderer materialOnUse;
    private AudioSource sound;

    // Start is called before the first frame update
    void Start()
    {
        materialOnUse = push.GetComponent<Renderer>();
        sound = GetComponent<AudioSource>();
        lifeTimeAux = lifeTime;
        loadTimeAux = loadTime;
        lifeTime = 0;
        timer.text = loadTime + "";

        StartCoroutine(ReloadPowerUp());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ReloadPowerUp()
    {
        loadTime--;
        timer.text = loadTime + "";
        yield return new WaitForSeconds(1);

        if(loadTime > 0){
            StartCoroutine(ReloadPowerUp());
        }else if(loadTime == 0){
            isReady = true;
            timer.text = ":)";
            materialOnUse.material = onMaterial;
            lifeTime = lifeTimeAux;
        }
    }

    IEnumerator UsingPowerUp()
    {
        lifeTime--;
        yield return new WaitForSeconds(1);

        if(lifeTime == 0){
            isActive = false;
            loadTime = loadTimeAux;
            StartCoroutine(ReloadPowerUp());
        }else if(lifeTime > 0){
            materialOnUse.material = offMaterial;
            StartCoroutine(UsingPowerUp());
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Hand") && isReady){
            timer.text = "...";
            sound.Play();
            isActive = true;
            isReady = false;
            StartCoroutine(UsingPowerUp());
        }
    }
}
