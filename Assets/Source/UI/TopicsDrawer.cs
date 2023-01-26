using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopicsDrawer : MonoBehaviour
{
    [SerializeField] private GameObject _topicPrefab;
    [SerializeField] private Transform _parentTransform;

    public void Draw(IEnumerable<string> topics)
    {
        foreach (string topic in topics)
        {
            GameObject newTopic = Instantiate(_topicPrefab, _parentTransform);
            newTopic.GetComponent<TextValueSetter>().Set(topic);
        }
    }
}
