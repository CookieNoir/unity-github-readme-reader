using UnityEngine;
[CreateAssetMenu(fileName = "Unity Github Reader", menuName = "Scriptable Objects/Github Readers/Unity")]
public class UnityGithubReaderInstancer : GithubReaderInstancer
{
    [SerializeField] private GameObject _jsonReceiverPrefab;

    public override IGithubReader GetInstance()
    {
        GameObject jsonReceiverObject = Instantiate(_jsonReceiverPrefab);
        JSONReceiver receiver = jsonReceiverObject.GetComponent<JSONReceiver>();
        return new UnityGithubReader(receiver);
    }
}
