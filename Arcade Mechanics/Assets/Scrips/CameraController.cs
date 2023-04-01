using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;

    public Transform pivot;

    public Vector3 offset;

    public float rotateSpeed;

    public bool useOffsetValues;

    public float maxViewAngle;

    public float minViewAngle;

    public bool invertY = false;

    // Start is called before the first frame update
    void Start()
    {
        if (!useOffsetValues)
        {
            offset = player.position - transform.position;
        }

        pivot.transform.position = player.transform.position;
        pivot.transform.parent = player.transform;

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Get the x position of the mouse and rotate the player
        float horizantal = Input.GetAxis("Mouse X") * rotateSpeed;
        player.Rotate(0, horizantal, 0);

        //Get the y position of the mouse and rotate the pivot
        float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;
        if(invertY)
        {
            pivot.Rotate(vertical, 0, 0);
        }
        else
        {
            pivot.Rotate(-vertical, 0, 0);
        }

        //Limit the up/down camera rotation
        if (pivot.rotation.eulerAngles.x > maxViewAngle && pivot.rotation.eulerAngles.x < 180f)
        {
            pivot.rotation = Quaternion.Euler(maxViewAngle, 0, 0);
        }
        if (pivot.rotation.eulerAngles.x > 180f && pivot.rotation.eulerAngles.x < 330f + minViewAngle)
        {
            pivot.rotation = Quaternion.Euler(330f + minViewAngle, 0, 0);
        }


        //Move the camera based on the current rotation of the target & the original offset
        float desiredYAngle = player.eulerAngles.y;
        float desiredXAngle = pivot.eulerAngles.x;
        Quaternion rotation = Quaternion.Euler(desiredXAngle, desiredYAngle, 0);
        transform.position = player.position - (rotation * offset);

        //transform.position = player.position - offset;

        if(transform.position.y < player.position.y)
        {
            transform.position = new Vector3(transform.position.x, player.position.y - 0.5f, transform.position.z);
        }

        transform.LookAt(player);
    }
}
