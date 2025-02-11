using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
private Rigidbody2D rb;
[SerializeField] private float velocityMultiplier = 15f;
[SerializeField] private LayerMask whatDestroysBullet;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SetStraightVelocity();
    }

    void OnBecameInvisible(){
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        String tag = "blank";
        if (collision.gameObject.tag == "LeftBullet" && gameObject.tag == "RightPlayer")
        {
            tag = "right";
        }
        if (collision.gameObject.tag == "RightBullet" && gameObject.tag == "LeftPlayer")
        {
            tag = "left";
        }

        GameObject collidingObject = collision.gameObject;
        
        if((whatDestroysBullet.value & (1 << collidingObject.layer))>0){
            if (gameObject != null)
            {
                if (tag == "left")
                {
                    PlayerManager.Instance.leftPlayerList.Remove(gameObject);
                }else if (tag == "right")
                {
                    PlayerManager.Instance.rightPlayerList.Remove(gameObject);
                }
                Destroy(gameObject);
            }
            if (collidingObject != null) Destroy(collidingObject);
        }
        
        if (tag != "blank") WinnerManager.Instance.RemoveSoldier(tag, gameObject);
    }

    private void SetStraightVelocity(){
        rb.velocity = transform.right * velocityMultiplier;
        if(gameObject.CompareTag("RightBullet")) rb.velocity *= -1;
    }
}
