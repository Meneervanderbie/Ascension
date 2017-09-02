using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    public God playerCharacter;
    public CameraController cc;

    void Start()
    {
        cc.playerCharacter = playerCharacter;
        cc.CenterCamera();
    }

    void Update()
    {
        float zoomActive = Input.GetAxis("Mouse ScrollWheel");
        if (zoomActive != 0)
        {
            cc.Zoom(-zoomActive);
        }
        if (Input.GetAxis("Fire3") != 0)
        {
            cc.Rotate(Input.GetAxis("Mouse X"));
        }
        //Vector3 moveBy = new Vector3(0, 0, 0);
        cc.MoveForward(Input.GetAxis("Vertical"));
        cc.MoveSide(Input.GetAxis("Horizontal"));

        if (Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100)) {
                if (hit.transform.gameObject.GetComponent<Elf>() != null) {
                    playerCharacter.TalkTo(hit.transform.gameObject.GetComponent<Elf>());
                }
            }
        }
        if (Input.GetMouseButtonDown(1)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, 100)) {
                if(hit.transform.gameObject.GetComponent<Tile>() != null) {
                    playerCharacter.MoveToTarget(hit.transform.position);
                }
            }
        }
    }

}
