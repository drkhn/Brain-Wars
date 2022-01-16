using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using DG.Tweening;
using Enums;
public class TapTheColor : MonoBehaviour
{
    [Header(" ~~~~~~~~~~~~~~ Indicators ~~~~~~~~~~~~~~ ")]
    [SerializeField] GameObject indicator;
    [SerializeField] Transform indicatorsPos;

    [Header("----------------------------------------------")]
    [SerializeField] float indicatorHorizontal;
    [SerializeField] float indicatorVertical;

    [Header(" ---------------------------------------------- ")]
    [SerializeField] List<GameObject> indicatorlist = new List<GameObject>();

    [Header(" ~~~~~~~~~~~~~~ Carts ~~~~~~~~~~~~~~ ")]
    [SerializeField] GameObject cart;
    [SerializeField] Transform cartPos;

    [Header("----------------------------------------------")]
    [SerializeField] float cartHorizontal;
    [SerializeField] float cartVertical;
    [Header("----------------------------------------------")]
    [SerializeField] Color cartDefaultColor;

    [Header("----------------------------------------------")]
    [SerializeField] List<GameObject> cartList = new List<GameObject>();

    [Header(" ~~~~~~~~~~~~~~ Game Settings ~~~~~~~~~~~~~~ ")]

    [SerializeField] int cartValue = 3;
    [SerializeField] int StackHorizontalCount;
    [SerializeField] int StackVerticalCount;
    [Header("----------------------------------------------")]
    [SerializeField] float moveDuration = .5f;
    [SerializeField] float colorDuration = .5f;
    [Header("----------------------------------------------")]
    [SerializeField] Color[] colors;

    [SerializeField] List<int> cartID = new List<int>();

    [SerializeField]List<int> indicatorID = new List<int>();


    private void OnEnable()
    {
        EventManager.GameTapTheColorMemorized += MemorizedButton;
    }

    private void OnDisable()
    {
        EventManager.GameTapTheColorMemorized -= MemorizedButton;
    }

    private void Start()
    {
        AlignCart();
    }


    void AlignIndicators()
    {
        for (int i = 0; i < cartValue; i++)
        {
            GameObject indicatorGO = Instantiate(indicator, new Vector2(indicatorsPos.transform.position.x, indicatorsPos.transform.position.y), Quaternion.identity);
            indicatorGO.transform.SetParent(indicatorsPos);
            indicatorlist.Add(indicatorGO);
        }
        for (int j = 0; j < indicatorlist.Count; j++)
        {
            Vector2 targetPos = Vector2.zero;
           
            targetPos.x = (j % StackHorizontalCount) - (StackHorizontalCount / 2);
            targetPos.y = (j / StackHorizontalCount) % (StackVerticalCount);

            targetPos.x *= indicatorHorizontal;
            targetPos.y *= -indicatorVertical;

            indicatorlist[j].transform.DOLocalMove(targetPos,moveDuration);
            
        }
    }

    void AlignCart()
    {
        for (int i = 0; i < cartValue; i++)
        {
            GameObject cartGO = Instantiate(cart, new Vector2(cartPos.transform.position.x, cartPos.transform.position.y), Quaternion.identity);
            cartGO.transform.SetParent(cartPos);
            cartList.Add(cartGO);
        }
        for (int j = 0; j < cartList.Count; j++)
        {
            Vector2 targetPos = Vector2.zero;

            targetPos.x = (j % StackHorizontalCount) - (StackHorizontalCount / 2);
            targetPos.y = (j / StackHorizontalCount) % (StackVerticalCount);

            targetPos.x *= cartHorizontal;
            targetPos.y *= -cartVertical;

            cartList[j].transform.DOLocalMove(targetPos, moveDuration);

        }

        CartColor();
    }

    void IndicatorColor()
    {
        for (int i = 0; i < indicatorlist.Count; i++)
        {
            indicatorlist[i].gameObject.GetComponent<SpriteRenderer>().DOColor(colors[indicatorID[i]],colorDuration);
        }
    }

    void CartColor()
    {
        for (int i = 0; i < cartList.Count; i++)
        {
            int rndColor = Random.Range(0, colors.Length);
            cartID.Add(rndColor);
            cartList[i].gameObject.GetComponent<SpriteRenderer>().DOColor(colors[rndColor], colorDuration);
            cartList[i].gameObject.GetComponent<CartsTapTheColor>().cartID = rndColor;

            cartList[i].gameObject.GetComponent<CartsTapTheColor>().cartColor = colors[rndColor];
        }
    }

    void CartDefaultColor()
    {
        for (int i = 0; i < cartList.Count; i++)
        {
           
            cartList[i].gameObject.GetComponent<SpriteRenderer>().DOColor(cartDefaultColor, colorDuration);
        }
    }

    void RandomUniq()
    {
        indicatorID = cartID.OrderBy(a => System.Guid.NewGuid()).ToList();
    }

    public void MemorizedButton()
    {
        EventManager.GamePlayMemorizedButton(MemorizedRoot.MemorizedTapTheColor,false);
        AlignIndicators();
        RandomUniq();
        IndicatorColor();
        CartDefaultColor();
        MatchCartID();
        CartContact();

    }
    void CartContact() // Kartlarý Dokunabilir yapabiliyorum
    {
        for(int i = 0; i < cartList.Count; i++)
        {
            cartList[i].gameObject.GetComponent<CartsTapTheColor>().isContact = true;
        }
    }
      

    void MatchCartID()
    {
        for (int i = 0; i < cartList.Count; i++)
        {
            cartList[i].gameObject.GetComponent<CartsTapTheColor>().indicatorIDList = indicatorID;
        }
    }
}


