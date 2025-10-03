using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(AudioSource))]
public class Brick : MonoBehaviour
{
    [Header("Refs")]
    public GameObject coinPrefab;      
    public Transform spawnPoint;        
    public Sprite usedBrickSprite;       
    public Collider2D headHitTrigger;  

    [Header("Config")]
    public bool canSpawnCoin = true;     

    [Header("Audio")]
    public AudioClip hitSfx;            
    public AudioClip coinSfx;         

    [Header("Coin Motion")]
    public float coinPopHeight = 1.0f;
    public float coinPopUpSpeed = 6.0f;
    public float coinFallSpeed = 8.0f;

    [Header("Brick Bounce")]
    public float bounceHeight = 0.12f;
    public float bounceSpeed = 14f;

    private SpriteRenderer sr;
    private AudioSource audioSrc;
    private bool used = false;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        audioSrc = GetComponent<AudioSource>();
    }

    public void Activate()
    {
        if (used) return;
        used = true;

  
        if (hitSfx && audioSrc) audioSrc.PlayOneShot(hitSfx);

        if (usedBrickSprite) sr.sprite = usedBrickSprite;

        if (headHitTrigger) headHitTrigger.enabled = false;


        StartCoroutine(BounceRoutine());

        // 50/50 coin spawn if allowed
        if (canSpawnCoin && Random.value < 0.5f)
        {
            StartCoroutine(SpawnCoinRoutine());
        }
    }

    private IEnumerator SpawnCoinRoutine()
    {
        Vector3 basePos = spawnPoint ? spawnPoint.position
                                     : (transform.position + Vector3.up * 0.5f);

        GameObject coin = Instantiate(coinPrefab, basePos, Quaternion.identity);

        if (coinSfx && audioSrc) audioSrc.PlayOneShot(coinSfx);

        Vector3 upTarget = basePos + Vector3.up * coinPopHeight;
        while ((coin.transform.position - upTarget).sqrMagnitude > 0.0001f)
        {
            coin.transform.position = Vector3.MoveTowards(
                coin.transform.position, upTarget, coinPopUpSpeed * Time.deltaTime);
            yield return null;
        }

        while ((coin.transform.position - basePos).sqrMagnitude > 0.0001f)
        {
            coin.transform.position = Vector3.MoveTowards(
                coin.transform.position, basePos, coinFallSpeed * Time.deltaTime);
            yield return null;
        }

        Destroy(coin);
    }

    private IEnumerator BounceRoutine()
    {
        Vector3 start = transform.localPosition;
        Vector3 peak = start + Vector3.up * bounceHeight;

        while ((transform.localPosition - peak).sqrMagnitude > 0.00001f)
        {
            transform.localPosition = Vector3.MoveTowards(
                transform.localPosition, peak, bounceSpeed * Time.deltaTime);
            yield return null;
        }

        while ((transform.localPosition - start).sqrMagnitude > 0.00001f)
        {
            transform.localPosition = Vector3.MoveTowards(
                transform.localPosition, start, bounceSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
