﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class accionador_atras : AAccionador
{
    public override void accionar()
    {
        accionar_atras();
    }

    private void accionar_atras()
    {
        transform.root.GetComponent<Server>().mover_atras_leap();
    }
}

        