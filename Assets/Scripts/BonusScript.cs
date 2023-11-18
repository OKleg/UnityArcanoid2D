using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusScript : MonoBehaviour {


    public Rigidbody2D rb;
    protected PlayerScript playerScript;

    public string text = "+100";
    public Color bonusColor = Color.yellow;
    public Color textColor = Color.black;

    public GameDataScript gameData; 

    public virtual void BonusActivate() {
        playerScript.gameData.points+=100;
    }

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        //audioSrc = Camera.main.GetComponent<AudioSource>();
        GetComponent<SpriteRenderer>().color = bonusColor;
        
        this.GetComponentInChildren<Text>().text = text; 
        this.GetComponentInChildren<Text>().color = textColor;
    }

    void Update() {
       
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // if (gameData.sound)
        //     audioSrc.PlayOneShot(loseSound,5);
        Destroy(gameObject);
        BonusActivate();
    }

}
