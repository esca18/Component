using UnityEngine;
using System.Collections;

public class FSMController : MonoBehaviour
{
	//Movement Layer
	public enum MOVEMENT_INPUT
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
	
	public enum MOVEMENT_STATE
	{
		none,
		idle,
		move,
		attack,
		die,
		revive,
		cnt
	};
	
	//Action Layer
	public enum ACTION_INPUT
	{
		none,
		Hkey,
		Skey,
		MouseRightGround,
		MkeyGround,
		MouseRightAlly,
		MkeyAlly,
		MkeyEnemy,
		AkeyGround,
		AkeyTarget,
		Arrival,
		cnt
	};
	
	public enum ACTION_STATE
	{
		None,
		Hold,
		Stop,
		MoveGround,
		MoveAlly,
		MoveEnemy,
		AttackGround,
		AttackTarget,
		cnt
	};
	
	//combat
	public enum COMBAT
	{
		DontFindEnemy,
		FindEnemy,
		AttackEnemy,
		EnemyDead
	};
	
	public FSMclass movement_fsm = new FSMclass((int)MOVEMENT_STATE.idle);
	FSMstate[] movement_state = new FSMstate[5];
	MOVEMENT_STATE _MovementLayerState;
	MOVEMENT_INPUT _MovementLayerLastInput;
	
	public FSMclass action_fsm = new FSMclass((int)ACTION_STATE.Hold);
	FSMstate[] action_state = new FSMstate[5];
	ACTION_STATE _ActionLayerState;
	ACTION_INPUT _ActionLayerLastInput;
	
	COMBAT _combat;
	
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
		
		//////////////Movement Layer/////////////////////
		//idle
		movement_state[0] = new FSMstate((int)MOVEMENT_STATE.idle, 3);
		movement_state[0].AddTransition((int)MOVEMENT_INPUT.command_move, (int)MOVEMENT_STATE.move);
		movement_state[0].AddTransition((int)MOVEMENT_INPUT.command_attack, (int)MOVEMENT_STATE.attack);
		movement_state[0].AddTransition((int)MOVEMENT_INPUT.command_die, (int)MOVEMENT_STATE.die);
		
		//move
		movement_state[1] = new FSMstate((int)MOVEMENT_STATE.move, 3);
		movement_state[1].AddTransition((int)MOVEMENT_INPUT.command_attack, (int)MOVEMENT_STATE.attack);
		movement_state[1].AddTransition((int)MOVEMENT_INPUT.complete_arrival, (int)MOVEMENT_STATE.idle);
		movement_state[1].AddTransition((int)MOVEMENT_INPUT.command_die, (int)MOVEMENT_STATE.die);
		
		//attack
		movement_state[2] = new FSMstate((int)MOVEMENT_STATE.attack, 3);
		movement_state[2].AddTransition((int)MOVEMENT_INPUT.command_move, (int)MOVEMENT_STATE.move);
		movement_state[2].AddTransition((int)MOVEMENT_INPUT.complete_arrival, (int)MOVEMENT_STATE.idle);
		movement_state[2].AddTransition((int)MOVEMENT_INPUT.command_die, (int)MOVEMENT_STATE.die);
		
		//die
		movement_state[3] = new FSMstate((int)MOVEMENT_STATE.die, 1);
		movement_state[3].AddTransition((int)MOVEMENT_INPUT.command_die, (int)MOVEMENT_STATE.revive);
		
		//revive
		movement_state[4] = new FSMstate((int)MOVEMENT_STATE.revive, 1);
		movement_state[4].AddTransition((int)MOVEMENT_INPUT.complete_revive, (int)MOVEMENT_STATE.idle);
		
		movement_fsm.AddState(movement_state[0]);
		movement_fsm.AddState(movement_state[1]);
		movement_fsm.AddState(movement_state[2]);
		movement_fsm.AddState(movement_state[3]);
		movement_fsm.AddState(movement_state[4]);
		
