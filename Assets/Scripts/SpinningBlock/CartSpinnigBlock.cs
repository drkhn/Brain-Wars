using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

public class CartSpinnigBlock : MonoBehaviour
{
    [Header(" ~~~~~~~~~~~~~~ Cart Settings ~~~~~~~~~~~~~~ ")]
    [SerializeField] SpriteRenderer spriteRenderer;

    [Header("----------------------------------------------")]
    [SerializeField] public bool isContact = false;
    [SerializeField] public bool isColor = false;
    [Header("----------------------------------------------")]
    [SerializeField] Color cartColor;
    public static int successCount = 0;

    private void OnMouseDown()
    {
        if (isContact)
        {
            Debug.Log("Cart");
            TrueSelectCart();
        }
    }

    void TrueSelectCart()
    {
        if (isColor)
        {
            successCount++;
            spriteRenderer.color = cartColor;
            Debug.Log("Doðru Týklandý");
            if (successCount == 3)
            {
                successCount = 0;
                Debug.Log("Success");
                GameManager.Instance.SuccessGame(MemorizedRoot.MemorizedSpinningBlcok, GamePrefab.PrefabSpinningBlcok);
            }
        }
        else
        {
            Debug.Log("Fail");
            successCount = 0;
            GameManager.Instance.RestartGame(MemorizedRoot.MemorizedSpinningBlcok,GamePrefab.PrefabSpinningBlcok);
        }
    }
}
