using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class game_manager : MonoBehaviour
{
    // (float, float) x_coords = (-7f, 7f);
    // (float, float) z_coords = (-8f, 8f);

    private float ball_spawn_time; 
    private static int score;
    private float ball_speed; 
    private static int lives;
    private float ball_speed_prev_time;

    //Variables for spawning new balls
    private Vector3 prev_position;
    private Vector3 new_position;
    private int xPos;
    private int zPos;
    private float time_diff;
    private float prev_time;
    public GameObject ball_prefab;

    //Variables for spawning new power-ups
    public GameObject shrink_prefab;
    public GameObject grow_prefab;
    public GameObject bomb_prefab;
    public GameObject speed_prefab;

    //Variables for the UI
    public GameObject endMenuUI;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI lifeText;
    public TextMeshProUGUI endScoreText;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        lives = 10;
        score = 0;
        ball_speed = 2.5f;
        prev_position = new Vector3(0, 9, 0);
        prev_time = 0f;
        ball_speed_prev_time = 0;
        calc_new_ball_pos();
    }

    // Update is called once per frame
    void Update()
    {
        //Shows the Game Over menu, and allow the user to either quit or restart
        if(lives == 0){

            endMenuUI.SetActive(true);
            scoreText.enabled = false;
            lifeText.enabled = false;
            Time.timeScale = 0f;
            endScoreText.text = "SCORE: " + score.ToString();
        }

        scoreText.text = "Score: " + score.ToString();
        lifeText.text = "Lives: " + lives.ToString();
        
        //Every 30 seconds increase ball speed
        if(Time.time - ball_speed_prev_time  >= 30){
            increase_ball_speed();
            ball_speed_prev_time = Time.time;
        }

        if (Time.time - prev_time >= time_diff){
            //One in ten chance of spawning a powerup
            int powerup_int = Random.Range(1,11);
            if(Random.Range(1, 10) == 1) {
                spawn_good_powerup(Random.Range(1,3));
            } else if (powerup_int >= 8) {
                spawn_bad_powerup(Random.Range(1,3));
            } else {
                Instantiate(ball_prefab, new_position, Quaternion.identity);
            }
            prev_time = Time.time;
            calc_new_ball_pos();
        }
    }

    public void calc_new_ball_pos(){
        xPos = Random.Range(-7, 7);
        zPos = Random.Range(-8, 8);
        new_position = new Vector3(xPos, 9, zPos);
        time_diff = Vector3.Distance(prev_position, new_position) / 10f + 0.2f;
        prev_position = new_position;
    }

    public void spawn_good_powerup(int powerup_num){
        if(powerup_num == 1)
        {
            Instantiate(grow_prefab, new_position, Quaternion.identity);
        } else
        {
            Instantiate(speed_prefab, new_position, Quaternion.identity);
        }
    }

    public void spawn_bad_powerup(int powerup_num){
        if(powerup_num == 1)
        {
            Instantiate(bomb_prefab, new_position, Quaternion.identity);
        } else
        {
            Instantiate(shrink_prefab, new_position, Quaternion.identity);
        }
    }

    public int random_negation(){
        float negation = Random.Range(-1, 1);
        if (negation <= 0) {
            return -1;
        } else {
            return 1;
        }
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
        if(ball_speed == 2.5f)
        {
            ball_speed = 3.5f;
        }  
          else if(ball_speed == 3.5)
        {
            ball_speed = 5f;
        } else if (ball_speed == 5)
        {
            ball_speed = 6f;
        } else if (ball_speed == 6){
            ball_speed = 7f;
        } else if (ball_speed == 7){
            ball_speed = 8f;
        } 
        return;
    }

    public void decrease_lives(){
        lives -= 1;
    }

    //restarts the game
    public void RestartGame()
    {
     
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }

    //quits the game
    public void QuitGame()
    {

#if UNITY_EDITOR
            // Application.Quit() does not work in the editor so
            // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif

    }
}
