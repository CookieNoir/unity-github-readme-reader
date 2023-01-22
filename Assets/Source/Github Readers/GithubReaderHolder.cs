using UnityEngine;

public class GithubReaderHolder : MonoBehaviour
{
    [SerializeField] private GithubReaderInstancer _githubReaderInstancer;
    [SerializeField] private ResourcesTextReader _accessTokenReader;
    public IGithubReader GithubReader { get; private set; }

    private void Awake()
    {
        GithubReader = _githubReaderInstancer.GetInstance(_accessTokenReader.ReadText());
    }
}
