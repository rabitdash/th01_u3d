using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
    //负责UI事件
    public static UIController _instance;
    #region Variables

    public Button confirmButton;
    public Button cancelButton;
    public Button logoutButton;
    public Button startButton;

    #endregion

    // Use this for initialization
    void Start()
    {
        _instance = this;

        #region AddListener
        confirmButton.onClick.AddListener(delegate
        {
            //NetSync.Instance.AddCard(BattleController.Player0.AddCard(-1));
            Debug.Log("confirmButtonClicked!");
        });
        logoutButton.onClick.AddListener(delegate
        {
            Application.Quit(); //TODO 考虑到网络游戏，这边不能这么写
        });
        cancelButton.onClick.AddListener(delegate
        {
            //CardManager.Instance.DropCardFrom(0,-1);//Test
        });
        startButton.onClick.AddListener(delegate
        {
            CardManager.Instance.NewTurn();
        });
        #endregion
    }
	void Awake ()
	{

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
