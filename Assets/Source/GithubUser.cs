public class GithubUser
{
    public GithubUser(int id, string avatarUrl, string name, string login, string bio, string blog, string url, int publicRepos)
    {
        Id = id;
        AvatarUrl = avatarUrl;
        Name = name;
        Login = login;
        Bio = bio;
        Blog = blog;
        Url = url;
        PublicRepos = publicRepos;
    }

    public int Id { get; private set; }
    public string AvatarUrl { get; private set; }
    public string Name { get; private set; }
    public string Login { get; private set; }
    public string Bio { get; private set; }
    public string Blog { get; private set; }
    public string Url { get; private set; }
    public int PublicRepos { get; private set; }
}
