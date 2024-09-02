using Unity.Netcode;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public void ButtonHost()
    {
        NetworkManager.Singleton.StartHost();
    }
    public void ButtonClient()
    {
        NetworkManager.Singleton.StartClient();
    }
    public void ButtonServer()
    {
        NetworkManager.Singleton.StartServer();
    }
}
