using UnityEngine;

public class TargetFollow : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField] private Transform target;

    void Start()
    {
        transform.localPosition = target.localPosition + offset;
    }

    void LateUpdate()
    {
        UpdatePosition();
    }

    [ContextMenu("Update Position")]
    public void UpdatePosition()
    {
        transform.localPosition = target.localPosition + offset;
    }

}
