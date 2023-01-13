using System.Globalization;
using Octokit;
using UnityEngine;
using TMPro;

public class RepositoryDrawer : MonoBehaviour
{
    [SerializeField] private GameObject _targetGameObject;
    [SerializeField] private TMP_Text _nameTextField;
    [SerializeField] private GameObject[] _descriptionGameObjects;
    [SerializeField] private TMP_Text _descriptionTextField;
    [SerializeField] private GameObject[] _readmeButtonGameObjects;
    [SerializeField] private GameObject _licenseGameObject;
    [SerializeField] private TMP_Text _licenseTextField;
    [SerializeField] private TMP_Text _lastUpdateTextField;

    public void Hide()
    {
        _targetGameObject.SetActive(false);
    }

    public void Draw(Repository repository, bool hasReadme)
    {
        _nameTextField.text = repository.Name;

        bool hasDescription = StringHelper.IsFilled(repository.Description);
        GameObjectHelper.SetActive(_descriptionGameObjects, hasDescription);
        if (hasDescription) _descriptionTextField.text = repository.Description;

        bool hasLicense = repository.License != null;
        _licenseGameObject.SetActive(hasLicense);
        if (hasLicense) _licenseTextField.text = repository.License.Name;

        _lastUpdateTextField.text = $"Updated on {repository.UpdatedAt.Date.ToString("MMM dd, yyyy", CultureInfo.InvariantCulture)}";
        
        GameObjectHelper.SetActive(_readmeButtonGameObjects, hasReadme);

        _targetGameObject.SetActive(true);
    }
}
