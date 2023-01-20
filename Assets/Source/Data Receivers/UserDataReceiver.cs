using System;

public class UserDataReceiver : DataReceiver<string, GithubUser>
{
    protected override Action<string, Action<GithubUser>, Action<string>> GetRequestMethod()
    {
        return GithubReader.RequestUserData;
    }
}
