using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Enums;

public class CartsTapTheColor : MonoBehaviour
{
    [Header(" ~~~~~~~~~~~~~~ Cart Settings ~~~~~~~~~~~~~~ ")]
    [SerializeField] SpriteRenderer spriteRenderer;
    [Header("----------------------------------------------")]
    [SerializeField] public int cartID;
    [SerializeField] public List<int> indicatorIDList = new List<int>();
    public static int selectValue = -1;
    public static int trueSelectValue = 0;
    [Header("----------------------------------------------")]
    [SerializeField] public Color cartColor;
    [Header("----------------------------------------------")]
    [SerializeField] float rotationDuration = .5f;
    [SerializeField] float colorDuration = .1f;

    [Header("----------------------------------------------")]
    [SerializeField] public bool isContact = false;

    private void OnMouseDown()
    {
        if (isContact)
        {
            SelectCart();
            ControlSelect(indicatorIDList[selectValue]);
        }


    }

    void SelectCart()
    {
        selectValue++;
        transform.DORotate(new Vector3(0, 180, 0), rotationDuration, RotateMode.Fast).OnComplete(() =>spriteRenderer.DOColor(cartColor,colorDuration));
    }

    void ControlSelect(int id)
    {
        if (cartID == id)
        {
            Debug.Log("True : " + cartID + " | " + id);
            SuccessTapTheColor();
        }
        else
        {
            Debug.Log("False : " + cartID + " | " + id);
            GameManager.Instance.RestartGame(MemorizedRoot.MemorizedTapTheColor,GamePrefab.PrefabTapTheColor);
            selectValue = -1;
            trueSelectValue = 0;
        }
    }

    void SuccessTapTheColor()
    {
        trueSelectValue++;
        if (trueSelectValue == indicatorIDList.Count)
        {
            trueSelectValue = 0;
            selectValue = -1;
            GameManager.Instance.SuccessGame(MemorizedRoot.MemorizedTapTheColor, GamePrefab.PrefabTapTheColor);
            Debug.Log("Success");
        }
    }



   
}
