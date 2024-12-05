using UnityEngine;

public class BallManager : MonoBehaviour
{
    public ObjectPool ballPool; // Reference to the ball object pool
    public int initialBalls = 10;

    private void Start()
    {
        SpawnAllBalls();
    }

    private void SpawnAllBalls()
    {
        for (int i = 0; i < initialBalls; i++)
        {
            SpawnBall();
        }
    }

    public void SpawnBall()
    {
        GameObject ball = ballPool.GetObject();

        if (ball != null)
        {
            ball.transform.position = GetCenterPosition();
            ball.SetActive(true); 
        }
    }

    private Vector3 GetCenterPosition()
    {
        Camera cam = Camera.main;
        float zPos = cam.nearClipPlane;
        Vector3 centerPosition = cam.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, zPos));
        return new Vector3(centerPosition.x, centerPosition.y, 0);
    }

}
