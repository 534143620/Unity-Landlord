using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPanel : UIBase
{
    private void Awake()
    {
         Bind(UIEvent.START_PANEL_ACTIVE);
    }

    public override void Execute(int eventCode, object message)
    {
        switch (eventCode)
        {
            case UIEvent.START_PANEL_ACTIVE:
                setPanelActive((bool)message);
                break;
            default:
                break;
        }
    }
    private Button Btn_Play;
    private Button Btn_Close;
    private InputField Input_Account;
    private InputField Input_Password;
    // Start is called before the first frame update
    void Start()
    {
        Btn_Play = transform.Find("Btn_Play").GetComponent<Button>();
        Btn_Close = transform.GetComponent<Button>();
        Input_Account = transform.Find("InputAccount").GetComponent<InputField>();
        Input_Password = transform.Find("InputPassword").GetComponent<InputField>();
        Btn_Play.onClick.AddListener(PlayClick);
        Btn_Close.onClick.AddListener(CloseClick);

        //面板需要默认隐藏
        setPanelActive(false);
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
        Btn_Play.onClick.RemoveListener(PlayClick);
        Btn_Close.onClick.RemoveListener(CloseClick);

    }
    private void PlayClick()
    {
        if (string.IsNullOrEmpty(Input_Account.text))
            return;
        if (string.IsNullOrEmpty(Input_Password.text)
            ||Input_Password.text.Length < 4
            ||Input_Password.text.Length > 16)
            return;

        //和服务器交互了
        //TODO

    }
    private void CloseClick()
    {
        setPanelActive(false);
    }
}
