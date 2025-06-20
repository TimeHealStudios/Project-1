using UnityEngine;

public class RifleProjectile : MonoBehaviour
{
    public float speed = 20f;
    public float lifeTime = 3f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
