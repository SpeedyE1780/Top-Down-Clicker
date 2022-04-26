using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField] private int health;

    public void TakeDamage(int damage)
    {
        health -= damage;

        Debug.Log($"{gameObject.name} took <color=red>{damage}</color> damage");
        
        if(health < 0)
            Destroy(gameObject);
    }

}
