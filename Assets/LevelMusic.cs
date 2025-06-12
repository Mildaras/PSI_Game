using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;

    void Update()
    {
        if (Input.anyKeyDown)
        {
            Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            spawnPosition.z = 0f;
            GameObject newObject = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
            newObject.name = "SpawnedObject";
            DontDestroyOnLoad(newObject);
        }
    }
}
