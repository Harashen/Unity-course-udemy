using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Paddle : MonoBehaviour
{
  // Configuration parameters
  private const float minX = 1f;
  private const float maxX = 15f;

  [SerializeField] float screenWidthUnits = 16f;

  // Cached component references
  GameSession theGameSession;
  Ball        theBall;

  // Start is called before the first frame update
  void Start()
  {
    theGameSession = FindObjectOfType<GameSession>();
    theBall        = FindObjectOfType<Ball>();
  }

  // Update is called once per frame
  void Update()
  {  
    Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);

    paddlePos.x = Mathf.Clamp(GetXPos(), minX, maxX); 

    transform.position = paddlePos;
  }

  private float GetXPos()
  {
    if (theGameSession.IsAutoPlayEnabled())
      return theBall.transform.position.x;
    else
      return Input.mousePosition.x / Screen.width * screenWidthUnits;
  }
}
