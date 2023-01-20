public class GithubUser
{
    public GithubUser(int id, string avatarUrl, string name, string login, string bio, string blog, string url)
    {
        Id = id;
        AvatarUrl = avatarUrl;
        Name = name;
        Login = login;
        Bio = bio;
        Blog = blog;
        Url = url;
    }

    public int Id { get; protected set; }
    public string AvatarUrl { get; protected set; }
    public string Name { get; protected set; }
    public string Login { get; protected set; }
    public string Bio { get; protected set; }
    public string Blog { get; protected set; }
    public string Url { get; protected set; }
}
