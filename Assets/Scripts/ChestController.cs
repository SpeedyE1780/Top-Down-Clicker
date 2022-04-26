using UnityEngine;

public class ChestController : MonoBehaviour, IInteractable
{
    [SerializeField] private Animator animator;
    bool opened;

    private void Start()
    {
        opened = false;
    }

    public void Interact()
    {
        if (opened)
            return;

        opened = true;
        animator.SetTrigger("open");
        int coins = Random.Range(1, 5);
        Debug.Log($"Chest opened received <color=green>{coins}</color> coins");
    }
}
