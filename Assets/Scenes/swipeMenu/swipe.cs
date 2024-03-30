using MainMenu;
using MainMenu.Shop.Platforms;
using UnityEngine;
using UnityEngine.UI;

public class swipe : MonoBehaviour
{
    [SerializeField] private BaseStore _platfromaSkinShop;
    [SerializeField] private Sprite _off;
    [SerializeField] private Sprite _on;
    
    public GameObject scrollbar, imageContent;
    private float _scrollPosition = 0;
    private float[] _positions;
    private bool _runIt = false;
    private float _time;
    private Button _takeButton;
    private int _buttonNumber;
    private Vector3[] _startPosition;
    private HorizontalLayoutGroup _layoutGroup;
    private RectTransform[] _children;
    private Vector3[] _newPosition;
    private Image _knobOff;
    private Image _knobOn;

    private void Start()
    {
        _layoutGroup = GetComponent<HorizontalLayoutGroup>();
        _startPosition = new Vector3[transform.childCount];
        _children = new RectTransform[_layoutGroup.transform.childCount];
        _newPosition = new Vector3[_children.Length];

        for (int i = 0; i < _layoutGroup.transform.childCount; i++)
        {
            _children[i] = _layoutGroup.transform.GetChild(i).GetComponent<RectTransform>();
        }

        for (int i = 0; i < _children.Length; i++)
        {
            _newPosition[i] = _children[i].transform.localPosition;
            _newPosition[i].z -= 50f;
        }


        for (int i = 0; i < transform.childCount; i++)
        {
            _startPosition[i] = transform.GetChild(i).position;
        }
    }

    private void Update()
    {
        _positions = new float[transform.childCount];
        float distance = 1f / (_positions.Length - 1f);

        if (_runIt)
        {
            GecisiDuzenle(distance, _positions, _takeButton);
            _time += Time.deltaTime;

            if (_time > 1f)
            {
                _time = 0;
                _runIt = false;
            }
        }

        for (int i = 0; i < _positions.Length; i++)
        {
            _positions[i] = distance * i;
        }

        if (Input.GetMouseButton(0))
        {
            _scrollPosition = scrollbar.GetComponent<Scrollbar>().value;
        }
        else
        {
            for (int i = 0; i < _positions.Length; i++)
            {
                if (_scrollPosition < _positions[i] + (distance / 2) &&
                    _scrollPosition > _positions[i] - (distance / 2))
                {
                    scrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollbar.GetComponent<Scrollbar>().value,
                        _positions[i], 0.1f);
                }
            }
        }
        
        for (int i = 0; i < _positions.Length; i++)
        {
            if (_scrollPosition < _positions[i] + (distance / 2) && _scrollPosition > _positions[i] - (distance / 2))
            {
                transform.GetChild(i).localScale = Vector3.Lerp(transform.GetChild(i).localScale,
                    new Vector3(1.65f, 1.65f, 1.65f), 0.1f);
                _platfromaSkinShop.UpdateButtons(i);
                transform.GetChild(i).localPosition = Vector3.Lerp(transform.GetChild(i).localPosition,
                    new Vector3(transform.GetChild(i).localPosition.x, transform.GetChild(i).localPosition.y, -150f),
                    0.1f);
                imageContent.transform.GetChild(i).GetComponent<Image>().sprite = _on;
                EnableRotate(transform.GetChild(i));

                for (int j = 0; j < _positions.Length; j++)
                {
                    if (j != i)
                    {
                        imageContent.transform.GetChild(j).GetComponent<Image>().sprite = _off;
                        imageContent.transform.GetChild(j).localScale =
                            Vector2.Lerp(imageContent.transform.GetChild(j).localScale, new Vector2(0.8f, 0.8f), 0.1f);
                        transform.GetChild(j).localScale = Vector3.Lerp(transform.GetChild(j).localScale,
                            new Vector3(0.8f, 0.8f, 0.8f), 0.1f);
                        
                        transform.GetChild(j).localPosition = Vector3.Lerp(transform.GetChild(j).localPosition,
                            new Vector3(transform.GetChild(j).localPosition.x, transform.GetChild(j).localPosition.y,
                                -15f), 0.1f);
                        
                        DisableRotate(transform.GetChild(j));
                    }
                }
            }
        }
    }

    private void EnableRotate(Transform capsula)
    {
        var platforma = capsula.GetComponentInChildren<BaseRotator>();
        platforma.EnableRotate();
    }
    
    private void DisableRotate(Transform capsula)
    {
        var platforma = capsula.GetComponentInChildren<BaseRotator>();
        platforma.DisableRotate();
    }

    private void GecisiDuzenle(float distance, float[] pos, Button btn)
    {
        for (int i = 0; i < pos.Length; i++)
        {
            if (_scrollPosition < pos[i] + (distance / 2) && _scrollPosition > pos[i] - (distance / 2))
            {
                scrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollbar.GetComponent<Scrollbar>().value,
                    pos[_buttonNumber], 1f * Time.deltaTime);
            }
        }

        for (int i = 0; i < btn.transform.parent.transform.childCount; i++)
        {
            btn.transform.name = ".";
        }
    }

    public void WhichBtnClicked(Button btn)
    {
        btn.transform.name = "clicked";

        for (int i = 0; i < btn.transform.parent.transform.childCount; i++)
        {
            if (btn.transform.parent.transform.GetChild(i).transform.name == "clicked")
            {
                _buttonNumber = i;
                _takeButton = btn;
                _time = 0;
                _scrollPosition = (_positions[_buttonNumber]);
                _runIt = true;
            }
        }
    }
}