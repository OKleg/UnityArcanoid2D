using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FastBonusScript : BonusScript {

  public FastBonusScript() {
    text = "Fast";
    bonusColor = Color.red;
  }

  public override void BonusActivate() {
    var balls = GameObject.FindGameObjectsWithTag("Ball");
    foreach (var ball in balls) {
      ball.GetComponent<SpriteRenderer>().color = bonusColor;
      rb = ball.GetComponent<Rigidbody2D>();
      rb.velocity = new Vector2(rb.velocity.x*1.1f,rb.velocity.y*1.1f);
    }
  }

}