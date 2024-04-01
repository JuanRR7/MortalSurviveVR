using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorPU : MonoBehaviour
{
    public GameObject[] prefabsPowerUps;
    private float spawnRangeX = 113.7f;
    private float spawnRangeZ = 136f;
    Vector3 powerupSpawnOffset = Vector3.zero; // Cambiado a (0, 0, 0)

    void Start()
    {
        InvokeRepeating("GeneratePowerUp", 0f, 60f);

	}
    void Update()
    {
    	// Invoca la función GeneratePowerUp cada 160 segundos, repitiéndola cada 160 segundos.
    }
    
    // Función que se llama cada 160 segundos
    void GeneratePowerUp()
    {
        for (int i = 0; i < prefabsPowerUps.Length; i++)
        {
            // Instancia el prefab en una posición específica
            Instantiate(prefabsPowerUps[i], GenerateSpawnPosition(), Quaternion.identity);
        }
    }

    Vector3 GenerateSpawnPosition()
    {
        float xPos = Random.Range(-spawnRangeX, spawnRangeX);
        float zPos = Random.Range(-spawnRangeZ, spawnRangeZ);
        return new Vector3(xPos, 7.2f, zPos); // Asegúrate de agregar la 'f' al final para especificar un número flotante
    }
}
