using UnityEngine;
using UnityEngine.UI;

public class BallSpawner : MonoBehaviour
{
    public ObjectPool ballPool;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            spawnPosition.z = 0; 
            SpawnBall(spawnPosition);
        }
    }

    void SpawnBall(Vector3 position)
    {
        GameObject ball = ballPool.GetObject();
        if (ball != null)
        {
            ball.transform.position = position;
            ball.SetActive(true);
        }
        else
        {
            Debug.LogWarning("No available balls in the pool!");
        }
    }
}
