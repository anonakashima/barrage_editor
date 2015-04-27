using UnityEngine;
using System.Collections;

public class BulletManagerUnit : MonoBehaviour {

	public BulletManager[] managers;
	private BulletManager[] _managers;

	void Awake () {
		_managers = new BulletManager[managers.Length];
		for (int i = 0; i < _managers.Length; i++) {
			var o = (BulletManager)Instantiate(managers[i], transform.position, transform.rotation);
			o.transform.position = transform.position;
			o.transform.parent = transform;
			_managers[i] = o;

		}
	}

	public void Shot() {
		foreach (var m in _managers) {
			m.Shot();
		}
	}
}
