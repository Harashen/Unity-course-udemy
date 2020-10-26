using UnityEngine;

public class Ball : MonoBehaviour
{
  // Config params
  [SerializeField] Paddle paddle;
  [SerializeField] float  xPush = 2f;
  [SerializeField] float  yPush = 15f;
  [SerializeField] AudioClip[] ballSounds;
  [SerializeField] float randomFactor = 0.2f;

  private Vector2 ballPaddleOffset;
  private bool    isLaunched;
 
  // Cached component references
  AudioSource myAudioSource;
  Rigidbody2D myRigidbody2D;

  // Start is called before the first frame update
  void Start()
  {
    ballPaddleOffset = transform.position - paddle.transform.position;
    isLaunched       = false;
    myAudioSource    = GetComponent<AudioSource>();
    myRigidbody2D    = GetComponent<Rigidbody2D>();
  }

  // Update is called once per frame
  void Update()
  {
    if (isLaunched == false)
    {
      LockBallToPaddle();
      LaunchOnMouseClick();
    }
  }
  
  private void LaunchOnMouseClick()
  {
    if (Input.GetMouseButtonDown(0))
    {
      isLaunched = true;

      myRigidbody2D.velocity = new Vector2(xPush, yPush);
    }
  }

  private void LockBallToPaddle()
  {
    Vector2 paddlePos  = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
    transform.position = paddlePos + ballPaddleOffset;
  }
  
  private void OnCollisionEnter2D(Collision2D collision)
  {
    Vector2 velocityTweak = new Vector2(Random.Range(0f, randomFactor), Random.Range(0f, randomFactor));

    if (isLaunched)
    {
      AudioClip clip = ballSounds[Random.Range(0, ballSounds.Length)];

      myAudioSource.PlayOneShot(clip);

      myRigidbody2D.velocity += velocityTweak;
    }
  }
}
