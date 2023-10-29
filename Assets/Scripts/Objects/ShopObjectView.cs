using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ShopObjectView : MonoBehaviour, IPointerClickHandler
{
    public event Action<ShopObjectView> Click;

    [SerializeField] private Sprite _standartBackground;
    [SerializeField] private Sprite _highlightBackground;

    [SerializeField] private Image _contentImage;
    [SerializeField] private Image _lockImage;

    [SerializeField] private IntValueView _priceView;

    [SerializeField] private Image _boughtText;

    private Image _backgroundImage;

    public ShopObject Item { get; private set; }

    public bool IsLock { get; private set; }

    public int Price => Item.Price;
    public GameObject Model => Item.Model;

    public void Init(ShopObject item)
    {
        _backgroundImage = GetComponent<Image>();
        _backgroundImage.sprite = _standartBackground;

        Item = item;

        _contentImage.sprite = item.Image;

        _priceView.Show(Price);
    }

    public void OnPointerClick(PointerEventData eventData) => Click?.Invoke(this);

    public void Lock()
    {
        IsLock = true;
        _lockImage.gameObject.SetActive(IsLock);
        _priceView.Show(Price);
    }

    public void UnLock()
    {
        IsLock = false;
        _lockImage.gameObject.SetActive(IsLock);
        _priceView.Hide();
    }

    public void Select() => _boughtText.gameObject.SetActive(true);
    public void UnSelect() => _boughtText.gameObject.SetActive(false);

    public void Highlight() => _backgroundImage.sprite = _highlightBackground;
    public void UnHighlight() => _backgroundImage.sprite = _standartBackground;
}
