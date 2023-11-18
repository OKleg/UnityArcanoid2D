using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AddTwoBonusScript : BonusScript {

    public AddTwoBonusScript() {
        text = "+2";
        bonusColor = Color.blue;
    }

    public override void BonusActivate() {
        var balls = GameObject.FindGameObjectsWithTag("Ball");
        playerScript.gameData.balls += 2;
    }

}