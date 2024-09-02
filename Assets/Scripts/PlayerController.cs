using Unity.Netcode;
using UnityEngine;

public class PlayerController : NetworkBehaviour
{
    [SerializeField] float moveSpeedPlayer = 3f;
    private void Update()
    {
        HandleMovement();
    }
    private void HandleMovement()
    {
        if (!IsOwner || !Application.isFocused) return;
        Vector3 inputMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        inputMousePosition.z = Camera.main.nearClipPlane;
        transform.position = Vector3.MoveTowards(transform.position, inputMousePosition, moveSpeedPlayer * Time.deltaTime);

        if (inputMousePosition != transform.position)
        {
            Vector2 direction = (inputMousePosition - transform.position).normalized;
            transform.up = Vector3.Lerp(transform.up, direction, Time.deltaTime * 10f);
        }
    }
}
