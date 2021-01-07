using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Player player;
    [SerializeField]
    SwipeController swipeCon;
    [SerializeField]
    GameObject buttonPause;

    private Transform playerTransform;
    private Transform myTransform;
    private Camera myCamera;

    [SerializeField]
    float speed = 2;

    Vector3 newPos;

    private bool cameraMove = false;

    [SerializeField]
    private int sizeOrthographic = 8;

    void Start()
    {
        playerTransform = player.transform;
        myTransform = GetComponent<Transform>();
        myCamera = GetComponent<Camera>();
    }
    
    void Update()
    {
        if (cameraMove)
        {
            newPos = new Vector3(playerTransform.position.x, playerTransform.position.y, -10);
            myTransform.position = Vector3.MoveTowards(myTransform.position, newPos, speed * Time.deltaTime);
        }

    }

    public IEnumerator CoCameraStartPos()
    {
        while (myCamera.orthographicSize > sizeOrthographic)
        {
            yield return new WaitForSeconds(.01f);
            myCamera.orthographicSize -= 0.2f;
        }

        buttonPause.SetActive(true);
    }

}
