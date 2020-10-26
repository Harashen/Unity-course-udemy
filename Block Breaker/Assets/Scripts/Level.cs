using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
  private int breakableBlocks;

  public void CountBreakableBlocks()
  {
    breakableBlocks++; 
  }

  public void BlockDestroyed()
  {
    breakableBlocks--; 

    if (breakableBlocks <= 0)
    {
      FindObjectOfType<SceneLoader>().LoadNextScene();
    }
  }
}
