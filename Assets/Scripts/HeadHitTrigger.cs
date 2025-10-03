using UnityEngine;

public class HeadHitTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        // Only trigger if Mario is moving upward
        Rigidbody2D rb = other.attachedRigidbody;
        if (rb != null && rb.linearVelocity.y > 0.1f)
        {
            GetComponentInParent<QuestionBox>()?.Activate();
        }
    }
}