		//////////////Action Layer/////////////////////
		//Hold
		action_state[0] =  new FSMstate((int)ACTION_STATE.Hold, 10);
		action_state[0].AddTransition((int)ACTION_INPUT.Hkey, (int)ACTION_STATE.Hold);
		action_state[0].AddTransition((int)ACTION_INPUT.Arrival, (int)ACTION_STATE.Hold);
		action_state[0].AddTransition((int)ACTION_INPUT.Skey, (int)ACTION_STATE.Stop);
		action_state[0].AddTransition((int)ACTION_INPUT.MouseRightGround, (int)ACTION_STATE.MoveGround);
		action_state[0].AddTransition((int)ACTION_INPUT.MkeyGround, (int)ACTION_STATE.MoveGround);
		action_state[0].AddTransition((int)ACTION_INPUT.MouseRightAlly, (int)ACTION_STATE.MoveAlly);
		action_state[0].AddTransition((int)ACTION_INPUT.MkeyAlly, (int)ACTION_STATE.MoveAlly);
		action_state[0].AddTransition((int)ACTION_INPUT.MkeyEnemy, (int)ACTION_STATE.MoveEnemy);
		action_state[0].AddTransition((int)ACTION_INPUT.AkeyGround, (int)ACTION_STATE.AttackGround);
		action_state[0].AddTransition((int)ACTION_INPUT.AkeyTarget, (int)ACTION_STATE.AttackTarget);
		
		//Stop
		action_state[1] =  new FSMstate((int)ACTION_STATE.Stop, 10);
		action_state[1].AddTransition((int)ACTION_INPUT.Hkey, (int)ACTION_STATE.Hold);
		action_state[1].AddTransition((int)ACTION_INPUT.Arrival, (int)ACTION_STATE.Hold);
		action_state[1].AddTransition((int)ACTION_INPUT.Skey, (int)ACTION_STATE.Stop);
		action_state[1].AddTransition((int)ACTION_INPUT.MouseRightGround, (int)ACTION_STATE.MoveGround);
		action_state[1].AddTransition((int)ACTION_INPUT.MkeyGround, (int)ACTION_STATE.MoveGround);
		action_state[1].AddTransition((int)ACTION_INPUT.MouseRightAlly, (int)ACTION_STATE.MoveAlly);
		action_state[1].AddTransition((int)ACTION_INPUT.MkeyAlly, (int)ACTION_STATE.MoveAlly);
		action_state[1].AddTransition((int)ACTION_INPUT.MkeyEnemy, (int)ACTION_STATE.MoveEnemy);
		action_state[1].AddTransition((int)ACTION_INPUT.AkeyGround, (int)ACTION_STATE.AttackGround);
		action_state[1].AddTransition((int)ACTION_INPUT.AkeyTarget, (int)ACTION_STATE.AttackTarget);
		
		//MoveGround
		action_state[2] =  new FSMstate((int)ACTION_STATE.MoveGround, 10);
		action_state[2].AddTransition((int)ACTION_INPUT.Hkey, (int)ACTION_STATE.Hold);
		action_state[2].AddTransition((int)ACTION_INPUT.Arrival, (int)ACTION_STATE.Hold);
		action_state[2].AddTransition((int)ACTION_INPUT.Skey, (int)ACTION_STATE.Stop);
		action_state[2].AddTransition((int)ACTION_INPUT.MouseRightGround, (int)ACTION_STATE.MoveGround);
		action_state[2].AddTransition((int)ACTION_INPUT.MkeyGround, (int)ACTION_STATE.MoveGround);
		action_state[2].AddTransition((int)ACTION_INPUT.MouseRightAlly, (int)ACTION_STATE.MoveAlly);
		action_state[2].AddTransition((int)ACTION_INPUT.MkeyAlly, (int)ACTION_STATE.MoveAlly);
		action_state[2].AddTransition((int)ACTION_INPUT.MkeyEnemy, (int)ACTION_STATE.MoveEnemy);
		action_state[2].AddTransition((int)ACTION_INPUT.AkeyGround, (int)ACTION_STATE.AttackGround);
		action_state[2].AddTransition((int)ACTION_INPUT.AkeyTarget, (int)ACTION_STATE.AttackTarget);
		
