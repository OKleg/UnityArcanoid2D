using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AddTenBonusScript : BonusScript {

    public AddTenBonusScript() {
        text = "+2";
        bonusColor = Color.blue;
    }

    public override void BonusActivate() {
        var balls = GameObject.FindGameObjectsWithTag("Ball");
        playerScript.gameData.balls += 10;
    }

}