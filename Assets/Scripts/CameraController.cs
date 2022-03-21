using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject player;
    float cameraHeight = 15;
    void LateUpdate()
    {
        if(player != null)
        {
            transform.position = player.transform.position + (Vector3.up * cameraHeight);
        }
    }

    public void SetPlayer(GameObject newPlayer)
    {
        player = newPlayer;
    }
}
