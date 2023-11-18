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
        for (int i = 0; i < 2; i++) {
            var obj = Instantiate(playerScript.ballPrefab);
            var ball = obj.GetComponent<BallScript>();
            var rbBall = obj.GetComponent<Rigidbody2D>();
            rbBall.isKinematic = false;
            rbBall.AddForce(ball.ballInitialForce);
            ball.ballInitialForce += new Vector2(10 * i, 0);
             var v = rbBall.velocity;
            if (Random.Range(0,2) == 0)
                v.Set(v.x - 0.1f, v.y + 0.1f);
            else
                v.Set(v.x + 0.1f, v.y - 0.1f);
            rbBall.velocity = v;
            ball.ballInitialForce *= 1 + playerScript.level * playerScript.ballVelocityMult;
        }
    }

}