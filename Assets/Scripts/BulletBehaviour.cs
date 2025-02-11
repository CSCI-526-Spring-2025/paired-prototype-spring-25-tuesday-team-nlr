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
        GameObject collidingObject = collision.gameObject;
        
        if((whatDestroysBullet.value & (1 << collidingObject.layer))>0){
            if(gameObject != null) Destroy(gameObject);
            if (collidingObject != null) Destroy(collidingObject);
        }
    }

    private void SetStraightVelocity(){
        rb.velocity = transform.right * velocityMultiplier;
        if(gameObject.CompareTag("RightPlayer")) rb.velocity *= -1;
    }
}
