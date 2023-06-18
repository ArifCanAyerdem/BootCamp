using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float rotationSpeed = 100f;

    private bool isWandering = false;
    private bool isRotatingRight = false;
    private bool isRotatingLeft = false;
    private bool isWalking = false;

    Rigidbody rb;
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(isWandering == false)
        {
            StartCoroutine(Wander());
        }
        if (isRotatingRight == true)
        {
            transform.Rotate(transform.up * Time.deltaTime * rotationSpeed);
        }
        if (isRotatingLeft == true)
        {
            transform.Rotate(transform.up * Time.deltaTime * -rotationSpeed);
        }
        if(isWalking == true)
        {
            rb.AddForce(transform.forward * movementSpeed);
            animator.SetBool("isRunning", true);
            

        }
        if(isWalking == false)
        {
            animator.SetBool("isRunning", false);
        }
    }
    IEnumerator Wander()
    {
        int rotationTime = Random.Range(1, 1);
        int rotateWait = Random.Range(1, 1);
        int rotateDirection = Random.Range(1, 3);
        int walkWait = Random.Range(1, 1);
        int walkTime = Random.Range(1, 3);

        isWandering = true;

        yield return new WaitForSeconds(walkWait);

        isWalking = true;

        yield return new WaitForSeconds(walkTime);

        isWalking = false;

        yield return new WaitForSeconds(rotateWait);

        if (rotateDirection == 1)
        {
            isRotatingLeft = true;
            animator.SetBool("isEating", true);
            yield return new WaitForSeconds(rotationTime);
            isRotatingLeft = false;
            animator.SetBool("isEating", false);
        }
        if (rotateDirection == 2)
        {
            isRotatingRight = true;
            animator.SetBool("Turn Head", true);
            yield return new WaitForSeconds(rotationTime);
            isRotatingRight = false;
            animator.SetBool("Turn Head", false);
        }
        isWandering = false;
    }
}
