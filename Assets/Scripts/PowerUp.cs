using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private void Start()
    {
        // Destroy the power-up automatically after 5 seconds if not collected
        Destroy(gameObject, 5f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("LeftBullet") || collision.CompareTag("RightBullet"))
        {
            // Notify PlayerManager to add a new player
            PlayerManager.Instance.AddSoldier(collision.gameObject.tag);

            // Destroy the power-up after collection
            Destroy(gameObject);
        }
    }
}