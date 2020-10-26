using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
  // Config params
  [SerializeField] AudioClip  destroySound;
  [SerializeField] GameObject blockSparklesVFX;
  [SerializeField] Sprite[] hitSprites;

  // Cached reference
  private Level level;

  // State variables
  private int timesHit;

  private void Start()
  {
    timesHit = 0;
    CountBreakableBlocks();
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    if (CompareTag("Breakable block"))
    {
      HandleHit();
    }
  }

  private void HandleHit()
  {
    int maxHits = hitSprites.Length + 1;

    ++timesHit;

    if (timesHit >= maxHits)
      DestroyBlock();
    else
      ShowNextHitSprites();
  }

  private void ShowNextHitSprites()
  {
    int spriteIndex = timesHit - 1;

    if (hitSprites[spriteIndex] != null)
      GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
    else
      Debug.LogError("Block Sprite is missing rom array " + gameObject.name);
  }

  private void DestroyBlock()
  {    
    PlayBlockDestroySFX();
    Destroy(gameObject);
    level.BlockDestroyed();
    TriggerSparklesVFX();
  }

  private void CountBreakableBlocks()
  {
    if (CompareTag("Breakable block"))
    {
      level = FindObjectOfType<Level>();

      level.CountBreakableBlocks();
    }
  }

  private void PlayBlockDestroySFX()
  {
    FindObjectOfType<GameSession>().AddToScore();

    AudioSource.PlayClipAtPoint(destroySound, Camera.main.transform.position);
  }

  private void TriggerSparklesVFX()
  {
    GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);  

    Destroy(sparkles, 1f);
  }
}
