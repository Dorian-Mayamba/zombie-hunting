using UnityEngine;
using UnityEngine.AI;

public class EnnemyMovement : MonoBehaviour
{


    [SerializeField] private float lookRadius = 10f;

    Transform target;

    [SerializeField] private LayerMask playerLayer, groundLayer;

    //Patrol
    private Vector3 destPoint;
    private bool walkPointSet;
    [SerializeField] private float walkRange;

    NavMeshAgent agent;

    //State change
    [SerializeField] private float sightRange, attackRange;

    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private Transform bulletPoint;

    private Rigidbody rb;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        rb = bullet.GetComponent<Rigidbody>();
        target = PlayerController.GetInstance().playerInstance.transform;
        
        if(target !=null)
            Debug.Log("player target found");
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);
        if(distance <= lookRadius)
        {
            Chase();
            if(distance <= agent.stoppingDistance)
            {
                AttackPlayer();
            }
        }else{
            Patrol();
        }
    }

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        
    }

    private void Patrol()
    {
        Debug.Log("Patroling");
        if(!walkPointSet)
        {
            SearchDest();
        }

        if(walkPointSet && agent.isActiveAndEnabled) agent.SetDestination(destPoint);
        if(Vector3.Distance(transform.position, destPoint) < 10) walkPointSet = false;

    }

    private void Chase()
    {
        Debug.Log("Chasing player");
        agent.SetDestination(target.position);
    }

    private void AttackPlayer()
    {
        Debug.Log("Attacking player");
        FaceTarget();
        GameObject go = Instantiate(bullet, bulletPoint.position, transform.rotation);
        rb.AddForce(transform.forward * 800);
        Destroy(go, 1);
        //Handle attack animation
    }
    private void SearchDest()
    {
        float randomZ = Random.Range(-walkRange, walkRange);
        float randomX = Random.Range(-walkRange, walkRange);

        destPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if(Physics.Raycast(destPoint, Vector3.down, groundLayer))
        {
            walkPointSet = true;
        }
    }

    public void FaceTarget()
    {
        transform.LookAt(target);
    }


}
