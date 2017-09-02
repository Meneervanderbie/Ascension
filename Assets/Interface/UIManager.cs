using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public GameManager gm;

    public Text faithCounter;
    public Button AscendButton;

	// Use this for initialization
	void Start () {
        // when save/load exists: take value from savefile.
        faithCounter.text = 0.ToString();
        AscendButton.interactable = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(gm.faith >= gm.AscendCost) {
            AscendButton.interactable = true;
        } 
        else {
            AscendButton.interactable = false;
        }
	}

    public void ChangeFaithValue(int faithValue) {
        faithCounter.text = faithValue.ToString();
    }

    public void Ascend() {
        print("You win the game!");
    }
}
