using UnityEngine;
[CreateAssetMenu(fileName = "Unity Github Reader", menuName = "Scriptable Objects/Github Readers/Unity")]
public class UnityGithubReaderInstancer : GithubReaderInstancer
{
    public override IGithubReader GetInstance()
    {
        return new UnityGithubReader();
    }
}
