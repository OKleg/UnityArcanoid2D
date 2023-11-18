using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AddTenBonusScript : BonusScript {


    public AddTenBonusScript() {
        text = "+10";
        bonusColor = Color.blue;
    }
    
    public override void BonusActivate() {
        int countBalls = 10;
        var balls = GameObject.FindGameObjectsWithTag("Ball");
        playerScript.gameData.balls += countBalls;
         for (int i = 0; i < countBalls; i++) {
            var obj = Instantiate(playerScript.ballPrefab);
            var ball = obj.GetComponent<BallScript>();
            var rbBall = obj.GetComponent<Rigidbody2D>();
            rbBall.isKinematic = false;
            rbBall.AddForce(ball.ballInitialForce);
            ball.ballInitialForce += new Vector2(10 * i, 0);
             var v = rbBall.velocity;
            if (Random.Range(0,i) % 2 == 0)
                v.Set(v.x - i/10.0f, v.y + i/10.0f);
            else
                v.Set(v.x + i/10.0f, v.y - i/10.0f);
            rbBall.velocity = v;
            ball.ballInitialForce *= 1 + playerScript.level * playerScript.ballVelocityMult;
        }
    }

}