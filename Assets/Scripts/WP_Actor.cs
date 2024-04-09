using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WP_Actor : MonoBehaviour
{
    float speed = 5.0f;
    private Transform target;
    public string nameOfPath;

    // Start is called before the first frame update
    void Start()
    {
        FindWayPoint();
        transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, 0, speed*Time.deltaTime));
    }

    void OnTriggerEnter(Collider other){
        Debug.Log("Entered");
        if(other.tag == "WayPoint"){
            target = other.gameObject.GetComponent<Waypoint>().nextPoint;
            transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
            Debug.Log(target.gameObject.name);
        }

        if(other.tag == "FinalDoor"){
            Destroy(gameObject);
        }
    }

    private void FindWayPoint(){
        target = GameObject.Find(nameOfPath).transform;
    }
}
