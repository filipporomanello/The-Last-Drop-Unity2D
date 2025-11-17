using UnityEngine;

/// <summary>
/// Manages package pickup and delivery mechanics.
/// </summary>
public class Delivery : MonoBehaviour
{
    bool hasPackage;
    [SerializeField] float destroyDelay = 0.2f;

    /// <summary>
    /// Handles package pickup and delivery interactions.
    /// </summary>
    /// <param name="collision">The collider that triggered the collision.</param>
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Package") && !hasPackage)
        {
            hasPackage = true;
            GetComponent<ParticleSystem>().Play();
            Destroy(collision.gameObject, destroyDelay);
        }

        if (collision.CompareTag("Customer") && hasPackage)
        {
            hasPackage = false;
            GetComponent<ParticleSystem>().Stop();
            Destroy(collision.gameObject, destroyDelay);
        }
    }
}
