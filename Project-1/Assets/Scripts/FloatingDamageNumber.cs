using UnityEngine;
using TMPro;

public class FloatingDamageNumber : MonoBehaviour
{
    public float floatSpeed = 1f;
    public float fadeTime = 1f;

    private TextMeshProUGUI text;
    private Color startColor;
    private float timer;

    void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
        startColor = text.color;
    }

    public void SetDamage(int damage)
    {
        text.text = damage.ToString();
    }

    void Update()
    {
        transform.position += Vector3.up * floatSpeed * Time.deltaTime;

        timer += Time.deltaTime;
        float alpha = Mathf.Lerp(1f, 0f, timer / fadeTime);
        text.color = new Color(startColor.r, startColor.g, startColor.b, alpha);

        if (timer >= fadeTime)
        {
            Destroy(gameObject);
        }
    }
}
