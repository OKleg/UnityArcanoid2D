using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlowBonusScript : BonusScript {

  public SlowBonusScript() {
    text = "Slow";
    bonusColor = Color.green;
  }

  public override void BonusActivate() {
    
    GetComponent<SpriteRenderer>().color = bonusColor;
    var balls = GameObject.FindGameObjectsWithTag("Ball");
    foreach (var ball in balls) {
      rb = ball.GetComponent<Rigidbody2D>();
      rb.velocity = new Vector2(rb.velocity.x*0.9f,rb.velocity.y*0.9f);
    }
  }

}