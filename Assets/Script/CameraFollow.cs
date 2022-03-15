using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Vector2 velocity;
    //======================= SmoothDamp =====================================
    public float smoothTimeX;
    public float smoothTimeY;

    //======================= Clamp ========================================
    public float minX, minY, maxX, maxY;

    public GameObject player;
    public Transform targetForClamp;

    private void Start()
    {
        targetForClamp = GameObject.Find("Player").transform;
    }

    private void Update()
    {

    }

    /*private void SmoothDamp()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
        float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);

        transform.position = new Vector3(posX, posY, transform.position.z);
    }*/

    private void Clamp()
    {
        transform.position = new Vector3(Mathf.Clamp(targetForClamp.position.x, minX, maxX), Mathf.Clamp(targetForClamp.position.y, minY, maxY), transform.position.z);
    }

    private void LateUpdate()
    {
        Clamp();
    }
}
