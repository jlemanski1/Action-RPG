using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour {

    Transform target;       //Target to follow
    NavMeshAgent agent;     //Player agent

    private int rotationSpeed = 5;

	
	void Start ()
    {
        agent = GetComponent<NavMeshAgent>();
	}
	
	
	void Update ()
    {
        if (target != null)
        {
            //Move to & face target
            agent.SetDestination(target.position);
            FaceTarget();
        }
	}

    #region Movement Logic

    //Move to new point
    public void MoveToPoint(Vector3 point)
    {
        agent.SetDestination(point);
    }

    //Follow target / Move to Interactable object
    public void FollowTarget(Interactable newTarget)
    {
        agent.stoppingDistance = newTarget.radius * 0.8f;   //0.8f buffer distance to stop from getting too close
        agent.updateRotation = false;

        target = newTarget.interactionTransform;
    }

    //Stop Moving toward target
    public void StopFollowingTarget()
    {
        agent.stoppingDistance = 0;
        agent.updateRotation = true;

        target = null;
    }

    //Turn to face the target
    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }

    #endregion

}
