using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreationStateContext : MonoBehaviour
{
    public State firstState;
    private State currentState;
    // Start is called before the first frame update
    void Start()
    {
        currentState = firstState;
    }

    public void setState(State state)
    {
      currentState = state;
      currentState.initialize();
    }

    public void alert()
    {
      currentState.alert(this);
    }

}
