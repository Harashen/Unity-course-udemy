using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameSession : MonoBehaviour
{
  [Range(0, 5)] [SerializeField] float gameSpeed = 1f;
  [SerializeField] int currentScore = 0;
  [SerializeField] int pointsPerBlock = 42;
  [SerializeField] TextMeshProUGUI scoreText;
  [SerializeField] bool isAutoPlayEnabled;

  private void Awake()
  {
    int gameStatusCount = FindObjectsOfType<GameSession>().Length;

    if (gameStatusCount > 1)
    {
      gameObject.SetActive(false);
      Destroy(gameObject);
    }
    else
    {
      DontDestroyOnLoad(gameObject);
    }
  }

  void Start()
  {
    scoreText.text = currentScore.ToString();  
  }

  // Update is called once per frame
  void Update()
  {
    Time.timeScale = gameSpeed;
  }

  public void AddToScore()
  {
    currentScore += pointsPerBlock;

    scoreText.text = currentScore.ToString();
  }

  public void ResetGame()
  {
    gameObject.SetActive(false);
    Destroy(gameObject);
  }

  public bool IsAutoPlayEnabled()
  {
    return isAutoPlayEnabled;
  }
}
