using UnityEngine;
using System.Collections;


public enum INPUT
{
	none,
	command_stop,
	command_move,
	command_attack,
	command_die,
	command_respwan,
	complete_arrival,
	complete_attack,
	complete_revive,
	cnt
};

public enum STATE
{
	none,
	idle,
	move,
	attack,
	die,
	cnt
};

//[AddComponentMenu("Transform/Follow Transform")]
public class GameManager : MonoBehaviour {
	
	//singleton
	//public string targetTagName = "Target";
	static GameManager _instance;
		
	//fsm
	public STATE currentState;
	public GUIText gui;
	
	public void Awake()
	{
		//씬이 병경돼도 제거되지 않도록 설정
		DontDestroyOnLoad(gameObject);
	}
	
	/*
	public void LoadNextLevel(){
		//다음 레벨로 이동. 마지막 레벨인 경우 첫 번째 레벨로 이동
		Application.LoadLevel(
			(Application.levelCount == (Application.loadedLevel + 1))
			? 0 : Application.loadedLevel + 1);
	}
	*/
	
	public static GameManager Instance
	{
		get
		{
			if(_instance == null)
			{
				_instance = FindObjectOfType(typeof(GameManager)) as GameManager;
				if(_instance == null)
				{
					//현재 씬에 GameManager 컴포넌트가 없으면 새로 생성
					_instance = new GameObject("Game Manager", 
						typeof(GameManager)).GetComponent<GameManager>();
				}
			}
			return _instance;
		}
	}
	
	// Use this for initialization
	void Start () {
		gui = new GameObject("GUI TEXT", typeof(GUIText)).GetComponent<GUIText>();
		gui.transform.position = new Vector2(0.0f, 1.0f);					
	}
	
	// Update is called once per frame
	void Update () 
	{
		int output;
		output = FSMController.Instance.GetCurrentState();
		currentState = (STATE)output;
		gui.text = "FSM : " + currentState;
	}
}
