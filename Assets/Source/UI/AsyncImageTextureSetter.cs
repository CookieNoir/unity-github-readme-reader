using UnityEngine;
using UnityEngine.UI;

public class AsyncImageTextureSetter : MonoBehaviour
{
    [SerializeField] private RawImage _image;
    [SerializeField, Min(1)] private int _secondsToTimeout = 1;

    public async void SetTexture(string url, TextureRepository textureRepository)
    {
        Texture2D texture = await textureRepository.GetTexture(url, _secondsToTimeout);
        _image.texture = texture;
    }
}
