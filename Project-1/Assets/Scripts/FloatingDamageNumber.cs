using TMPro;
using UnityEngine;

public class FloatingDamageNumber : MonoBehaviour
{
    private TextMeshProUGUI text;
    private Color startColor;
    private float disappearTimer = 1f;
    private float disappearSpeed = 3f;
    private float floatSpeed = 1.5f;

    private Transform mainCamera;

    void Awake()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        if (text != null)
        {
            startColor = text.color;
        }
        else
        {
            Debug.LogWarning("No TextMeshProUGUI found on FloatingDamageNumber!");
        }

        if (Camera.main != null)
        {
            mainCamera = Camera.main.transform;
        }
        else
        {
            Debug.LogWarning("No Main Camera found! Make sure your camera has the 'MainCamera' tag.");
        }
    }

    void Update()
    {
        // Float upward
        transform.position += Vector3.up * floatSpeed * Time.deltaTime;

        // Billboard properly
        if (mainCamera != null)
        {
            Vector3 direction = transform.position - mainCamera.position;
            direction.y = 0; // Optional: keeps it upright
            transform.forward = direction.normalized;
        }

        // Fade out
        disappearTimer -= Time.deltaTime;
        if (disappearTimer <= 0f && text != null)
        {
            Color color = text.color;
            color.a = Mathf.MoveTowards(color.a, 0, disappearSpeed * Time.deltaTime);
            text.color = color;

            if (color.a <= 0f)
            {
                Destroy(gameObject);
            }
        }
    }

    public void SetDamage(int damage)
    {
        if (text != null)
        {
            text.text = damage.ToString();
            text.color = startColor;  // Reset color
        }
    }
}
