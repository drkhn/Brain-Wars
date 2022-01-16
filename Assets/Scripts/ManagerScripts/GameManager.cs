using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [Header(" ~~~~~~~~~~~~~~ Tap The Color ~~~~~~~~~~~~~~ ")]
    [SerializeField] GameObject TapTheColor;

    [Header(" ~~~~~~~~~~~~~~ Spinning Block ~~~~~~~~~~~~~~ ")]
    [SerializeField] GameObject spinningBlock;

    [Header(" ~~~~~~~~~~~~~~ Spinning Block ~~~~~~~~~~~~~~ ")]
    [SerializeField] GameObject followTheLeader;

    [SerializeField] GameObject prefab;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    void GameSelect(GameObject go)
    {
        prefab = Instantiate(go);
    }

    //Tap The Color
    public void OpenTapTheColor()
    {
        EventManager.GamePlayUIRoot(UIRoot.MainPanel, false);
        GameSelect(TapTheColor);
        EventManager.GamePlayUIRoot(UIRoot.GamePanel, true);
        EventManager.GamePlaySelectGame(GameRoot.TapTheColor, true);


    }
      
    public void TapTheColorMemorized()
    {
        EventManager.GamePLayTapTheColorMemorized();
    }

    public void RestartGame(MemorizedRoot enums, GamePrefab gamePrefab)
    {
        Destroy(prefab);
      
        Vibration.Vibrate(35);
        EventManager.GamePlayCamera(CameraRoot.FailCamera);
        StartCoroutine(RestartGameCoroutine(enums, gamePrefab));
    }

    IEnumerator RestartGameCoroutine(MemorizedRoot enums, GamePrefab gamePrefab)
    {
        yield return new WaitForSeconds(.2f);
        
        EventManager.GamePlayMemorizedButton(enums,true);
        if (gamePrefab == GamePrefab.PrefabTapTheColor)
        {
            prefab = Instantiate(TapTheColor);
        }
        else if (gamePrefab == GamePrefab.PrefabSpinningBlcok)
        {
            prefab = Instantiate(spinningBlock);
        }
        else if (gamePrefab == GamePrefab.PrefabFollowTheLeader)
        {
            prefab = Instantiate(followTheLeader);
        }
    }

    public void SuccessGame(MemorizedRoot enums, GamePrefab gamePrefab)
    {
        Destroy(prefab);
        StartCoroutine(SuccessGameCrouitine(enums,gamePrefab));
        EventManager.GamePlayCamera(CameraRoot.SuccessCamera);
    }

    IEnumerator SuccessGameCrouitine(MemorizedRoot enums, GamePrefab gamePrefab)
    {
        yield return new WaitForSeconds(.2f);
       
        EventManager.GamePlayMemorizedButton(enums,true);
        if (gamePrefab == GamePrefab.PrefabTapTheColor)
        {
            prefab = Instantiate(TapTheColor);
        }
        else if (gamePrefab == GamePrefab.PrefabSpinningBlcok)
        {
            prefab = Instantiate(spinningBlock);
        }
        else if (gamePrefab == GamePrefab.PrefabFollowTheLeader)
        {
            prefab = Instantiate(followTheLeader);
        }
    }


    // Spinning Block

    public void OpenSpinningBlock()
    {
        EventManager.GamePlayUIRoot(UIRoot.MainPanel, false);
        GameSelect(spinningBlock);
        EventManager.GamePlayUIRoot(UIRoot.GamePanel, true);
        EventManager.GamePlaySelectGame(GameRoot.SpinningBlcok, true);

    }

    public void SpinningBlockMemorized()
    {
        EventManager.GamePlaySpiningBlockMemorized();
    }

    // Follow The Leader

    public void OpenFollowTheLeader()
    {
        EventManager.GamePlayUIRoot(UIRoot.MainPanel, false);
        GameSelect(followTheLeader);
        EventManager.GamePlayUIRoot(UIRoot.GamePanel, true);
        EventManager.GamePlaySelectGame(GameRoot.FollowTheLeader, true);
    }

    public void FollowTheLeaderMemorized()
    {
        EventManager.GamePlayFollowTheLeaderMemorized();
    }




}
