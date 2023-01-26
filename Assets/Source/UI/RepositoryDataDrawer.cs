using System.Globalization;
using UnityEngine;
using TMPro;

public class RepositoryDataDrawer : MonoBehaviour
{
    [SerializeField] private GameObject _targetGameObject;
    [SerializeField] private TMP_Text _nameTextField;
    [SerializeField] private GameObject[] _descriptionGameObjects;
    [SerializeField] private TMP_Text _descriptionTextField;
    [SerializeField] private GameObject[] _readmeButtonGameObjects;
    [SerializeField] private GameObject _licenseGameObject;
    [SerializeField] private TMP_Text _licenseTextField;
    [SerializeField] private TMP_Text _lastUpdateTextField;
    [SerializeField] private GameObject[] _topicsGameObjects;
    [SerializeField] private TopicsDrawer _topicsDrawer;

    public void Hide()
    {
        _targetGameObject.SetActive(false);
    }

    public void Draw(GithubRepository repository, bool hasReadme)
    {
        _nameTextField.text = repository.Name;

        bool hasDescription = StringHelper.IsFilled(repository.Description);
        GameObjectHelper.SetActive(_descriptionGameObjects, hasDescription);
        if (hasDescription) _descriptionTextField.text = repository.Description;

        bool hasLicense = StringHelper.IsFilled(repository.LicenseName);
        _licenseGameObject.SetActive(hasLicense);
        if (hasLicense) _licenseTextField.text = repository.LicenseName;

        _lastUpdateTextField.text = $"Updated on {repository.UpdatedAt.Date.ToString("MMM dd, yyyy", CultureInfo.InvariantCulture)}";
        
        GameObjectHelper.SetActive(_readmeButtonGameObjects, hasReadme);

        bool hasTopics = repository.Topics != null;
        GameObjectHelper.SetActive(_topicsGameObjects, hasTopics);
        if (hasTopics) _topicsDrawer.Draw(repository.Topics);

        _targetGameObject.SetActive(true);
    }
}
