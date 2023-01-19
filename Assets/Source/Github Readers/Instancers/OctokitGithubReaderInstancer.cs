using UnityEngine;
[CreateAssetMenu(fileName = "Octokit Github Reader", menuName = "Scriptable Objects/Github Readers/Octokit")]
public class OctokitGithubReaderInstancer : GithubReaderInstancer
{
    [SerializeField] private string _productHeaderValue;

    public override IGithubReader GetInstance()
    {
        return new OctokitGithubReader(_productHeaderValue);
    }
}
