using UnityEngine;

public class WATER : MonoBehaviour
{
    public float speed = 40.0f;


    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
