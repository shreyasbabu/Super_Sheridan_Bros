using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Movement : MonoBehaviour
{
    [SerializeField] float distanceAway = 5.0f;
    [SerializeField] float distanceUp = 2.0f;
    [SerializeField] float smooth = 2.5f;

    private Transform follow;
    private Vector3 targetPos;

    private void Awake()
    {
        follow = GameObject.Find("follow").transform;
    }

    private void LateUpdate()
    {
        cameraMovement();
    }

    void cameraMovement()
    {
        targetPos = (follow.position + follow.up * distanceUp - follow.forward * distanceAway);

        Debug.DrawRay(follow.position, Vector3.up, Color.red);
        Debug.DrawRay(follow.position, (-1f * follow.forward * distanceAway), Color.blue);
        Debug.DrawLine(follow.position, targetPos, Color.green);

        this.transform.position = Vector3.Lerp( this.transform.position, targetPos ,Time.deltaTime * smooth);

        transform.LookAt(follow);
    }

}
