using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform currentPos;

    public Vector3 moveSpeed = new Vector3(1,0,0);

    public float stopPoint;

    public bool willStop;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = transform.position + moveSpeed;

      /*  if (transform.position.x > 9.290164f)
        {
            moveSpeed = moveSpeed * -1f;
            
        }*/

        if (transform.position.y < stopPoint && willStop)
        {
            moveSpeed = moveSpeed * 0f;
            
        }

       // transform.position = transform.position + moveSpeed;
        

    }
}
