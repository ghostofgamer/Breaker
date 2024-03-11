using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class swipe : MonoBehaviour
{
    [SerializeField]private PlatformaSkinShop _platfromaSkinShop;
    public Color[] colors;
    public GameObject scrollbar, imageContent;
    private float scroll_pos = 0;
    float[] pos;
    private bool runIt = false;
    private float time;
    private Button takeTheBtn;
    int btnNumber;
    private Vector3[] _startPosition;
    private HorizontalLayoutGroup _layoutGroup;
    [Range(0, 1000), SerializeField] private float _offset;
    private RectTransform[] _children;
    private Vector3[] _newPosition;
    private Image _knobOff;
    private Image _knobOn;
    [SerializeField ] private Sprite _off;
    [SerializeField ] private Sprite _on;
    
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
        pos = new float[transform.childCount];
        float distance = 1f / (pos.Length - 1f);

        if (runIt)
        {
            GecisiDuzenle(distance, pos, takeTheBtn);
            time += Time.deltaTime;

            if (time > 1f)
            {
                time = 0;
                runIt = false;
            }
        }

        for (int i = 0; i < pos.Length; i++)
        {
            pos[i] = distance * i;
        }

        if (Input.GetMouseButton(0))
        {
            scroll_pos = scrollbar.GetComponent<Scrollbar>().value;
        }
        else
        {
            for (int i = 0; i < pos.Length; i++)
            {
                if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
                {
                    scrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollbar.GetComponent<Scrollbar>().value, pos[i], 0.1f);
                }
            }
        }


        for (int i = 0; i < pos.Length; i++)
        {
            if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
            {
                Transform targetElement = _layoutGroup.transform.GetChild(i);
                // targetElement.position = new Vector3( targetElement.position.x,  targetElement.position.y, targetElement.position.z - 1f);
                transform.GetChild(i).localScale = Vector3.Lerp(transform.GetChild(i).localScale, new Vector3(1.65f, 1.65f,1.65f), 0.1f);
                // Debug.Log(i);
                
                _platfromaSkinShop.UpdateButtons(i);
                
                // transform.GetChild(i).localPosition = _newPosition[i];
                // Vector3 targetposition = new Vector3(transform.GetChild(i).localPosition.x, transform.GetChild(i).localPosition.y, transform.GetChild(i).localPosition.z);
                // Vector3 targetposition = new Vector3(transform.GetChild(i).position.x, transform.GetChild(i).position.y, -300f);
                // transform.GetChild(i).position = Vector3.Lerp(transform.GetChild(i).position, targetposition, 0.1f);
                // transform.GetChild(i).localPosition = Vector3.Lerp(transform.GetChild(i).position, targetposition, 0.1f);
                transform.GetChild(i).localPosition = Vector3.Lerp(transform.GetChild(i).localPosition, new Vector3(transform.GetChild(i).localPosition.x,transform.GetChild(i).localPosition.y,-90f), 0.1f);
                // imageContent.transform.GetChild(i).localScale = Vector2.Lerp(imageContent.transform.GetChild(i).localScale, new Vector2(1.2f, 1.2f), 0.1f);
                // imageContent.transform.GetChild(i).GetComponent<Image>().color = colors[1];
                imageContent.transform.GetChild(i).GetComponent<Image>().sprite = _on;
                RotateCapsula(transform.GetChild(i),true);
                
                for (int j = 0; j < pos.Length; j++)
                {
                    if (j != i)
                    {
                        // imageContent.transform.GetChild(j).GetComponent<Image>().color = colors[0];
                        imageContent.transform.GetChild(j).GetComponent<Image>().sprite = _off;
                        imageContent.transform.GetChild(j).localScale = Vector2.Lerp(imageContent.transform.GetChild(j).localScale, new Vector2(0.8f, 0.8f), 0.1f);
                        transform.GetChild(j).localScale = Vector3.Lerp(transform.GetChild(j).localScale, new Vector3(0.8f, 0.8f,0.8f), 0.1f);
                        
                        
                        
                        transform.GetChild(j).localPosition = Vector3.Lerp(transform.GetChild(j).localPosition,new Vector3( transform.GetChild(j).localPosition.x, transform.GetChild(j).localPosition.y,-15f),0.1f);
                        
                        
                        
                        RotateCapsula(transform.GetChild(j), false);
                        // transform.GetChild(j).localPosition = Vector3.Lerp(transform.GetChild(j).localPosition, new Vector3(transform.GetChild(j).localPosition.x,transform.GetChild(j).localPosition.y,-216f), 0.1f);
                        // transform.GetChild(i).position = _startPosition[i];
                        /*Vector3 targetPosition = new Vector3(transform.GetChild(i).position.x, transform.GetChild(i).position.y, -3.5f);
                        transform.GetChild(i).position = Vector3.Lerp(transform.GetChild(i).position, targetPosition, 0.1f);*/
                    }
                }
            }
        }


    }

    private void RotateCapsula(Transform capsula,bool selected)
    {
        var platforma = capsula.GetComponentInChildren<Capsula>();
        platforma.StartRotate(selected);
        // platforma.transform.rotation = Quaternion.Euler(0,0f,-45f);
        /*platforma.transform.rotation = Quaternion.Euler(0,1f,0);
        platforma.transform.Rotate(0,1,0);*/
        /*capsula.transform.Rotate(0,1,0);
        capsula.transform.localRotation *= Quaternion.Euler(0,100,0);*/
    }

    private void GecisiDuzenle(float distance, float[] pos, Button btn)
    {
        // btnSayi = System.Int32.Parse(btn.transform.name);

        for (int i = 0; i < pos.Length; i++)
        {
            if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
            {
                scrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollbar.GetComponent<Scrollbar>().value, pos[btnNumber], 1f * Time.deltaTime);
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
                btnNumber = i;
                takeTheBtn = btn;
                time = 0;
                scroll_pos = (pos[btnNumber]);
                runIt = true;
            }
        }
    }
}