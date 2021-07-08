using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    private void Start()
    {
        offset = new Vector3(0f, 3.75f, 20f);
    }
    // Update is called once per frame
    void Update(){
        transform.position = target.position + offset;
        Debug.Log(target.position);
    }
}
