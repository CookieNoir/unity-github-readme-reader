using UnityEngine;
using UnityEngine.UI;

public class Scroller : MonoBehaviour
{
    [SerializeField] private Scrollbar _scrollbar;
    [SerializeField, Min(0.01f)] private float _speed = 0.1f;
    private float _modifiedSpeed;

    public void StartScrollingUp()
    {
        _modifiedSpeed = _speed;
        enabled = true;
    }

    public void StartScrollingDown()
    {
        _modifiedSpeed = -_speed;
        enabled = true;
    }

    public void StopScrolling()
    {
        enabled = false;
    }

    private void Update()
    {
        _scrollbar.value += _modifiedSpeed * Time.deltaTime;
    }
}
