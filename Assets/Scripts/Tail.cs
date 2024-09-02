using UnityEngine;

public class Tail : MonoBehaviour
{
    public Transform followTransform;
    public Transform networkOwner;
    [SerializeField] float distance = .3f;

    private Vector3 targetPosition;

    private void Update()
    {
        if (followTransform == null || networkOwner == null) return;
        targetPosition = followTransform.position - followTransform.forward * distance;

        targetPosition.z = 0f;
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 10f);
    }
}
