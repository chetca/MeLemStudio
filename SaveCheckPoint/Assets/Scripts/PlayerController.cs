{jusing UnityEngine;
using System;
/// <summary>
/// Simple player controller based on a Rigidbody
/// </summary>

public class PlayerController : MonoBehaviour
{
    #region Public Variables

    public float Speed = 8.0F;
    public float JumpForce = 10.0F;

    #endregion

    #region Private Variables

    private Rigidbody thisRigidbody;
    #endregion

    void Start()
    {
        thisRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        thisRigidbody.velocity = new Vector3(Input.GetAxis("Horizontal") * Speed, thisRigidbody.velocity.y, 0);
        if (Input.GetKey(KeyCode.D))
        {
            CameraFollow2D.faceLeft = false;
            thisRigidbody.transform.rotation = Quaternion.Euler(Vector3.zero);
        }
        if (Input.GetKey(KeyCode.A))
        {
            thisRigidbody.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
            CameraFollow2D.faceLeft = true;
        }


    }

    void OnCollisionEnter(Collision collision)
    {


        if (collision.gameObject.tag == "Enemy")
        {
            thisRigidbody.transform.position = CheckPoint.GetActiveCheckPointPosition().result;
        }
    }
}