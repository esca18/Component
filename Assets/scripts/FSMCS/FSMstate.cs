using UnityEngine;
using System.Collections;
using System;

public class FSMstate {
	
	public int m_iNumberOfTransitions;
	public ArrayList m_arrInputs;
	public ArrayList m_arrOutputs;
	public int m_iStateID;
	
	//void Awake() {
	//}
	
	// Use this for initialization
	//void Start () {
	//}
	
	// Update is called once per frame
	//void Update () {
	//}
	
	
	//temp용도
	public FSMstate(){
		
	}
		
	//iStateID : 현재 상태
	//iTransitions : 상태 전이
	public FSMstate(int iStateID, int iTransitions){
		if(iTransitions <= 0)
			iTransitions = 1; //최소 하나의 전이는 존재 한다.
		else
			m_iNumberOfTransitions = iTransitions;
		
		//ID와 상태 전이 개수를 저장한다.
		m_iStateID = iStateID;
		
		try{
			m_arrInputs = new ArrayList();
			for(int i=0; i<m_iNumberOfTransitions; ++i){
				//m_arrInputs[i] = 0;	
				m_arrInputs.Add(0);
			}
				
		}
		catch( Exception e ){
			Debug.Log ("m_iNumberOfTransitions : " + m_iNumberOfTransitions);
			Debug.Log(e.ToString());
		}
		
		try{
			m_arrOutputs = new ArrayList();
			for(int i=0; i<m_iNumberOfTransitions; ++i){
				//m_arrOutputs[i] = 0;	
				m_arrOutputs.Add(0);
			}
				
		}
		catch( Exception e ){
			Debug.Log(e.ToString());
		}
	}
	
	public int GetID(){
		return m_iStateID;
	}
	
	public void AddTransition(int iInput, int iOutput){
		//m_arrInputs, m_arrOutputs 은 0으로 값을 리셋했으므로 
		//처음 만나는 0의 값이 빈값이다.
		int i = 0;
		for(; i<m_iNumberOfTransitions; ++i){
			if((int)m_arrOutputs[i] == 0)
				break;
		}
		if(i < m_iNumberOfTransitions)
		{
			m_arrOutputs[i] = iOutput;
			m_arrInputs[i] = iInput;
		}
		
	}
	
	public void DeleteTransition(int iOutput){
		int i = 0;
		for(; i<m_iNumberOfTransitions; ++i){
			if((int)m_arrOutputs[i] == iOutput)
				break;
		}
		
		//위의 for문에서 걸러내지지만...
		if(i >= m_iNumberOfTransitions)
			return;
		
		m_arrInputs[i] = 0;
		m_arrOutputs[i] = 0;
		
		for(; i<(m_iNumberOfTransitions-1); ++i){
			if((int)m_arrOutputs[i] == 0)
				break;
			
			m_arrInputs[i] = m_arrInputs[i+1];
			m_arrOutputs[i] = m_arrOutputs[i+1];
		}
		
		m_arrInputs[i] = 0;
		m_arrOutputs[i] = 0;
	}
	
	public int GetOutputs(int iInput){
		int iOutputID = m_iStateID;
		for(int i=0; i<m_iNumberOfTransitions; ++i){
			if((int)m_arrOutputs[i] == 0)
				break;
			if(iInput == (int)m_arrInputs[i]){
				iOutputID = (int)m_arrOutputs[i]; //출력 상태 ID
				break;
			}
		}
		return (iOutputID);
	}
}
