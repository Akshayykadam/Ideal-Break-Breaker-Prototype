using UnityEngine;

public class RandomObjectManager : MonoBehaviour
{
    public ObjectPool objectPool; 
    public int minObjectsOnScreen = 30;


    private void Start()
    {
        MaintainMinimumObjects();
    }

    private void MaintainMinimumObjects()
    {
        for (int i = 0; i < minObjectsOnScreen ; i++)
        {
            SpawnRandomObject();
        }
    }

    public void SpawnRandomObject()
    {
        GameObject obj = objectPool.GetObject();
        if (obj != null)
        {
            Vector3 validPosition = GetValidPosition();
            obj.transform.position = validPosition;
            obj.SetActive(true); 
        }
    }

    private Vector3 GetValidPosition()
    {
        Camera cam = Camera.main;
        Vector3 screenBounds = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, cam.transform.position.z));

        // Spawn objects within the screen bounds
        return new Vector3(
            Random.Range(-screenBounds.x, screenBounds.x),
            Random.Range(-screenBounds.y, screenBounds.y),
            0
        );
    }
}
