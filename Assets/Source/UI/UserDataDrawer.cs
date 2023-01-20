using UnityEngine;
using TMPro;

public class UserDataDrawer : MonoBehaviour
{
    [SerializeField] private TextureRepository _textureRepository;
    [SerializeField] private AsyncImageTextureSetter _asyncImageTextureSetter;
    [SerializeField] private GameObject[] _nameGameObjects;
    [SerializeField] private TMP_Text _nameTextField;
    [SerializeField] private TMP_Text _loginTextField;
    [SerializeField] private GameObject[] _bioGameObjects;
    [SerializeField] private TMP_Text _bioTextField;
    [SerializeField] private GameObject[] _blogGameObjects;
    [SerializeField] private TMP_Text _blogTextField;
    [SerializeField] private ManagedLayoutRebuilder _layoutRebuilder;

    public void Draw(GithubUser user)
    {
        _asyncImageTextureSetter.SetTexture(user.AvatarUrl, _textureRepository);

        bool hasName = StringHelper.IsFilled(user.Name);
        GameObjectHelper.SetActive(_nameGameObjects, hasName);
        if (hasName) _nameTextField.text = user.Name;

        _loginTextField.text = user.Login;

        bool hasBio = StringHelper.IsFilled(user.Bio);
        GameObjectHelper.SetActive(_bioGameObjects, hasBio);
        if (hasBio) _bioTextField.text = user.Bio;

        bool hasBlog = StringHelper.IsFilled(user.Blog);
        GameObjectHelper.SetActive(_blogGameObjects, hasBlog);
        if (hasBlog) _blogTextField.text = user.Blog;

        _layoutRebuilder.Rebuild();
    }
}
