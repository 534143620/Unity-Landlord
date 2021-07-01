using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayPanel : UIBase
{
    private Button Btn_Start;
    private Button Btn_Login;

    void Start()
    {
        Btn_Start = transform.Find("PLAY").GetComponent<Button>();
        Btn_Login = transform.Find("LOGIN").GetComponent<Button>();
        Btn_Start.onClick.AddListener(startClick);
        Btn_Login.onClick.AddListener(loginClick);

    }

    public override void OnDestroy()
    {
        base.OnDestroy();

        Btn_Start.onClick.RemoveAllListeners();
        Btn_Login.onClick.RemoveAllListeners();
    }

    private void startClick()
    {
        Dispatch(AreaCode.UI, UIEvent.START_PANEL_ACTIVE, true);
    }
    private void loginClick()
    {
        Dispatch(AreaCode.UI, UIEvent.LOGIN_PANEL_ACTIVE, true);
    }
}
