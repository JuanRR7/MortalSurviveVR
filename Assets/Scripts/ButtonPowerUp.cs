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
    public GameObject[] flogObjects;
    public bool isActiveFrezzer = false;
    public bool isActiveHelper = false;
    

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
        if(!isActive && !isReady)
        {
            if(gameObject.name == "ColliderFrezeer")
            {
                isActiveFrezzer = false;
                foreach (GameObject obj in flogObjects)
                {
                    obj.SetActive(false);
                }
            }
            else if(gameObject.name == "ColliderHelper")
            {
                isActiveHelper = false;
            }
        }
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

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Hand") && isReady)
        {
            timer.text = "...";
            sound.Play();
            isActive = true;
            isReady = false;

            if (gameObject.name == "ColliderHelper")
            {
                isActiveHelper = true;
            }
            else if(gameObject.name == "ColliderFrezeer")
            {
                isActiveFrezzer = true;
                foreach (GameObject obj in flogObjects)
                {
                    obj.SetActive(true);
                }
            }
            
            StartCoroutine(UsingPowerUp());
        }
        
    }
}
