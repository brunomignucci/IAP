using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class crear_objetos : AAccionador
{
    public CreationStateContext ctx;

    public override void accionar()
    {
        ctx.alert();
    }

}
