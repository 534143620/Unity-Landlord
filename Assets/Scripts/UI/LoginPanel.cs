using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginPanel : UIBase
{
    private void Awake()
    {
        Bind(UIEvent.LOGIN_PANEL_ACTIVE);
    }

    public override void Execute(int eventCode, object message)
    {
        switch (eventCode)
        {
            case UIEvent.LOGIN_PANEL_ACTIVE:
                setPanelActive((bool)message);
                break;
            default:
                break;
        }
    }
    private Button Btn_Login;
    private Button Btn_Close;
    private InputField Input_Account;
    private InputField Input_Password;
    private InputField Input_Repeat;
    // Start is called before the first frame update
    void Start()
    {
        Btn_Login = transform.Find("Btn_Login").GetComponent<Button>();
        Btn_Close = transform.GetComponent<Button>();
        Input_Account = transform.Find("InputAccount").GetComponent<InputField>();
        Input_Password = transform.Find("InputPassword").GetComponent<InputField>();
        Input_Repeat = transform.Find("InputRepeat").GetComponent<InputField>();
        Btn_Login.onClick.AddListener(LoginClick);
        Btn_Close.onClick.AddListener(CloseClick);

        //面板需要默认隐藏
        setPanelActive(false);
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
        Btn_Login.onClick.RemoveListener(LoginClick);
        Btn_Close.onClick.RemoveListener(CloseClick);

    }
    private void LoginClick()
    {
        //TODO 注册

    }
    private void CloseClick()
    {
        setPanelActive(false);
    }
}
