using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class TextureRepository : MonoBehaviour
{
    [SerializeField] private Texture2D _placeholderImage;
    private Dictionary<string, Texture2D> _loadedImages;

    private void Awake()
    {
        _loadedImages = new Dictionary<string, Texture2D>();
    }

    public async Task<Texture2D> GetTexture(string url, int secondsToTimeout)
    {
        Texture2D result;
        if (_loadedImages.ContainsKey(url))
        {
            result = _loadedImages[url];
        }
        else
        {
            Texture2D texture = await TextureLoader.GetRemoteTexture(url, secondsToTimeout);
            if (texture != null)
            {
                _loadedImages.Add(url, texture);
                result = texture;
            }
            else
            {
                result = _placeholderImage;
            }
        }
        return result;
    }
}
