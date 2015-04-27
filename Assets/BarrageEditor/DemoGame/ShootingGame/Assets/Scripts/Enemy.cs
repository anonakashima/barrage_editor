using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public bool unit;

	public BulletManager[] bulletManagers;
	private BulletManager[] _bulletManagers;

	public BulletManagerUnit unit1;
	public BulletManagerUnit unit2;
	public BulletManagerUnit unit3;
	public BulletManagerUnit unit4;
	public BulletManagerUnit unit5;

	private int index = 0;

	void Awake () {
		_bulletManagers = new BulletManager[bulletManagers.Length];
		for (int i = 0; i < bulletManagers.Length; i++) {
			if (bulletManagers[i] != null) {
				_bulletManagers[i] = (BulletManager)Instantiate(bulletManagers[i], transform.position, transform.rotation);
			} else {
				break;
			}
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown(KeyCode.A)) {
			if (unit) {

				if (index == 0) unit1.Shot();
				else if (index == 1) unit2.Shot();
				else if (index == 2) unit3.Shot();
				else if (index == 3) unit4.Shot();
				else if (index == 4) unit5.Shot();

			} else {
				_bulletManagers[index].Shot();
			}
		}
		if (Input.GetKeyDown(KeyCode.S)) {
			index++;
			if (unit && index >= 5) {
				index = 0;
			} else {
				if (_bulletManagers[index] == null) index = 0;
			}
		}
	}
}
