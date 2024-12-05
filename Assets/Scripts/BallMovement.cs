using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float Speed = 5f;
    public float CollisionRadius = 0.5f; // Radius for overlap detection
    public LayerMask CollisionLayer; // Layer mask for collidable objects
    private Vector2 velocity;
    private Vector2 minBounds, maxBounds;

    private void Start()
    {
        // Set initial random direction and normalize
        velocity = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * Speed;

        // Get screen bounds from the camera
        Camera cam = Camera.main;
        Vector3 screenBottomLeft = cam.ScreenToWorldPoint(new Vector3(0, 0, cam.nearClipPlane));
        Vector3 screenTopRight = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, cam.nearClipPlane));

        minBounds = new Vector2(screenBottomLeft.x, screenBottomLeft.y);
        maxBounds = new Vector2(screenTopRight.x, screenTopRight.y);
    }

    private void FixedUpdate()
    {
        // Move the ball manually based on velocity
        transform.position += (Vector3)velocity * Time.fixedDeltaTime;

        // Check for boundary collisions
        CheckBoundaryCollisions();

        // Check for object collisions
        CheckObjectCollisions();
    }

    private void CheckBoundaryCollisions()
    {
        Vector3 pos = transform.position;

        // Reflect velocity if ball hits screen edges
        if ((pos.x <= minBounds.x && velocity.x < 0) || (pos.x >= maxBounds.x && velocity.x > 0))
        {
            velocity.x = -velocity.x; // Reflect on X-axis
        }

        if ((pos.y <= minBounds.y && velocity.y < 0) || (pos.y >= maxBounds.y && velocity.y > 0))
        {
            velocity.y = -velocity.y; // Reflect on Y-axis
        }
    }

    private void CheckObjectCollisions()
    {
        Collider2D collider = Physics2D.OverlapCircle(transform.position, CollisionRadius, CollisionLayer);
        if (collider != null)
        {
            Vector2 collisionNormal = (transform.position - collider.transform.position).normalized;

            // Reflect the velocity using the collision normal
            velocity = Vector2.Reflect(velocity, collisionNormal);

            // Move ball outside of collider to prevent continuous collision
            transform.position += (Vector3)(collisionNormal * CollisionRadius);

            Debug.Log("Collision Detected with: " + collider.name);
        }
    }

}
