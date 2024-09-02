using System.Collections.Generic;
using Unity.Netcode;
using UnityEditor;
using UnityEngine;

public class PlayerGrown : NetworkBehaviour
{
    [SerializeField] GameObject tailPrefab;
    private NetworkVariable<ushort> lenght = new(1, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Server);
    private Transform lastTail;
    private List<GameObject> tailList;
    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        tailList = new List<GameObject>();
        lastTail = transform;
        if (IsServer)
        {
            lenght.OnValueChanged += Length_OnValueChanged;
        }
    }
    private void Start()
    {

    }
    private void Length_OnValueChanged(ushort pre, ushort cur)
    {
        Debug.Log("Event");
        InstantiateTail();
    }
    [ContextMenu("AddLength")]
    public void AddLenght()
    {
        lenght.Value++;
        //InstantiateTail();
    }
    private void InstantiateTail()
    {
        Debug.Log(lastTail!=null);
        GameObject tailObject = Instantiate(tailPrefab, lastTail.position, Quaternion.identity);
        tailObject.transform.parent = transform;
        tailObject.GetComponent<SpriteRenderer>().sortingOrder = -lenght.Value;
        if (tailObject.TryGetComponent(out Tail tail))
        {
            tail.followTransform = lastTail.transform;
            tail.networkOwner = transform;
            lastTail = tailObject.transform;
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), tailObject.GetComponent<Collider2D>());
        }
        tailList.Add(tailObject);
    }
}
