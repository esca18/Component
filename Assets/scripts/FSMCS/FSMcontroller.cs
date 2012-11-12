using UnityEngine;
using System.Collections;

public class FSMController : MonoBehaviour
{
	public FSMclass fsm = new FSMclass((int)STATE.idle);
	FSMstate[] state = new FSMstate[5];
	
	//singleton
	static FSMController _instance;
	public static FSMController Instance
	{
		get
		{
			if(_instance == null)
			{
				_instance = FindObjectOfType(typeof(FSMController)) as FSMController;
				if(_instance == null)
				{
					//현재 씬에 GameManager 컴포넌트가 없으면 새로 생성
					_instance = new GameObject("FSM Controller", 
						typeof(FSMController)).GetComponent<FSMController>();
				}
			}
			return _instance;
		}
	}
	public void Awake()
	{
		DontDestroyOnLoad(gameObject);	
		
		//idle
		state[0] = new FSMstate((int)STATE.idle, 3);
		state[0].AddTransition((int)INPUT.command_move, (int)STATE.move);
		state[0].AddTransition((int)INPUT.command_attack, (int)STATE.attack);
		state[0].AddTransition((int)INPUT.command_die, (int)STATE.die);
		
		//move
		state[1] = new FSMstate((int)STATE.move, 3);
		state[1].AddTransition((int)INPUT.command_attack, (int)STATE.attack);
		state[1].AddTransition((int)INPUT.complete_arrival, (int)STATE.idle);
		state[1].AddTransition((int)INPUT.command_die, (int)STATE.die);
		
		//attack
		state[2] = new FSMstate((int)STATE.attack, 3);
		state[2].AddTransition((int)INPUT.command_attack, (int)STATE.attack);
		state[2].AddTransition((int)INPUT.complete_arrival, (int)STATE.idle);
		state[2].AddTransition((int)INPUT.command_die, (int)STATE.die);
		
		//die
		
		//revive
		fsm.AddState(state[0]);
		fsm.AddState(state[1]);
		fsm.AddState(state[2]);
	}
	
	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
		
	public int StateTransition(int iInputID)
	{
		int returnvalue;
		returnvalue = fsm.StateTransition(iInputID);
		return returnvalue;
	}
	
	public void SetCurrentState(int iInputID)
	{
		fsm.SetCurrentState(iInputID);
	}
		
	public int GetCurrentState()
	{
		return fsm.GetCurrentState();
	}
}

