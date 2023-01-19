using UnityEngine;

public abstract class GithubReaderInstancer : ScriptableObject
{
    public abstract IGithubReader GetInstance();
}
