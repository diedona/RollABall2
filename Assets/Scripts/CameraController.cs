using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector3 offsetPosition;
    public float rotationSpeed;

    public GameObject objectToFollow;

    public void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        //if (Input.GetButton("Jump"))
        //{
        //    this.transform.rotation = Quaternion.Euler(0, 17, 0);
        //}

        transform.position = this.objectToFollow.transform.TransformPoint(this.offsetPosition);
        transform.LookAt(this.objectToFollow.transform);
    }
}
