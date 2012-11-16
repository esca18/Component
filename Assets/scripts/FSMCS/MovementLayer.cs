using UnityEngine;
using System.Collections;

public class MovementLayer{
	//Movement Layer
	public enum INPUT
	{
		none,
		command_idle,
		command_move,
		command_attack,
		command_die,
		command_respwan,
		complete_arrival,
		complete_attack,
		complete_die,
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
		revive,
		cnt
	};
	

	private FSMclass _fsm;
	private bool Refresh;
	STATE _CurrentState;
	FSMstate[] _state = new FSMstate[5];
	
	public MovementLayer(){
		Refresh = false;
		//////////////Movement Layer/////////////////////
		//idle
		_state[0] = new FSMstate((int)STATE.idle, 4);
		_state[0].AddTransition((int)INPUT.command_idle, (int)STATE.idle);
		_state[0].AddTransition((int)INPUT.command_move, (int)STATE.move);
		_state[0].AddTransition((int)INPUT.command_attack, (int)STATE.attack);
		_state[0].AddTransition((int)INPUT.command_die, (int)STATE.die);
		
		//move
		_state[1] = new FSMstate((int)STATE.move, 4);
		_state[1].AddTransition((int)INPUT.command_idle, (int)STATE.idle);
		_state[1].AddTransition((int)INPUT.command_attack, (int)STATE.attack);
		_state[1].AddTransition((int)INPUT.complete_arrival, (int)STATE.idle);
		_state[1].AddTransition((int)INPUT.command_die, (int)STATE.die);
		
		//attack
		_state[2] = new FSMstate((int)STATE.attack, 4);
		_state[1].AddTransition((int)INPUT.command_idle, (int)STATE.idle);
		_state[2].AddTransition((int)INPUT.command_move, (int)STATE.move);
		_state[2].AddTransition((int)INPUT.complete_arrival, (int)STATE.idle);
		_state[2].AddTransition((int)INPUT.command_die, (int)STATE.die);
		
		//die
		_state[3] = new FSMstate((int)STATE.die, 1);
		_state[3].AddTransition((int)INPUT.complete_die, (int)STATE.revive);
		
		//revive
		_state[4] = new FSMstate((int)STATE.revive, 1);
		_state[4].AddTransition((int)INPUT.complete_revive, (int)STATE.idle);
		
		_fsm = new FSMclass((int)STATE.idle);
		_fsm.AddState(_state[0]);
		_fsm.AddState(_state[1]);
		_fsm.AddState(_state[2]);
		_fsm.AddState(_state[3]);
		_fsm.AddState(_state[4]);
		
		//idle init
		//_CurrentState = (STATE)_fsm.StateTransition((int)INPUT.command_idle);
		_CurrentState = (STATE)_fsm.GetCurrentState();
		
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public void Update () {
		SetRefresh();
		if(!Refresh)
			return;
		
		//Debug.Log ("state : " + _CurrentState);
	}
	
	void SetRefresh(){
		Refresh = true;
	}
	
	//request
	bool RequestIdle(){
		_CurrentState = (STATE)_fsm.StateTransition((int)INPUT.command_idle);
		if(STATE.idle == _CurrentState)	
			return true;
		else
			return false;
	}
	
	bool RequestMove(){
		_CurrentState = (STATE)_fsm.StateTransition((int)INPUT.command_move);
		if(STATE.move == _CurrentState)	
			return true;
		else
			return false;
	}
	
	bool RequestAttack(){
		_CurrentState = (STATE)_fsm.StateTransition((int)INPUT.command_attack);
		if(STATE.attack == _CurrentState)	
			return true;
		else
			return false;
	}
	
	bool RequestDie(){
		_CurrentState = (STATE)_fsm.StateTransition((int)INPUT.command_die);
		if(STATE.die == _CurrentState)	
			return true;
		else
			return false;
	}
	
	//complet
	//?? need STATE?
	STATE CompleteMove(){
		_CurrentState = (STATE)_fsm.StateTransition((int)INPUT.complete_arrival);
		return _CurrentState;
	}
	STATE CompleteAttack(){
		_CurrentState = (STATE)_fsm.StateTransition((int)INPUT.complete_attack);
		return _CurrentState;
	}
	STATE CompleteDie(){
		_CurrentState = (STATE)_fsm.StateTransition((int)INPUT.complete_die);
		return _CurrentState;
	}
	STATE CompleteRevive(){
		_CurrentState = (STATE)_fsm.StateTransition((int)INPUT.complete_revive);
		return _CurrentState;
	}
}
