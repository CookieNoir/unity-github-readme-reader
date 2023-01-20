using System;
using System.Collections.Generic;

public interface IGithubReader
{
    void RequestUserData(string username, Action<GithubUser> onSuccessAction, Action<string> onFailureAction = null);
    void RequestUserRepositoriesData(string username, Action<IEnumerable<GithubRepository>> onSuccessAction, Action<string> onFailureAction = null);
    void RequestRepositoryReadme(string repositoryFullName, Action<GithubReadme> onSuccessAction, Action<string> onFailureAction = null);
}
