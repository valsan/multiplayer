using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class Player : MonoBehaviour
{
    [SerializeField] GameObject gun;
    [SerializeField] float speed;
    [SerializeField] float rotSpeed;
    PlayerHealth playerHealth;
    Rigidbody rb;

    PhotonView view;

    Vector3 desiredFacingDirection = Vector3.forward;
    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
        view = GetComponent<PhotonView>();
        rb = GetComponent<Rigidbody>();
        if (view.IsMine)
        {
            Camera.main.GetComponent<CameraController>().SetPlayer(gameObject);
        }

    }
    void Update()
    {
        if (view.IsMine)
        {
            HandleRightClick();
            SmoothlyRotateHead();
        }
    }

    private void FixedUpdate()
    {
        if (view.IsMine)
        {
            HandleMovement();
        }
    }

    void HandleRightClick()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 centerOfScreen = new Vector3(Screen.width / 2, 0, Screen.height / 2);
            Vector3 facingDirection = new Vector3(Input.mousePosition.x, 0, Input.mousePosition.y);
            desiredFacingDirection = (facingDirection - centerOfScreen).normalized;
            gun.GetComponent<Gun>().Shoot();
        }
    }

    void SmoothlyRotateHead()
    {
        Quaternion rotGoal = Quaternion.LookRotation(desiredFacingDirection);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotGoal, rotSpeed * Time.deltaTime);
    }

    void HandleMovement()
    {
        Vector3 movementVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        rb.transform.position += movementVector.normalized * speed * Time.deltaTime;
    }

    private void OnParticleCollision(GameObject other)
    {
        playerHealth.TakeDamage();
    }
}
