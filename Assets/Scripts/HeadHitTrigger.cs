using UnityEngine;

public class HeadHitTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        // Only trigger if Mario is moving upward
        var rb = other.attachedRigidbody;
        if (rb == null || rb.linearVelocity.y <= 0.1f) return;

        // Try QuestionBox first, then Brick
        var qb = GetComponentInParent<QuestionBox>();
        if (qb != null) { qb.Activate(); return; }

        var brick = GetComponentInParent<Brick>();
        if (brick != null) { brick.Activate(); }
    }
}
