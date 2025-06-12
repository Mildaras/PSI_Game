using UnityEngine;

public class PlaceTrigger : MonoBehaviour
{
    public GameObject objectToSpawn;
    public Transform spawnPoint;

    void Update()
    {
        if (Input.anyKeyDown)
        {
            Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            GameObject newObject = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
            newObject.name = "SpawnedObject";
            DontDestroyOnLoad(newObject);
        }
    }
}
