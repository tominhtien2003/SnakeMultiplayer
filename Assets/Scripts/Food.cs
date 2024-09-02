using Unity.Netcode;
using UnityEngine;

public class Food : NetworkBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger");
        if (!NetworkManager.Singleton.IsServer) return;
        if (!other.CompareTag("Player")) return;
        if (other.TryGetComponent(out PlayerGrown playerGrown))
        {
            playerGrown.AddLenght();
        }
        else if (other.TryGetComponent(out Tail tail))
        {
            tail.networkOwner.GetComponent<PlayerGrown>().AddLenght();
        }
        GetComponent<Collider2D>().enabled = false;
        //Destroy(gameObject);
        //NetworkObject.Despawn();
    }
}
