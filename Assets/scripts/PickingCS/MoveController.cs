using UnityEngine;
using System.Collections;

public class MoveController : MonoBehaviour
{
//	int output = 1;
	private GameObject _pickHolder;
	private Pickingclass picks;
	
	public float speed;
	public Vector3 temp = new Vector3(0.0f, 0.0f, 0.0f);
	
	//singleton
	static MoveController _instance;
	public static MoveController Instance
	{
		get
		{
			if(_instance == null)
			{
				_instance = FindObjectOfType(typeof(MoveController)) as MoveController;
				if(_instance == null)
				{
					//현재 씬에 GameManager 컴포넌트가 없으면 새로 생성
					_instance = new GameObject("Move Controller", 
						typeof(MoveController)).GetComponent<MoveController>();
				}
			}
			return _instance;
		}
	}
	public void Awake()
	{
		DontDestroyOnLoad(gameObject);	
	}
	// Use this for initialization
	void Start ()
	{
		_pickHolder = new GameObject("test");
		_pickHolder.transform.parent = gameObject.transform;		
		picks = _pickHolder.AddComponent<Pickingclass>();
		picks.name = "pick";
			
		speed = 10.0f;
		temp.x = 0.0f;
		temp.y = 1.0f;
		temp.z = 0.0f;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Input.GetMouseButton(1))
		{
			temp.x = picks.transform.position.x;
			temp.y = 1.0f;
			temp.z = picks.transform.position.z;
			
			
			///!!! fix point
			FSMController.Instance.ActionLayerStateTransition(FSMController.ACTION_INPUT.MouseRightGround);
			//FSMController.Instance.SetCurrentState(output);
		}
	
		transform.LookAt(temp);
		transform.position = Vector3.MoveTowards(transform.position, temp, Time.deltaTime * speed);
		
		//Debug.Log("============== picking pos : " + temp.x.ToString() + " " +  temp.y.ToString() + " " +temp.z.ToString());
		//Debug.Log("player pos : " + transform.position.x.ToString() + " " + transform.position.y.ToString() + " " + transform.position.z.ToString());
		
		if(Input.GetKey(KeyCode.H))
		{
			FSMController.Instance.ActionLayerStateTransition(FSMController.ACTION_INPUT.Hkey);
		}
		if(Input.GetKey(KeyCode.S))
		{
			FSMController.Instance.ActionLayerStateTransition(FSMController.ACTION_INPUT.Skey);
		}
		
		if(temp == transform.position && 
			(FSMController.Instance.GetActionLayerCurrentState() == FSMController.ACTION_STATE.MoveGround))
		{
			Debug.Log("complete_arrival");
			FSMController.Instance.ActionLayerStateTransition(FSMController.ACTION_INPUT.Arrival);
		}
	}
}

