using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] CharacterController controller;

    [SerializeField] float playerSpeed;
    [SerializeField] float sprintMod;
    [SerializeField] float jumpHeight;
    [SerializeField] float gravityValue;
    [SerializeField] int jumpsMax;
    //[SerializeField] float shootRate;
    //[SerializeField] int shootDist;
    //[SerializeField] int shootDamage;

    Vector3 move;
    private Vector3 playerVelocity;
    int jumpTimes;
    bool isSprinting;
    //bool isShooting;
    float playerspeedOrig;

    private void Start()
    {
        playerspeedOrig = playerSpeed;
    }
    void Update()
    {
        Movement();
        Sprint();
        //StartCoroutine(shoot());
    }

    void Movement()
    {
        if (controller.isGrounded && playerVelocity.y < 0)
        {
            jumpTimes = 0;
            playerVelocity.y = 0f;
        }

        move = transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical");
        controller.Move(move * Time.deltaTime * playerSpeed);


        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && jumpTimes < jumpsMax)
        {
            jumpTimes++;
            playerVelocity.y = jumpHeight;
        }

        playerVelocity.y -= gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    void Sprint()
    {
        if (Input.GetButtonDown("Sprint"))
        {
            playerSpeed *= sprintMod;
            isSprinting = true;
        }
        else if (Input.GetButtonUp("Sprint"))
        {
            playerSpeed /= sprintMod;
            isSprinting = false;
        }
    }
    //IEnumerator shoot()
    //{
    //    if (!isShooting && Input.GetButton("Shoot"))
    //    {
    //        isShooting = true;
    //        RaycastHit hit;
    //        if (Physics.Raycast(Camera.main.ViewportPointToRay(new Vector2(0.5f, 0.5f)), out hit, shootDist))
    //        {
               
    //        }
    //        yield return new WaitForSeconds(shootRate);
    //        isShooting = false;
    //    }
    //}
}