		action_fsm.AddState(action_state[0]);
		action_fsm.AddState(action_state[1]);
		action_fsm.AddState(action_state[2]);
		
	}
	
	// Use this for initialization
	void Start ()
	{
		ActionLayerStateTransition(ACTION_INPUT.Hkey);
		_combat = COMBAT.FindEnemy;
	}
	
	// Update is called once per frame
	void Update ()
	{
		//ActionLayer Update
		switch(_ActionLayerState)
		{
			case ACTION_STATE.Hold:
				InHold();
				break;
			case ACTION_STATE.Stop:
				InStop();
				break;
			case ACTION_STATE.MoveGround:
				InMoveGround();
				break;
		}
		
	}
	
	//movement fsm
	public MOVEMENT_STATE MovementLayerStateTransition(MOVEMENT_INPUT iInputID)
	{
		_MovementLayerLastInput = iInputID;
		_MovementLayerState = (MOVEMENT_STATE)movement_fsm.StateTransition((int)iInputID);
		return _MovementLayerState;
	}
			
	public MOVEMENT_STATE GetMovementLayerCurrentState()
	{
		return (MOVEMENT_STATE)movement_fsm.GetCurrentState();
	}
	
	//action fsm
	public ACTION_STATE ActionLayerStateTransition(ACTION_INPUT iInputID)
	{
		_ActionLayerLastInput = iInputID;
		_ActionLayerState = (ACTION_STATE)action_fsm.StateTransition((int)iInputID);
		
		if(_ActionLayerState == ACTION_STATE.Hold){
			_combat = COMBAT.FindEnemy;
		}
			
		return _ActionLayerState;
	}
			
	public ACTION_STATE GetActionLayerCurrentState()
	{
		return (ACTION_STATE)action_fsm.GetCurrentState();
	}
	
	//action function
	private void InHold()
	{
		Debug.Log("InHold");
		switch(_combat)
		{
		case COMBAT.DontFindEnemy:
			break;
		case COMBAT.FindEnemy:
			MovementLayerStateTransition(MOVEMENT_INPUT.complete_arrival);
			FindEnemy();
			break;
		case COMBAT.AttackEnemy:
			MovementLayerStateTransition(MOVEMENT_INPUT.command_attack);
			AttackEnemy();
			break;
		case COMBAT.EnemyDead:
			MovementLayerStateTransition(MOVEMENT_INPUT.complete_attack);
			EnemyDead();
			break;
		}
	}
	
	private void InStop()
	{
		DontFindEnemy();
		MovementLayerStateTransition(MOVEMENT_INPUT.complete_arrival);
		Debug.Log("InStop");
	}
	private void InMoveGround()
	{
		DontFindEnemy();
		MovementLayerStateTransition(MOVEMENT_INPUT.command_move);
		Debug.Log("InMoveGround");
	}
	
	private void DontFindEnemy()
	{
		_combat =  COMBAT.DontFindEnemy;
	}
	private void FindEnemy()
	{
		Debug.Log("FindEnemy");
		if(EnemyTest.getFind()){
			Debug.Log("success find");
			_combat = COMBAT.AttackEnemy;
		}
		else{
			Debug.Log("fail find");
			_combat = COMBAT.FindEnemy;
		}
	}
	
	private void AttackEnemy()
	{
		Debug.Log("AttackEnemy");
		//_combat = COMBAT.EnemyDead;
	}
	
	private void EnemyDead()
	{
		Debug.Log("EnemyDead");
		_combat = COMBAT.FindEnemy;
		ActionLayerStateTransition(_ActionLayerLastInput);
	}
	
	
}

