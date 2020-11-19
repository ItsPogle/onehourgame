using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float nextTimeToAttack;
    public float attackspeed = 1.2f;
    Vector3 moveInput;
    Vector3 moveVelocity;
    Vector3 pointToLook;
    Rigidbody rbody;
    public float moveSpeed = 4f;
    public Transform firepoint;
    public GameObject projectile;

    private void Awake()
    {
        rbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput * moveSpeed;

        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if(groundPlane.Raycast(cameraRay, out rayLength))
        {
            pointToLook = cameraRay.GetPoint(rayLength);
            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }

        if(Input.GetKey(KeyCode.Mouse0) && Time.time >= nextTimeToAttack)
        {
            float f = Random.Range(0.8f, 1f);
            GameManager.instance.AS.pitch = f;
            GameManager.instance.AS.PlayOneShot(GameManager.instance.hitmark, f);
            GameObject GO = Instantiate(projectile, firepoint.position, Quaternion.identity);
            GO.transform.GetComponent<Rigidbody>().AddForce(transform.forward * 50, ForceMode.Impulse);
            nextTimeToAttack = Time.time + 1f / attackspeed;
        }
    }

    private void FixedUpdate()
    {
        rbody.velocity = moveVelocity;
    }


}
