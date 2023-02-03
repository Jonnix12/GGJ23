using System.Collections.Generic;
using Player;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUI : MonoBehaviour
{
    [SerializeField] private PlayerWeaponHandler _player;
    [SerializeField] private List<Sprite> _images;
    [SerializeField] private Image _image;

    // Update is called once per frame
    void Update()
    {
        _image.sprite = _images[_player.CurrentWeaponID];
    }
}
