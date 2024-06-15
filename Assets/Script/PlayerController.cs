using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public GameObject laserPrefab;
    public Transform firePoint;
    private float xMin, xMax; 
    //public int health = 3; // Player's health

    

    void Start()
    {
        // Set the boundaries for the player's movement
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftBoundary = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightBoundary = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        xMin = leftBoundary.x;
        xMax = rightBoundary.x;
    }

    void Update()
    {
        // Move the player left and right
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(horizontalInput, 0, 0);
        transform.Translate(movement * speed * Time.deltaTime);

        // Clamp the player's position
        float clampedX = Mathf.Clamp(transform.position.x, xMin, xMax);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);

        // Fire lasers
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(laserPrefab, firePoint.position, firePoint.rotation);
        }

    }
}
