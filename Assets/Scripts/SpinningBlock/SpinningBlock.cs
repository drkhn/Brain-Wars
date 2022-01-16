using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq;
using Enums;
public class SpinningBlock : MonoBehaviour
{
    [Header(" ~~~~~~~~~~~~~~ Spinning block ~~~~~~~~~~~~~~ ")]
    [SerializeField] GameObject block;
    [SerializeField] Color cartColor;

    [Header("----------------------------------------------")]
    [SerializeField] List<GameObject> spinningCarts = new List<GameObject>();
    [SerializeField] List<int> spinningCartsID = new List<int>();
    [SerializeField] List<int> RandomID = new List<int>();
    List<int> randomList = new List<int>();

    [Header(" ~~~~~~~~~~~~~~ Game Settings ~~~~~~~~~~~~~~ ")]
    [SerializeField] float rotateDuration = .5f;
    [Range(1, 9)]
    [SerializeField] int cartCount = 3;
    private void OnEnable()
    {
        EventManager.GameSpiningBlockMemorized += MemorizedButton;
    }
    private void OnDisable()
    {
        EventManager.GameSpiningBlockMemorized -= MemorizedButton;

    }
    private void Start()
    {
        AlignBlock();
    }

    void AlignBlock()
    {
        RandomUniq();
        for (int i = 0; i < cartCount; i++)
        {
            spinningCarts[RandomID[i]].gameObject.GetComponent<CartSpinnigBlock>().isColor = true; //
            Debug.Log("Random Uniq :" + RandomID[i]);
            spinningCarts[RandomID[i]].gameObject.GetComponent<SpriteRenderer>().color = cartColor;
        }

    }

    void RandomUniq()
    {
        RandomID = spinningCartsID.OrderBy(a => System.Guid.NewGuid()).ToList();
    }


    public void MemorizedButton()
    {
        RotateBlock();
        ColorCart();
        EventManager.GamePlayMemorizedButton(MemorizedRoot.MemorizedSpinningBlcok, false);
    }

    void RotateBlock()
    {
        int rnd = Random.Range(0, 4);
        if (rnd == 0)
        {
            block.transform.DORotate(new Vector2(180, 0), rotateDuration);
        }
        else if (rnd == 1 )
        {
            block.transform.DORotate(new Vector2(-180, 0), rotateDuration);
        }
        else if (rnd == 2)
        {
            block.transform.DORotate(new Vector2(0, 180), rotateDuration);
        }
        else if (rnd == 3)
        {
            block.transform.DORotate(new Vector2(0, -180), rotateDuration);
        }


    }

    void ColorCart()
    {
        for (int i = 0; i < spinningCarts.Count; i++)
        {
            spinningCarts[i].gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            spinningCarts[i].gameObject.GetComponent<CartSpinnigBlock>().isContact = true;
        }
    }
}
