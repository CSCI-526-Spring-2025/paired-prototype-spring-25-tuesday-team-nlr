using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject gun;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletSpawnPoint;

    private GameObject bulletInstance;

    // Update is called once per frame
    void Update()
    {
        HandleShooting();
    }

    private void HandleShooting(){
        
        if(Mouse.current.leftButton.wasPressedThisFrame){
            bulletInstance = Instantiate(bullet, bulletSpawnPoint.position, quaternion.identity);
            if (gameObject.tag == "LeftPlayer")
            {
                bulletInstance.tag = "LeftBullet";
            }else if (gameObject.tag == "RightPlayer")
            {
                bulletInstance.tag = "RightBullet";
            }
        }
    }
}
