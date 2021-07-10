using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image ObjectwithImage;
    public Sprite[] spritesToChangeItTo;
    public int health;
    public int health2;

    void Update() {
        if(Input.GetKeyDown(KeyCode.Space) && health>0){
            health--;
            ObjectwithImage.sprite = spritesToChangeItTo[health];
            if(health == 0) 
                health = health2;
        }
    }
    
}
