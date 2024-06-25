using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandManager : MonoBehaviour
{
    public GameObject handAnchor;
    public GameObject cardModel;

    public int startingHandSize;
    public float verticalShift; // Probably need to change this based on screen size?

    public int horizontalShift; // Probably need to change this based on screen size?

    public int tilt;

    // Start is called before the first frame update
    void Start()
    {
        float middle = (startingHandSize+1) / 2;
        for(int i = 1; i < startingHandSize+1; i++){
            // Calculate the angle and offset for the current card. 
            float curPos = i - middle;
            float shiftBy = curPos / horizontalShift;
            float shiftVertical = Mathf.Abs(curPos) * verticalShift;
            //Vector3 curCardPos = new Vector3(handAnchor.transform.position.x-shiftBy, handAnchor.transform.position.y, handAnchor.transform.position.z);
            Vector3 curCardPos = new Vector3(-shiftBy, 0, -shiftVertical);
            Quaternion tempQuat = handAnchor.transform.rotation;
            tempQuat *= Quaternion.Euler(Vector3.down * curPos*tilt);
            // Need to save the cards to a hand array when we actually have that sort of thing set up. 
            //GameObject temp = Instantiate(cardModel, curCardPos, tempQuat, handAnchor.transform);
            GameObject temp = Instantiate(cardModel, handAnchor.transform, false);
            temp.transform.localPosition = curCardPos;
            temp.transform.rotation = tempQuat;
            temp.AddComponent<Card>();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
