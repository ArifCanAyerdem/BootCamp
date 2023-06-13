using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floater : MonoBehaviour
{
    public Rigidbody rigidBody;

    public float depthBeforeSubmerged = 1f;

    public float displacementAmount = 3f;
    public int floaterCount = 1;
    public float waterDrag = 0.99f;
    public float waterAngularDrag = 0.5f;


    private void FixedUpdate()
    {
        rigidBody.AddForceAtPosition(Physics.gravity/floaterCount,transform.position,ForceMode.Acceleration);

        float waveHeight = WaveManager.instance.GetWaveHeight(transform.position.x);
        if (transform.position.y<waveHeight)
        {
            float displacementMultipler = Mathf.Clamp01((waveHeight-transform.position.y) / depthBeforeSubmerged) * displacementAmount;

            rigidBody.AddForceAtPosition(new Vector3(0f, Mathf.Abs(Physics.gravity.y) * displacementMultipler, 0f),transform.position, ForceMode.Acceleration);

            rigidBody.AddForce(displacementMultipler * -rigidBody.velocity * waterDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
            rigidBody.AddTorque(displacementMultipler * -rigidBody.angularVelocity * waterAngularDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
        }


    }



}
