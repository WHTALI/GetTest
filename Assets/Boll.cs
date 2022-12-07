using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Boll : MonoBehaviour
{

    TextMeshProUGUI scoreText;

    Vector3 dir;

    int player1Goal=0;
    int player2Goal=0;

    float speed;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = FindObjectOfType<TextMeshProUGUI>();
        ResetBall();
    }


    private void ResetBall()
    {

        scoreText.text = player1Goal + "-" + player2Goal;
            transform.position = new Vector3(0, 0, 0);
            int x = Random.Range(0, 2);
            if (x == 0)
            {
                x = -1;
            }
            dir = new Vector3(x, Random.Range(-1, 2), 0);
        

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        

        if(collision.gameObject.tag=="Player")
        {
            speed*=1.2f;
            if(speed<12)
            {
                speed = 12;
            }

            dir.x *= -1;
        }
        else
        {
            dir.y *= -1;
        }

        
    }


    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetBall();
        }
            transform.position += dir *7* Time.deltaTime;
        if(transform.position.x>12)
        {
            player1Goal += 1;
            print("spelare 1 mål");
            ResetBall();
        }else if(transform.position.x<-12)
        {
            player2Goal += 1;
            print("Spelare 2 mål");
            ResetBall();
        }
    }
}
