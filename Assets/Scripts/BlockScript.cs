using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // using TMPro;
public class BlockScript : MonoBehaviour
{
    public GameObject textObject;
    Text textComponent; 
        
    public int hitsToDestroy;
    public int points;

    PlayerScript playerScript;


    void Start() {
        if (textObject != null) {
            textComponent = textObject.GetComponent<Text>();
            textComponent.text = hitsToDestroy.ToString();
        }
        playerScript = GameObject.FindGameObjectWithTag("Player")
            .GetComponent<PlayerScript>(); 
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        {
            hitsToDestroy--;
            if (hitsToDestroy == 0) {
                if (this.ToString()[0] == 'G'){
                    var bonusType = playerScript.gameData.BonusTypeСhoose();
                    var bonus = Instantiate(playerScript.bonusPrefab,
                        new Vector3(this.transform.position.x,
                        this.transform.position.y, 0),
                        Quaternion.identity);
                    bonus.AddComponent(bonusType);
                }
                Destroy(gameObject);
                playerScript.BlockDestroyed(points);
            }
            else if (textComponent != null)
                textComponent.text = hitsToDestroy.ToString();
        }
    }

}

