using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class ProjectileMotion : MonoBehaviour
{
    private GameObject projectile1;
    private Rigidbody projectileRb;
    [SerializeField] private bool airResistanceOn;

    private Vector3 initialVelocity;
    private Vector3 acceleration;
    private float mass;

    private bool reset = true;
    private bool inMotion = false;


    private Vector3 initialPosition;
    private Quaternion initialRotation;






    // Start is called before the first frame update
    void Start()
    {
        // set initial position of the projectile
        projectile1 = GameObject.FindWithTag("projectile");
        projectileRb = projectile1.GetComponent<Rigidbody>();
        initialRotation = projectileRb.rotation;
        projectileRb.useGravity = false;
        initialPosition = projectile1.transform.position;
        GameControl.control.veryInitialPosition = initialPosition;
        GameControl.control.initialPosition = initialPosition;
        mass = projectileRb.mass;
    }

    // Update is called once per frame
    void Update()
    {
        // as soon as the user hits the space bar this will allow the fireprojectile function to be triggered
        if (Input.GetKeyDown(KeyCode.Space) && reset == true)
        {
            inMotion = true;
            reset = false;
            projectileRb.isKinematic = false;
            initialVelocity = GameControl.control.initialVelocity;
            acceleration = GameControl.control.acceleration;
            projectileRb.velocity = initialVelocity;
        }

        // when R is pressed the projectile is reset.
        if (Input.GetKeyDown(KeyCode.R) && reset == false)
        {
            ResetProjectile();
        }

        if (inMotion == true)
        {
            projectileRb.AddForce(acceleration * mass, ForceMode.Force);
        }

    }

    private void ResetProjectile()
    {
        projectileRb.velocity = Vector3.zero;
        projectileRb.angularVelocity = Vector3.zero;
        projectileRb.isKinematic = true;
        projectile1.transform.position = GameControl.control.initialPosition;
        reset = true;
        inMotion = false;
        Debug.Log("reset");
    }

}
