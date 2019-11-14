using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public abstract class State : NetworkBehaviour
{
  public State next;
  public abstract void alert(CreationStateContext ctx);
  public abstract void initialize();
}
