using UnityEngine;

public class stupid : MonoBehaviour
{
    public Transform campos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = campos.position;
    }
}
