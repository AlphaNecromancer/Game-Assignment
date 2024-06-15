using UnityEngine;

public class Laser : MonoBehaviour
{
    public float speed = 25f;

    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        // Destroy the laser when it leaves the screen
        if (transform.position.z > 20)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            // Destroy the laser
            Destroy(other.gameObject);



            // Destroy the enemy
            Destroy(gameObject);
        }
    }
}