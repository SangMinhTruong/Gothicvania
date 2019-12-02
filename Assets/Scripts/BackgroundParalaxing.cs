using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundParalaxing : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject[] backgrounds;
    [SerializeField] float paralaxWeight = 10f;

    Vector3 lastCameraPos;
    // Start is called before the first frame update
    void Start()
    {
        lastCameraPos = mainCamera.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 curCameraPos = mainCamera.transform.position;
        for (int i = 0; i < backgrounds.Length; i++)
        {
            Vector3 cameraPosDelta = new Vector3(lastCameraPos.x - curCameraPos.x, 0, 0);
            Vector3 paralaxOffset = (cameraPosDelta / paralaxWeight) * i;
            backgrounds[i].transform.position += paralaxOffset;
        }
        lastCameraPos = curCameraPos;
    }
}
