using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BallBonusScript : BonusScript {

    public BallBonusScript() {
        text = "Ball";
        bonusColor = Color.green;
    }

    public override void BonusActivate() {
        playerScript.gameData.balls += 2;
    }

}