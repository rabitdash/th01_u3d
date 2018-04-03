using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
    //负责UI事件
    public static UIController _instance;

    #region 按钮定义,须由外部赋值

    public Button confirmButton;
    public Button cancelButton;
    public Button logoutButton;
    public Button startButton;

    #endregion

    // Use this for initialization
    void Awake()
    {
        _instance = this;

        #region 按钮事件监听
        confirmButton.onClick.AddListener(delegate
        {
            CardManager._instance.AddCardTo(0);//Test
            Debug.Log("confirmButtonClicked!");
        });
        logoutButton.onClick.AddListener(delegate
        {
            Application.Quit(); //考虑到网络游戏，这边不能这么写
        });
        cancelButton.onClick.AddListener(delegate
        {
            CardManager._instance.DropCardFrom(0);//Test
        });
        startButton.onClick.AddListener(delegate
        {
            CardManager._instance.NewTurn();
        });
        #endregion
    }
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
