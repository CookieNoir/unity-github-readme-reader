using System;
using System.Collections.Generic;

public interface IGithubReader
{
    void RequestUserData(string username, Action<UserData> onSuccessAction = null, Action<string> onFailureAction = null);
    void RequestUserRepositoriesData(string username, Action<IEnumerable<RepositoryData>> onSuccessAction, Action<string> onFailureAction = null);
    void RequestRepositoryReadme(long repositoryId, Action<string> onSuccessAction, Action<string> onFailureAction = null);
}
