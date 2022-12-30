using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ballscript : MonoBehaviour
{
    // Start is called before the first frame update
    

   public float speed=30;
   public Text scorerightText;
   	
	public Text scoreleftText;
	int scoreRight;
	int scoreLeft;
    void Start()
    {
     
     GetComponent<Rigidbody2D>().velocity=Vector2.right*speed;
	
        
    }

float hitFactor(Vector2 ballPos, Vector2 racketPos,
                float racketHeight) {
    // ascii art:
    // ||  1 <- at the top of the racket
    // ||
    // ||  0 <- at the middle of the racket
    // ||
    // || -1 <- at the bottom of the racket
    return (ballPos.y - racketPos.y) / racketHeight;
}



void OnCollisionEnter2D(Collision2D col) {
  
  if (col.gameObject.name == "Wallright") {
			//this line will just add 1 point to the score
			scoreLeft ++;
			//this line will convert the int score variable to a string variable
			scoreleftText.text = scoreLeft.ToString ();
		}
		if (col.gameObject.name == "Wallleft") {
			scoreRight ++;
			scorerightText.text = scoreRight.ToString ();
		}
   
    if (col.gameObject.name == "RacketLeft") 
		{
       
        float y = hitFactor(transform.position,
                            col.transform.position,
                            col.collider.bounds.size.y);

       
        Vector2 dir = new Vector2(1, y).normalized;

        // Set Velocity with dir * speed
        GetComponent<Rigidbody2D>().velocity = dir * speed;
    }

   
    if (col.gameObject.name == "RacketRight") {
      
        float y = hitFactor(transform.position,
                            col.transform.position,
                            col.collider.bounds.size.y);


        Vector2 dir = new Vector2(-1, y).normalized;

        
        GetComponent<Rigidbody2D>().velocity = dir * speed;
    }
}
  
    // Update is called once per frame
  

}
