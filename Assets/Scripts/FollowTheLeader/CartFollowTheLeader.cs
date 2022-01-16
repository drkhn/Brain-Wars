using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Enums;

public class CartFollowTheLeader : MonoBehaviour
{
    [Header(" ~~~~~~~~~~~~~~ Cart Settings ~~~~~~~~~~~~~~ ")]
    [SerializeField] SpriteRenderer spriteRenderer;
    [Header("----------------------------------------------")]
    [SerializeField] Color cartColor;

    [Header("----------------------------------------------")]
    [SerializeField] public bool isContact = false;
    [SerializeField] public int cartID = -1;
    public static int id = 0;
    public static int successCount = 0;
    public int totalSuccessCount;


    private void OnMouseDown()
    {
        if (isContact)
        {
            TrueSelectCart();
        }
    }

    void TrueSelectCart()
    {
        id++;
        if (id == cartID)
        {
            Debug.Log("Select True ");
            successCount++;
            if (successCount == totalSuccessCount)
            {
                id = 0;
                successCount = 0;
                Debug.Log("Success");
                GameManager.Instance.SuccessGame(MemorizedRoot.MemorizedFollowTheLeader, GamePrefab.PrefabFollowTheLeader);
            }

        }
        else
        {
            id = 0;
            successCount = 0;
            Debug.Log("Fail");
            GameManager.Instance.RestartGame(MemorizedRoot.MemorizedFollowTheLeader,GamePrefab.PrefabFollowTheLeader);
        }
    }

    public void ColorChange(int k , float duration)
    {
        spriteRenderer.DOColor(Color.white, duration * k).OnComplete(() =>spriteRenderer.DOColor(cartColor,.1f));
    }
}
