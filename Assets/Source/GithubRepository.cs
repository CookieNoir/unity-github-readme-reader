using System;
using System.Collections.Generic;

public class GithubRepository
{
    public GithubRepository(long id, string name, string fullName, string description, string defaultBranch, string licenseName, DateTime updatedAt, string url, string svnUrl, IEnumerable<string> topics)
    {
        Id = id;
        Name = name;
        FullName = fullName;
        Description = description;
        DefaultBranch = defaultBranch;
        LicenseName = licenseName;
        UpdatedAt = updatedAt;
        Url = url;
        SvnUrl = svnUrl;
        Topics = topics;
    }

    public long Id { get; private set; }
    public string Name { get; private set; }
    public string FullName { get; private set; }
    public string Description { get; private set; }
    public string DefaultBranch { get; private set; }
    public string LicenseName { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    public string Url { get; private set; }
    public string SvnUrl { get; private set; }
    public IEnumerable<string> Topics { get; private set; }
}
