using UnityEngine;
using System.Collections;

//[AddComponentMenu("Transform/Follow Transform")]
public class GameManager : MonoBehaviour {
	
	//singleton
	//public string targetTagName = "Target";
	static GameManager _instance;
		
	//fsm
	
	public FSMController.MOVEMENT_STATE CurrentMovementState;
	public FSMController.ACTION_STATE CurrentActionState;
	public GUIText MovementLayer_GUI;
	public GUIText ActionLayer_GUI;
	
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
		MovementLayer_GUI = new GameObject("MOVEMENT TEXT", typeof(GUIText)).GetComponent<GUIText>();
		MovementLayer_GUI.transform.position = new Vector2(0.0f, 1.0f);			
		ActionLayer_GUI = new GameObject("ACTION TEXT", typeof(GUIText)).GetComponent<GUIText>();
		ActionLayer_GUI.transform.position = new Vector2(0.0f, 0.9f);	
	}
	
	// Update is called once per frame
	void Update () 
	{
		CurrentMovementState = FSMController.Instance.GetMovementLayerCurrentState();
		MovementLayer_GUI.text = "MovemntLayer FSM : " + CurrentMovementState;
		

		CurrentActionState = FSMController.Instance.GetActionLayerCurrentState();
		ActionLayer_GUI.text = "ActionLayer FSM : " + CurrentActionState;
	}
}
