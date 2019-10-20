using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Movement_Logic : MonoBehaviour
{

    [SerializeField] Animator charAnimator;
    [SerializeField] float dampingTime = 0.25f;

    private float speed = 0.0f;
    private float hori = 0.0f;
    private float vert = 0.0f;

    private void Awake()
    {
        charAnimator = GetComponent<Animator>();

    }

    private void Update()
    {
        characterMovement();
    }


    void characterMovement()
    {

        hori = Input.GetAxis("Horizontal");
        vert = Input.GetAxis("Vertical");

        speed = new Vector2(hori, vert).sqrMagnitude;

        if (charAnimator != null)
        {
            charAnimator.SetFloat("HDirection", hori, dampingTime, Time.deltaTime);
            charAnimator.SetFloat("VDirection", vert, dampingTime, Time.deltaTime);
            charAnimator.SetFloat("Speed", speed);
        }
    }
}
