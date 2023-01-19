using System;

public class UserDataReceiver : DataReceiver<string, UserData>
{
    protected override Action<string, Action<UserData>, Action<string>> GetRequestMethod()
    {
        return GithubReader.RequestUserData;
    }
}
