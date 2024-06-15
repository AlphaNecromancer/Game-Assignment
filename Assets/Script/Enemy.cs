using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5f;
    public int scoreValue = 10; // Points for destroying this enemy
    public AudioClip destructionSound; // Assign this in the Inspector or dynamically
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    private void OnDestroy()
    {
        ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
        if (scoreManager != null)
        {
            scoreManager.AddScore(scoreValue);
        }
        if (destructionSound != null)
        {
            AudioSource.PlayClipAtPoint(destructionSound, transform.position);
        }

    }

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        // Destroy the enemy when it leaves the screen
        if (transform.position.z < -10)
        {
            Destroy(gameObject);
        }
    }
    

}