using UnityEngine;

public class fpsViewModel : MonoBehaviour
{
    public Transform vm;
    public Vector3 localPositionOffset = new Vector3(0, -1.8f, 0.4f); // tweak if you want
    public Vector3 localRotationOffset = new Vector3(-8, 0, 0); // also tweak if you want

    void Start()
    {
        // parents the item to the camera
        vm.SetParent(Camera.main.transform);

        // sets the local position and rotation offsets
        vm.localPosition = localPositionOffset;
        vm.localRotation = Quaternion.Euler(localRotationOffset);

    }
    void Update()
    {
        
    }
}
