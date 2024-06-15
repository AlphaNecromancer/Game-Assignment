using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public float moveSpeed = 5f; // Speed of enemy movement
    private Transform player; // Reference to the player's transform
    
    void Start()
    {
        transform.Rotate(-90, 0, 180);
    }
   
}