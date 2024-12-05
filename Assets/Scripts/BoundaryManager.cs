//using UnityEngine;

//public class BoundaryManager : MonoBehaviour
//{
//    private void Start()
//    {
//        SetUpBoundaries();
//    }

//    private void SetUpBoundaries()
//    {
//        Camera cam = Camera.main;
//        Vector3 screenBounds = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, cam.transform.position.z));
//        float thickness = 0.5f; // Thickness of the boundary colliders

//        // Top Boundary
//        CreateBoundary("TopBoundary", new Vector3(0, screenBounds.y + thickness / 2, 0), new Vector2(screenBounds.x * 2, thickness));

//        // Bottom Boundary
//        CreateBoundary("BottomBoundary", new Vector3(0, -screenBounds.y - thickness / 2, 0), new Vector2(screenBounds.x * 2, thickness));

//        // Left Boundary
//        CreateBoundary("LeftBoundary", new Vector3(-screenBounds.x - thickness / 2, 0, 0), new Vector2(thickness, screenBounds.y * 2));

//        // Right Boundary
//        CreateBoundary("RightBoundary", new Vector3(screenBounds.x + thickness / 2, 0, 0), new Vector2(thickness, screenBounds.y * 2));
//    }

//    private void CreateBoundary(string name, Vector3 position, Vector2 size)
//    {
//        GameObject boundary = new GameObject(name);
//        boundary.transform.position = position;
//        BoxCollider2D collider = boundary.AddComponent<BoxCollider2D>();
//        collider.size = size;
//        collider.isTrigger = false; // Ensure it acts as a physical boundary
//    }
//}
