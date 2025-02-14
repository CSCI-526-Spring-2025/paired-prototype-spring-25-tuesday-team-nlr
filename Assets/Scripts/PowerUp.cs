using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private void Start()
    {
        
        Destroy(gameObject, 5f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("LeftBullet") || collision.CompareTag("RightBullet"))
        {
            PlayerManager.Instance.AddSoldier(collision.gameObject.tag);

           
            Destroy(gameObject);
        }
    }
}