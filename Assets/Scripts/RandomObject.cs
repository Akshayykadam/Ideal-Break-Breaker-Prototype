//using UnityEngine;

//public class RandomObject : MonoBehaviour
//{
//    private RandomObjectManager objectManager;

//    [System.Obsolete]
//    private void Start()
//    {
//        objectManager = FindObjectOfType<RandomObjectManager>();
//    }

//    private void OnCollisionEnter2D(Collision2D collision)
//    {
//        if (collision.gameObject.CompareTag("Ball"))
//        {
//            // Notify manager to handle hit
//            objectManager.ObjectHit(gameObject);
//        }
//    }
//}
