using UnityEngine;
using System.Collections;

using System.Collections.Generic;

public class FSMclass {
	
	//FSmclass 내부에서만 사용할것 외부로 사용 금지
	private static FSMstate temp_state = new FSMstate();
	public Dictionary<int, FSMstate> m_map = new Dictionary<int, FSMstate>();
	int m_iCurrentState;
	
	//void Awake() {
	//}
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	//void Update () {
	//}
	
	
	public FSMclass(int iStateID){
		m_iCurrentState = iStateID;
	}
	
	public int GetCurrentState(){
		return m_iCurrentState;
	}
	
	public void SetCurrentState(int iStateID){
		m_iCurrentState = iStateID;	
	}
	
	//temp_state 사용 
	public FSMstate GetState(int iStateID){
		//temp_state = null;
		if (m_map.TryGetValue(iStateID, out temp_state)){
			//Debug.Log("success");
		}
		else{
			Debug.Log("fail");
			return null;
		}
		
		return temp_state;
	}
	
	//temp_state 사용 
	//m_map에 FSmstate를 추가한다.
	public void AddState(FSMstate state){
		if (m_map.TryGetValue(state.GetID(), out temp_state)){
			Debug.Log("Add fail : already state");
			return;
		}
		else{
			m_map[state.GetID()] = state;
			//Debug.Log("Add success");
		}
	}
	
	//temp_state 사용 
	//m_map에 FSmstate를 삭제한다.
	public void DeleteState(int iState){
		if (m_map.TryGetValue(iState, out temp_state)){
			Debug.Log("Delete state find");
			if(temp_state.GetID() == iState){
				m_map.Remove(temp_state.GetID());
				Debug.Log("Delete success");
			}
		}
		else{
			Debug.Log("Delete fail : not find");
		}
	}
	
	//temp_state 사용
	//입력과 현재 상태에 기반해서 상태 전이를 수행한다.
	public int StateTransition(int iInput){
		//temp_state = null;
		if(m_iCurrentState <= 0)
		{
			Debug.Log("m_iCurrentState <= 0");
			return m_iCurrentState;
		}
		
		temp_state = GetState(m_iCurrentState);
		if(temp_state == null){
			//문제가 있음을 알린다. 
			m_iCurrentState = 0;
			Debug.Log("FAIL : temp_state == null");
			return m_iCurrentState;
		}
		
		//active transition
		m_iCurrentState = temp_state.GetOutputs(iInput);
		
		Debug.Log("m_iCurrentState : " + m_iCurrentState);
		return m_iCurrentState;
	}
}
