using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
  public object GameOverScene;

  private void OnTriggerEnter2D(Collider2D collision)
  {
    SceneManager.LoadScene("Game Over");
  }
}
