using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public God playerCharacter;

    public float zoomSpeed;
    public float rotateSpeed;
    public float moveSpeed;

    public void CenterCamera()
    {
        //transform.position = playerCharacter.transform.position;
        //transform.rotation = Quaternion.Euler(45, 0, 0);
        //transform.position -= transform.forward * 10;
    }

    public void Zoom(float amount)
    {
        // TODO: Set a max and min zoom to clamp to
        transform.position -= transform.forward * amount * zoomSpeed;
    }

    public void Rotate(float amount)
    {
        // Shoot a Raycast to a point and rotate around that point by amount
        RaycastHit hit;
        Physics.Raycast(transform.position, transform.forward, out hit);
        if(hit.collider != null)
        {
            transform.RotateAround(hit.point, hit.transform.up, rotateSpeed * amount);
        }
    }

    public void MoveForward(float moveBy)
    {
        Vector3 oldPos = transform.position;
        transform.position += transform.forward * moveBy * moveSpeed;
        Vector3 newPos = new Vector3(transform.position.x, oldPos.y, transform.position.z);
        transform.position = newPos;
    }

    public void MoveSide(float moveBy)
    {
        Vector3 oldPos = transform.position;
        transform.position += transform.right * moveBy * moveSpeed;
        Vector3 newPos = new Vector3(transform.position.x, oldPos.y, transform.position.z);
        transform.position = newPos;
    }
}
