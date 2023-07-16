using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PaddleController : MonoBehaviour
{
    public KeyCode input;
    private HingeJoint hingejoint;
    private float springpower;
    private float targetpressed;
    private float targetrelease;
    // Start is called before the first frame update
    void Start()
    {
        hingejoint = GetComponent<HingeJoint>();
        targetpressed = hingejoint.limits.max;
        targetrelease = hingejoint.limits.min;
    }

    // Update is called once per frame
    void Update()
    {
        ReadInput();
        MovePaddle();
    }

    

    private void ReadInput()
    {
        JointSpring jointspring = hingejoint.spring;
        hingejoint.spring = jointspring;


        //read input here
        if (Input.GetKey(input))
        {
            jointspring.targetPosition = targetpressed;
        }
        else
        {
            jointspring.targetPosition = targetrelease;
        }

        hingejoint.spring = jointspring;
    }

    private void MovePaddle()
    {
        //move paddle here
        
    }
}
