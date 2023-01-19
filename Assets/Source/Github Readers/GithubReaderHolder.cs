using UnityEngine;

public class GithubReaderHolder : MonoBehaviour
{
    [SerializeField] private GithubReaderInstancer _githubReaderInstancer;
    public IGithubReader GithubReader { get; private set; }

    private void Awake()
    {
        GithubReader = _githubReaderInstancer.GetInstance();
    }
}
