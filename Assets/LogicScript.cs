using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    int playerScore = 0;
    public Text scoreCounter;
    public GameObject gameOverScreen;
    public bool isRunning = true;

    public AudioClip PointSFX;
    public AudioClip gameOverSFX;
    public AudioSource SFX;
    
    public ParticleSystem Clouds;

    void Start() {
        gameOverScreen.SetActive(false);
        Clouds.Play();
    }


    [ContextMenu("Add Score")]
    public void addPlayerScore(){
        playerScore += 1;
        scoreCounter.text = playerScore.ToString();
        SFX.PlayOneShot(PointSFX);
    }

    public void resetLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver(){
        gameOverScreen.SetActive(true);
        isRunning = false;
        SFX.PlayOneShot(gameOverSFX);
        Clouds.Pause();

    }
}
