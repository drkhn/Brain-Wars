using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

public class UIManager : MonoBehaviour
{
    [Header(" ~~~~~~~~~~~~~~ Panel ~~~~~~~~~~~~~~ ")]
    [SerializeField] GameObject mainPanel;
    [SerializeField] GameObject gamePanel;

    [Header(" ~~~~~~~~~~~~~~ TapTheColor ~~~~~~~~~~~~~~ ")]
    [SerializeField] GameObject tapTheColorMemorizedButton;

    [Header(" ~~~~~~~~~~~~~~ TapTheColor ~~~~~~~~~~~~~~ ")]
    [SerializeField] GameObject spinnigBlockMemorizedButton;

    [Header(" ~~~~~~~~~~~~~~ Follow The Leader ~~~~~~~~~~~~~~ ")]
    [SerializeField] GameObject followTheLeaderMemorizedButton;

    [Header(" ~~~~~~~~~~~~~~ Game Panel ~~~~~~~~~~~~~~ ")]
    [SerializeField] GameObject tapTheColorPanel;
    [SerializeField] GameObject spinnigBlockPanel;
    [SerializeField] GameObject followThePanelPanel;

    private void OnEnable()
    {
        EventManager.GameMemorizedButton += SetMemorizedButton;
        EventManager.GameUIRoot += SetPanel;
        EventManager.GameSelectGame += SetSelectGame;
    }

    private void OnDisable()
    {
        EventManager.GameMemorizedButton -= SetMemorizedButton;
        EventManager.GameUIRoot -= SetPanel;
        EventManager.GameSelectGame -= SetSelectGame;
    }

    public void SetPanel(UIRoot value, bool val)
    {
        if (value == UIRoot.MainPanel)
        {
            MainPanel(val);
        }
        if (value == UIRoot.GamePanel)
        {
            GamePanel(val);
        }
    }


    void MainPanel(bool value)
    {
        mainPanel.SetActive(value);
    }

    void GamePanel(bool value)
    {
        gamePanel.SetActive(value);

    }

    public void SetMemorizedButton(MemorizedRoot value,bool val)
    {
        if (value == MemorizedRoot.MemorizedTapTheColor)
        {
            MemorizedTapTheColor(val);
        }
        if (value == MemorizedRoot.MemorizedSpinningBlcok)
        {
            MemorizedSpinnigBlock(val);
        }
        if (value == MemorizedRoot.MemorizedFollowTheLeader)
        {
            MemorizedFollowTheLeader(val);
        }
    }

    void MemorizedTapTheColor(bool val)
    {
        tapTheColorMemorizedButton.SetActive(val);
    }

    void MemorizedSpinnigBlock(bool val)
    {
        spinnigBlockMemorizedButton.SetActive(val);
    }

    void MemorizedFollowTheLeader(bool val)
    {
        followTheLeaderMemorizedButton.SetActive(val);
    }

    public void SetSelectGame(GameRoot value , bool val)
    {
        if (value == GameRoot.TapTheColor)
        {
            SelectTapTheColor(val);
        }
        else if (value == GameRoot.SpinningBlcok)
        {
            SelectSpinningBlock(val);
        }
        else if (value == GameRoot.FollowTheLeader)
        {
            SelectFollowTheLeader(val);
        }
    }

    void SelectTapTheColor(bool val)
    {
        tapTheColorPanel.SetActive(val);
    }

    void SelectSpinningBlock(bool val)
    {
        spinnigBlockPanel.SetActive(val);
    }

    void SelectFollowTheLeader(bool val)
    {
        followThePanelPanel.SetActive(val);
    }
}
