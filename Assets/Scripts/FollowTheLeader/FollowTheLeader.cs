using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using DG.Tweening;
using Enums;
public class FollowTheLeader : MonoBehaviour
{
    [Header(" ~~~~~~~~~~~~~~ Follow The Leader ~~~~~~~~~~~~~~ ")]
    [SerializeField] GameObject carts;

    [Header("----------------------------------------------")]
    [SerializeField] List<GameObject> followTheLeaderCarts = new List<GameObject>();
    [SerializeField] List<GameObject> RandomID = new List<GameObject>();

    [Header(" ~~~~~~~~~~~~~~ Game Settings ~~~~~~~~~~~~~~ ")]
    [SerializeField] float colorDuration = 1f;
    [Range(1, 9)]
    [SerializeField] int cartCount = 3;

    private void OnEnable()
    {
        EventManager.GameFollowTheLeaderMemorized += MemorizedButton;
    }
    private void OnDisable()
    {
        EventManager.GameFollowTheLeaderMemorized -= MemorizedButton;

    }

    private void Start()
    {
        AlignBlock();
    }


    void AlignBlock()
    {
        for (int i = 0; i < carts.transform.childCount; i++)
        {
            followTheLeaderCarts.Add(carts.transform.GetChild(i).gameObject);
        }
        RandomUniq();
        for (int i = 0; i < cartCount; i++)
        {
             RandomID[i].gameObject.GetComponent<CartFollowTheLeader>().isContact = true;
            RandomID[i].gameObject.GetComponent<CartFollowTheLeader>().cartID = i+1;
            RandomID[i].gameObject.GetComponent<CartFollowTheLeader>().totalSuccessCount = cartCount;
            RandomID[i].gameObject.GetComponent<CartFollowTheLeader>().ColorChange(i, colorDuration);
        }
       
    }

    void RandomUniq()
    {
        RandomID = followTheLeaderCarts.OrderBy(a => System.Guid.NewGuid()).ToList();
    }

    public void MemorizedButton()
    {
        EventManager.GamePlayMemorizedButton(MemorizedRoot.MemorizedFollowTheLeader, false);
    }

}
