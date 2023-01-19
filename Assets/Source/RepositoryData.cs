using System;

public class RepositoryData
{
    public RepositoryData(long id, string name, string fullName, string description, string defaultBranch, string licenseName, DateTime updatedAt, string svnUrl)
    {
        Id = id;
        Name = name;
        FullName = fullName;
        Description = description;
        DefaultBranch = defaultBranch;
        LicenseName = licenseName;
        UpdatedAt = updatedAt;
        SvnUrl = svnUrl;
    }

    public long Id;
    public string Name;
    public string FullName;
    public string Description;
    public string DefaultBranch;
    public string LicenseName;
    public DateTime UpdatedAt;
    public string SvnUrl;
}
