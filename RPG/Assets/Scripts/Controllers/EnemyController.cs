using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 10f;

    Transform target;
    NavMeshAgent agent;
    CharacterCombat combat;

	void Start ()
	{
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        combat = GetComponent<CharacterCombat>();
	}
	
	void Update ()
	{
        //Check distance to target
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            //If withing look radius set destination to target's position
            agent.SetDestination(target.position);

            if (distance <= agent.stoppingDistance)
            {
                //Attack the target
                CharacterStats targetStats = target.GetComponent<CharacterStats>();
                if (targetStats != null)
                {
                    combat.Attack(targetStats);
                }
                
                FaceTarget();   //Stay facing the target while in sight
            }
        }
	}

    //Face towards target
    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position.normalized);
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
