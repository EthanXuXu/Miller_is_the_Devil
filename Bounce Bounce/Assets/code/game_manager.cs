using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_manager : MonoBehaviour
{
    (float, float) x_coords = (-7f, 7f);
    (float, float) z_coords = (-8f, 8f);

    private float ball_spawn_time; 
    private static int score;
    private float ball_speed; 
    private static int lives;

    // Start is called before the first frame update
    void Start()
    {
        lives = 10;
        score = 0;
        ball_speed = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        if(lives == 0){
            Application.Quit();
        }
        Debug.Log("Score " + score);
    }

    public void increase_score(){
        score += 1;
    }

    public int get_score(){
        return score;
    }

    public float get_ball_speed(){
        return ball_speed;
    }

    public void increase_ball_speed(){
        return;
    }

    public void decrease_lives(){
        lives -= 1;
    }
}
