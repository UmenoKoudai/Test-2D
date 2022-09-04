using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// カードの初期化とリセットをするコンポーネント
/// </summary>
public class ResetController : MonoBehaviour
{
    /// <summary>このデッキの上にカードを置く</summary>
    [SerializeField] LayoutGroup _deck = null;
    /// <summary>カードを置く枚数</summary>
    [SerializeField] int _count = 6;
    /// <summary>カードのプレハブ</summary>
    [SerializeField] Image _cardPrefab = null;
    Sprite[] _cardSprites = null;

    void Start()
    {
        _cardSprites = Resources.LoadAll<Sprite>("Sprites");   // Resources/Sprites 以下にある全てのスプライトを読み込む
        Reset();
    }

    /// <summary>
    /// カードをリセットする
    /// </summary>
    public void Reset()
    {
        DestroyAllCards();

        for (int i = 0; i < _count; i++)
        {
            Image image = CreateRandomCard();
            image.transform.SetParent(_deck.transform);
            image.transform.localScale = Vector3.one;   // ズレてしまった Scale を元に戻す
        }
    }

    /// <summary>
    /// ランダムな絵柄のカードを一枚生成して戻り値として返す
    /// </summary>
    /// <returns></returns>
    Image CreateRandomCard()
    {
        Image image = Instantiate(_cardPrefab);
        image.sprite = _cardSprites[Random.Range(0, _cardSprites.Length)];
        image.gameObject.name = image.sprite.name;
        return image;
    }

    /// <summary>
    /// 全てのカードを破棄する
    /// </summary>
    void DestroyAllCards()
    {
        foreach(var card in GameObject.FindGameObjectsWithTag("CardTag"))
        {
            Destroy(card);
        }
    }
}
