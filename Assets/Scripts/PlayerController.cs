using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Animator animator;
    private HealthController enemy;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                agent.SetDestination(hit.point);

                if (hit.collider.CompareTag("Interactable"))
                    StartCoroutine(Interact(hit.transform.GetComponent<IInteractable>()));

                if (hit.collider.CompareTag("Enemy"))
                {
                    enemy = hit.transform.GetComponent<HealthController>();
                    StartCoroutine(AttackEnemy());
                }
            }
        }
    }

    IEnumerator Interact(IInteractable interactable)
    {
        Debug.Log("Interaction queued");
        yield return null;
        yield return new WaitUntil(() => agent.remainingDistance < 1f);
        interactable.Interact();
        agent.SetDestination(transform.position);
    }

    IEnumerator AttackEnemy()
    {
        Debug.Log("Attacking enemy");
        yield return null;
        yield return new WaitUntil(() => agent.remainingDistance < 5f);
        agent.SetDestination(transform.position);
        animator.SetBool("attacking", true);

        while (enemy != null)
        {
            enemy.TakeDamage(1);
            yield return new WaitForSeconds(0.2f);
        }

        animator.SetBool("attacking", false);
    }

    private void LateUpdate()
    {
        animator.SetBool("walking", agent.remainingDistance > 1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            Debug.Log("Picked up <color=green> 1</color> coin");
            Destroy(other.gameObject);
        }
    }
}
