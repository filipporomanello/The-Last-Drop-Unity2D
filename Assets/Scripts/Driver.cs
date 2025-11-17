using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

/// <summary>
/// Controls player movement and speed based on keyboard input and collisions.
/// </summary>
public class Driver : MonoBehaviour
{
    [SerializeField] float currentSpeed = 7f;
    [SerializeField] float steerSpeed = 180f;
    [SerializeField] float boostSpeed = 10f;
    [SerializeField] float regularSpeed = 7f;
    [SerializeField] TMP_Text boostText;

    /// <summary>
    /// Initializes the driver by hiding the boost text.
    /// </summary>
    void Start()
    {
        boostText.gameObject.SetActive(false);
    }

    /// <summary>
    /// Handles trigger collisions with boost pickups.
    /// </summary>
    /// <param name="collision">The collider that triggered the collision.</param>
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boost"))
        {
            currentSpeed = boostSpeed;
            boostText.gameObject.SetActive(true);
            Destroy(collision.gameObject);
        }
    }

    /// <summary>
    /// Handles collisions with world objects to reset speed.
    /// </summary>
    /// <param name="collision">The collision data.</param>
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("World Collision"))
        {
            currentSpeed = regularSpeed;
            boostText.gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// Handles player input and updates position and rotation each frame.
    /// </summary>
    void Update()
    {
        float move = 0f;
        float steer = 0f;

        if (Keyboard.current.wKey.isPressed)
        {
            move = 1f;
        }
        else if (Keyboard.current.sKey.isPressed)
        {
            move = -1f;
        }

        if (Keyboard.current.aKey.isPressed)
        {
            steer = 1f;
        }
        else if (Keyboard.current.dKey.isPressed)
        {
            steer = -1f;
        }

        float moveAmount = move * currentSpeed * Time.deltaTime;
        float steerAmount = steer * steerSpeed * Time.deltaTime;
        transform.Translate(0, moveAmount, 0);
        transform.Rotate(0, 0, steerAmount);
    }
}
