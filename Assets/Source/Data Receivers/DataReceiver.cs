using System;
using UnityEngine;
using UnityEngine.Events;

public abstract class DataReceiver<IT, OT> : MonoBehaviour
{
    [SerializeField] private GithubReaderHolder _githubReaderHolder;
    public UnityEvent<OT> OnDataReceived;
    public UnityEvent<string> OnFailure;
    protected IGithubReader GithubReader { get => _githubReaderHolder.GithubReader; }

    protected abstract Action<IT, Action<OT>, Action<string>> GetRequestMethod();

    public void RequestAndSendData(IT inputData)
    {
        var requestMethod = GetRequestMethod();
        requestMethod(inputData, s => OnDataReceived.Invoke(s), f => OnFailure.Invoke(f));
    }
}
