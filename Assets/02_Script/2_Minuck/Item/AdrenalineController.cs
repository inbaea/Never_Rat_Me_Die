using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdrenalineController : ItemController
{
    public int adrenalineBuffCount;

    protected override void ApplyEffect()
    {
        playerGuide.adrenalineCount = playerGuide.adrenalineCount + adrenalineBuffCount;
    }
}
