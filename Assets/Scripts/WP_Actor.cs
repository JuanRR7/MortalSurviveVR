using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WP_Actor : MonoBehaviour
{
    public float speed = 1.5f;
    private Transform target;
    public string nameOfPath;
    private GameManager gameManager;
    private ButtonPowerUp buttonPowerUpScript;

    // Start is called before the first frame update
    void Start()
    {
        buttonPowerUpScript = GameObject.Find("ColliderFrezeer").GetComponent<ButtonPowerUp>();
        FindWayPoint();
        transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        RevisarPowerUpFrezeer();
        transform.Translate(new Vector3(0, 0, speed*Time.deltaTime));
    }

    void OnTriggerEnter(Collider other){
        if(other.tag == "WayPoint"){
            target = other.gameObject.GetComponent<Waypoint>().nextPoint;
            transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
        }

        if(other.tag == "FinalDoor" && !gameManager.gameOver){
            Destroy(gameObject);
            gameManager.limiteZombies--;
        }
    }

    private void FindWayPoint(){
        target = GameObject.Find(nameOfPath).transform;
    }

    void RevisarPowerUpFrezeer()
    {
        if(buttonPowerUpScript.isActiveFrezzer == true) speed = 0.1f;
        else speed = 1.5f;
    }
}
