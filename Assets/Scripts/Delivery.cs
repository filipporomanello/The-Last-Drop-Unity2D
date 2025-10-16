using UnityEngine;
public class Delivery : MonoBehaviour
{
    bool hasPackage;
    [SerializeField] float destroyDelay = 0.2f;
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
