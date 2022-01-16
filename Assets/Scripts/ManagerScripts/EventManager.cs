using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;



    public class EventManager
    {

    public delegate void onGamePlayUIRoot(UIRoot value, bool val);
    public static event onGamePlayUIRoot GameUIRoot;

    public static void GamePlayUIRoot(UIRoot value, bool val)
    {
        GameUIRoot?.Invoke(value,val);
    }

    public delegate void onGameSelectGame(GameRoot value, bool val);
    public static event onGameSelectGame GameSelectGame;

    public static void GamePlaySelectGame(GameRoot value, bool val)
    {
        GameSelectGame?.Invoke(value, val);
    }

    public delegate void onGameMemorizedButton(MemorizedRoot value,bool val);
    public static event onGameMemorizedButton GameMemorizedButton;

    public static void GamePlayMemorizedButton(MemorizedRoot value,bool val)
    {
        GameMemorizedButton?.Invoke(value,val);
    }

    //Camera

    public delegate void onGameCamera(CameraRoot value);
        public static event onGameCamera GameCamera;

        public static void GamePlayCamera(CameraRoot value)
        {
        GameCamera?.Invoke(value);
        }



    //Save

    public delegate void onGameSaveLevelPlus();
        public static event onGameSaveLevelPlus GameSaveLevelPlus;

        public static void GamePlaySaveLevelPlus()
        {
            GameSaveLevelPlus?.Invoke();
        }

        public delegate void onGameLevelData(int levelMod, int levelLenght);
        public static event onGameLevelData GameLevelData;

        public static void GamePlayLevelData(int levelMod, int levelLenght)
        {
            GameLevelData?.Invoke( levelMod,levelLenght);
        }

        //Level Count
        public delegate void onGameLevelCount(int value);
        public static event onGameLevelCount GameLevelCount;

        public static void GamePlayLevelCount(int value)
        {
            GameLevelCount?.Invoke(value);
        }

    //Tap The Color

    public delegate void onGameTapTheColorMemorized();
    public static event onGameTapTheColorMemorized GameTapTheColorMemorized;

    public static void GamePLayTapTheColorMemorized()
    {
        GameTapTheColorMemorized?.Invoke();
    }


    // Spinning Block

    public delegate void onGameSpiningBlockMemorized();
    public static event onGameSpiningBlockMemorized GameSpiningBlockMemorized;

    public static void GamePlaySpiningBlockMemorized()
    {
        GameSpiningBlockMemorized?.Invoke();
    }

    // Follow The Leader

    public delegate void onGameFollowTheLeaderMemorized();
    public static event onGameFollowTheLeaderMemorized GameFollowTheLeaderMemorized;

    public static void GamePlayFollowTheLeaderMemorized()
    {
        GameFollowTheLeaderMemorized?.Invoke();
    }

}



