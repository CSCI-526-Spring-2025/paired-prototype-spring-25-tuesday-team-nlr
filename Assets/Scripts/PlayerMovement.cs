using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movingSpeed = 2f;
    // Update is called once per frame
    void Update()
    {
        Boolean isLeftPlayer = gameObject.tag == "LeftPlayer", 
                isRightPlayer = gameObject.tag == "RightPlayer";
        if(SideSwitching.HasSideSwitched){
            if(isRightPlayer) HandleLeftPlayerMovement(gameObject);
            if(isLeftPlayer) HandleRightPlayerMovement(gameObject);
        }else{
            if(isLeftPlayer) HandleLeftPlayerMovement(gameObject);
            if(isRightPlayer) HandleRightPlayerMovement(gameObject);
        }

    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
        String tag = (gameObject.tag == "LeftPlayer") ? "left":"right";
        WinnerManager.Instance.DecreaseSoldiers(tag);
    }

    private void HandleRightPlayerMovement(GameObject gObj){
        if(Input.GetKey("up")){
            goUp(gObj);
        }else if(Input.GetKey("down")){
            goDown(gObj);
        }
    }

    private void HandleLeftPlayerMovement(GameObject gObj){
        if(Input.GetKey("w")){
            goUp(gObj);
        }else if(Input.GetKey("s")){
            goDown(gObj);
        }
    }

    private void goUp(GameObject gObj)
    {
        Vector3 trans = Vector3.up * movingSpeed * Time.deltaTime;
        Vector3 newPos = gObj.transform.position + trans;
        if (newPos.y > 4.5)
        {
            Destroy(gObj);
            WinnerManager.Instance.ShouldEndGame();
        }
        else
        {
            gObj.transform.Translate(trans);
        }
        
    }

    private void goDown(GameObject gObj)
    {
        Vector3 trans = Vector3.down * movingSpeed * Time.deltaTime;
        Vector3 newPos = gObj.transform.position + trans;
        if (newPos.y < -4.5)
        {
            Destroy(gObj);
            WinnerManager.Instance.ShouldEndGame();
        }
        else
        {
            gObj.transform.Translate(trans);
        }
        
    }
}
