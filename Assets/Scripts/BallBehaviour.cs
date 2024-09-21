using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;
using UnityEngine.UI;

public class BallBehaviour : MonoBehaviour
{
   Rigidbody rb;
   [SerializeField] private float UpSpeed;
   [SerializeField] private GameObject gameOverPanel;
   [SerializeField] private GameObject congratsPanel;
   [SerializeField] private GameObject congratsPanel2;
   [SerializeField] private GameObject splash;
   [SerializeField] private TextMeshProUGUI scoreText;
   [SerializeField] private GameObject playUI;
   [SerializeField] private AudioSource failEffect;
   [SerializeField] private AudioSource passedEffect;
   [SerializeField] private AudioSource wonEffect;
   [SerializeField] private AudioSource bounceEffect;


   private int score = 0;
   public delegate void NextLevel();
   public static NextLevel OnNextLevel;
   
   private void Awake()
{
  rb = GetComponent<Rigidbody>();
  score = 0;
}
public void OnTriggerEnter(Collider collision)
{
    if (collision.gameObject.tag== "Pass")
    {
        Debug.Log("piles passed");
        score++;
        scoreText.text = score.ToString();
        passedEffect.Play();
    }
}

public void OnCollisionEnter(Collision collision)
{
    if(collision.gameObject.tag =="FriendTiles")
    {
      rb.AddForce(Vector3.up * UpSpeed ,ForceMode.Impulse);
      Debug.Log("collision has occured");
      bounceEffect.Play();
    }

    if (collision.gameObject.tag=="EnemyTile")
    {
        gameOverPanel.SetActive(true);
        playUI.SetActive(false);
        Time.timeScale = 0;
        failEffect.Play();
    }

    if (collision.gameObject.tag== "FinishTile")
    {
        Debug.Log("Level 1 is finished");
        congratsPanel.SetActive(true);
        playUI.SetActive(false);
        wonEffect.Play();
        Time.timeScale = 0;
    }

    if (collision.gameObject.tag== "SecondFinish")
    {
        Debug.Log("Level 2 is finished");
        playUI.SetActive(false);
        congratsPanel2.SetActive(true);
        wonEffect.Play();
    }
}


}
