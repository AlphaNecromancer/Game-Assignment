using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text healthText;

    private void Start()
    {
        UpdateHealthText(3); // Initial health value
    }

    public void UpdateHealthText(int health)
    {
        healthText.text = "Health: " + health.ToString();
    }
}
