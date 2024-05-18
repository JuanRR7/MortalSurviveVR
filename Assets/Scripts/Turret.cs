using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Turret : MonoBehaviour
{
    public float range;
    public Vida currentTarget;
    public List<Vida> currentTargets = new List<Vida>();
    private float rotationSpeed = 150.0f;
    private Vector3 direction;
    private ButtonPowerUp buttonPowerUpScript;
    public bool targetFound = false;
    // Start is called before the first frame update
    void Start()
    {
        buttonPowerUpScript = GameObject.Find("ColliderHelper").GetComponent<ButtonPowerUp>();
        currentTarget = null;
    }

    // Update is called once per frame
    void Update()
    {
        if(buttonPowerUpScript.isActiveHelper == true) 
        {
            EnemyDetection();
            LookRotation();
        }
    }
 
    void EnemyDetection()
    {
        currentTargets = Physics.OverlapSphere(transform.position, range)
        .Where(currentEnemy => currentEnemy.GetComponent<Vida>())
        .Select(currentEnemy => currentEnemy.GetComponent<Vida>())
        .ToList();

        currentTarget = currentTargets.FirstOrDefault(); // Asigna el primer objetivo si hay alguno, o null si no hay ninguno
    }
    void LookRotation()
    {
        if (currentTarget != null) // Comprueba si currentTarget no es nulo
        {
            targetFound = true;
            direction = currentTarget.transform.position - transform.position;
            Debug.DrawRay(transform.position, direction, Color.green);
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);  
        }
        else targetFound = false;
    }
}
