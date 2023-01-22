using UnityEngine;

public class GithubReaderHolder : MonoBehaviour
{
    [SerializeField] private GithubReaderInstancer _githubReaderInstancer;
    [SerializeField] private string _accessToken;
    public IGithubReader GithubReader { get; private set; }

    private void Awake()
    {
        GithubReader = _githubReaderInstancer.GetInstance(_accessToken);
    }
}
