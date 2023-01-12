using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

public abstract class DataReceiver<T> : MonoBehaviour
{
    [SerializeField] protected GithubReader githubReader;
    public UnityEvent<T> OnDataReceived;

    protected abstract Task<T> Receive();

    public async void ReceiveAndTransfer()
    {
        T data = await Receive();
        if (data != null) OnDataReceived.Invoke(data);
    }
}
