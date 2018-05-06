using UnityEngine;
using UnityEngine.AI;

public class CharacterAnimator : MonoBehaviour {

    const float locomotionSmoothTime = .1f;     //Dampening between animations

    NavMeshAgent agent;
    Animator animator;

	void Start ()
    {
        //Set up agent & animator
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
	}
	

	void Update ()
    {
        //Blend between animations
        float speedPercent = agent.velocity.magnitude / agent.speed;
        animator.SetFloat("speedPercent", speedPercent, locomotionSmoothTime, Time.deltaTime);
	}
}
