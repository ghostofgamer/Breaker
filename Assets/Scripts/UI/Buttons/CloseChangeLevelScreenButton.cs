using System;
using System.Collections;
using System.Collections.Generic;
using UI.Buttons;
using UI.Screens.LevelInfo;
using UnityEngine;

public class CloseChangeLevelScreenButton : AbstractButton
{
    [SerializeField] private LevelInfo _levelInfo;

    private RaycastHit _hit;
    
    private void Update()
         {
        /*if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out _hit))
            {
                if (_hit.collider.TryGetComponent(out MirrorScript mirrorScript))
                {
                    Debug.Log("MirrorScript");
                    _levelInfo.Close();
                }
            }
        }*/
    }

    protected override void OnClick()
    {
        _levelInfo.Close();
        // gameObject.SetActive(false);
    }

    public void Init(LevelInfo levelInfo)
    {
        _levelInfo = levelInfo;
    }
}
