using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	[HideInInspector]
	public SpriteRenderer sprite;

	[HideInInspector]
	public float shotSpeed;

	[HideInInspector]
	public float bulletSpeedRate;

	[HideInInspector]
	public float shotAngle;
	private float _shotAngle;

	[HideInInspector]
	public float bulletAngleRate;

	[HideInInspector]
	public float guideTime;

	[HideInInspector]
	public string targetTagName;

	private Vector3 tmp = Vector3.zero;

	void Awake () {
		sprite = gameObject.GetComponent (typeof(SpriteRenderer)) as SpriteRenderer;
	}

	void Start() {
	}

	void Update() {

		if (guideTime > 0) {
			float __shotAngle = SetTarget(targetTagName, guideTime);
			tmp.x = Mathf.Cos (__shotAngle * Mathf.Deg2Rad);
			tmp.y = Mathf.Sin (__shotAngle * Mathf.Deg2Rad);
			guideTime -= Time.deltaTime;
		}

		transform.position += (tmp * shotSpeed * Time.deltaTime);
		shotSpeed += bulletSpeedRate * Time.deltaTime;
		shotAngle += bulletAngleRate * Time.deltaTime;

		if (_shotAngle != shotAngle) {
			transform.rotation = Quaternion.AngleAxis(shotAngle - 90.0f, Vector3.forward );
			_shotAngle = shotAngle;
		}
	}

	public void Calc() {
		tmp.x = Mathf.Cos (shotAngle * Mathf.Deg2Rad);
		tmp.y = Mathf.Sin (shotAngle * Mathf.Deg2Rad);
		transform.rotation = Quaternion.AngleAxis(shotAngle - 90.0f, Vector3.forward );
		_shotAngle = shotAngle;
	}

	public void Wakeup() {
		enabled = true;
		sprite.enabled = true;
	}

	public float SetTarget(string targetTagName, float guideTime) {
		this.targetTagName = targetTagName;
		this.guideTime = guideTime;
		var t = GameObject.FindWithTag(targetTagName);
		if (t) {
			shotAngle = GetAim(transform.position, t.transform.position);
		} else {
			Debug.LogError("Target Tag Not Found!!!");
		}
		return shotAngle;
	}

	private float GetAim(Vector2 p1, Vector2 p2) {
		float dx = p2.x - p1.x;
		float dy = p2.y - p1.y;
		float rad = Mathf.Atan2(dy, dx);
		return rad * Mathf.Rad2Deg;
	}

	void OnBecameInvisible() {
		enabled = false;
		sprite.enabled = false;
	}
}
