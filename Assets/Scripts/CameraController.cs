using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform player;
    private CinemachineVirtualCamera camera;
    private float lowBound = -1f;
    // Start is called before the first frame update
    void Start()
    {
        camera = gameObject.GetComponent<CinemachineVirtualCamera>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        camera.Follow = player;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (player == null || player.position.y <= lowBound)
        {
            camera.Follow = null;
        }
    }
}
