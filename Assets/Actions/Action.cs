using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Action {

    // cost
    // Needs to change to reflect differences in valuations and possible kinds of costs. Data Type?
    float CheckCosts(Entity ent);

    // precondition
    bool CheckPreconditions(Hashtable preconditionTable);

    // effect
    void Effects();

}
