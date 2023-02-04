using System.Collections.Generic;
using Player;
using UnityEngine;
using UnityEngine.UI;

public class HPUIHandler : MonoBehaviour
{
    [SerializeField] private List<Sprite> _sprite;
    [SerializeField] private Image _image;
    private void Update()
    {
        if (PlayerManager.Instance.Hp < 0)
        {
            return;
        }
        _image.sprite = _sprite[PlayerManager.Instance.Hp];
    }
}
