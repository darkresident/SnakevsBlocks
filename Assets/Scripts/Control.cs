using UnityEngine;

public class Control : MonoBehaviour
{
    public Rigidbody Rigidbody;
    public Vector3 Force = new Vector3(0, 0, 10);
    public Vector3 SideSpeed = new Vector3(10, 0, 0);

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        Rigidbody.AddForce(Force, ForceMode.VelocityChange);
        float inputX = Input.GetAxis("Horizontal");
        Rigidbody.velocity = new Vector3(SideSpeed.x * inputX, 0, 0);
    }
}