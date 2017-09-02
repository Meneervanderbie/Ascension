using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class God : Humanoid
{
    public int faithIncrease = 10;

    public Vector3 moveTarget;
    public bool moveTargetSet;

    public Elf talkTarget;
    public bool talkTargetSet;

    void Update() {
        if (moveTargetSet) {
            if (talkTargetSet && Vector3.Distance(transform.position, moveTarget) <= 2) {
                moveTargetSet = false;
                talkTargetSet = false;
                talkTarget.IncreaseFaith(faithIncrease);
            } else {
                transform.position = Vector3.MoveTowards(transform.position, moveTarget + Vector3.up, speed * Time.deltaTime);
                if (transform.position == moveTarget) {
                    print("Destination reached");
                }
            }
        }
    }

    public void MoveToTarget(Vector3 target) {
        // Maybe move to a specific tile?
        moveTargetSet = true;
        moveTarget = target;
    }

    public void TalkTo(Elf elf) {
        if(Vector3.Distance(transform.position, elf.transform.position) > 1){
            talkTarget = elf;
            talkTargetSet = true;
            moveTarget = elf.tile.transform.position;
            moveTargetSet = true;
        } 
        else {
            talkTarget = elf;
            talkTargetSet = true;
        }
    }
}
