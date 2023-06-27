using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseController : ItemController
{
    public int moveCountRecoveryAmount;

    protected override void ApplyEffect()
    {
        playerGuide.moveCount = playerGuide.moveCount + moveCountRecoveryAmount;
    }
}
