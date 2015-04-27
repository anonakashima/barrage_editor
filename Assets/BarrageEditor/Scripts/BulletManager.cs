using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BulletManager : MonoBehaviour {

	public Bullet bulletPrefab;
	List<Bullet> bulletPool = new List<Bullet>();

	public enum BulletType {
		DirectionBullets,
		SpiralBullet,
		MultidirectionalSpiralBullet,
		TurningAcceleratingSpiralBullet,
		WashingMachineSpiralBullets,
		NWayBullets,
		CircularBullet,
		TurningAcceleratedCircularBullet,
		AimNWayBullets,
		AimRandomNWayBullets,
		RandomCircularBullet,
		RotationNWayBullets,
		WavyNWayBullets,
		WavyCircularBullet,
		WinderBullet,
		DiffusionBullets,
		RandomDiffusionBullets,
		OvertakingBullets,
		CurveOvertakingBullets,
		GuidedMissile,
		PatternBullets
	};
	public BulletType bulletType;

	// All
	private int restShotCount = 0;
	public int shotCount      = 1;
	private float restInterval = 0.0f;
	public float shotInterval  = 0.0f;

	// DirectionBullets
	public float _shotAngle;
	private float shotAngle = 0.0f;
	public float _shotSpeed = 1.0f;
	private float shotSpeed;

	// SpiralBullet
	public float shotAngleRate = 1.0f;

	// TurningAcceleratingSpiralBullet
	public float bulletAngleRate = 0.0f;
	public float bulletSpeedRate = 1.0f;

	// MultidirectionalSpiralBullet
	public int lineCount = 1;

	// WashingMachineSpiralBullets
	private float timer = 0.0f;
	public float wInterval_1 = 0;
	public float wInterval_2 = 0;
	public float wInterval_3 = 0;
	public float wInterval_4 = 0;
	private float wIntervalTotal;
	public float maxShotAngleRate;
	public float maxBulletAngleRate;

	// NWayBullets
	public float shotAngleRange = 0.0f;

	// AimNWayBullets
	public string targetTag;

	// RandomNWayBullets
	public float randomRange;

	// WavyNWayBullets
	public float wavingAngleRange;
	public float cycle;

	// WinderBullet
	public float shotAngleBase;
	public float winderAngleRange;

	// DiffusionBullets
	public float shotSpeedRate;
	public float randomRangeMax;
	public float randomRangeMin;

	// OvertakingBullets
	public float addSpeedRate;

	// GuidedMissile
	public float guideTime;

	// PatternBullets
	public string pattern;
	private string[] splitedData;

	void Awake () {

	}

	// Use this for initialization
	void Start () {
		wIntervalTotal = wInterval_1 + wInterval_2 + wInterval_3 + wInterval_4;
	}
	
	// Update is called once per frame
	void Update () {


		if (restShotCount > 0) {

			restInterval -= Time.deltaTime;

			while (restShotCount > 0 && restInterval <= 0) {

				if (bulletType == BulletType.WashingMachineSpiralBullets) {
					if (timer < wInterval_1) {
						shotAngleRate = maxShotAngleRate;
						bulletAngleRate = -maxBulletAngleRate;
					} else if (timer < wInterval_1 + wInterval_2) {
						shotAngleRate = maxShotAngleRate * (wInterval_1 + (wInterval_2/2) - timer)/(wInterval_2/2);
						bulletAngleRate = -maxBulletAngleRate * (wInterval_1 + (wInterval_2/2) - timer)/(wInterval_2/2);
					} else if (timer < wInterval_1 + wInterval_2 + wInterval_3) {
						shotAngleRate = -maxShotAngleRate;
						bulletAngleRate = maxBulletAngleRate;
					} else {
						shotAngleRate = -maxShotAngleRate * (wInterval_1 + wInterval_2 + wInterval_3 + (wInterval_4/2) - timer)/(wInterval_4/2);
						bulletAngleRate = maxBulletAngleRate * (wInterval_1 + wInterval_2 + wInterval_3 + (wInterval_4/2) - timer)/(wInterval_4/2);
					}
				} else if (bulletType == BulletType.WinderBullet) {
					shotAngle = shotAngleBase + winderAngleRange * Mathf.Sin(Mathf.PI*2*timer/cycle);
				}

				for (int i = 0; i < lineCount; i++) {

					if (bulletType == BulletType.PatternBullets) {
						if (splitedData[restShotCount-1][i].Equals('0')) {
							continue;
						}
					}

					Bullet bullet = null;
					foreach (var b in bulletPool) {
						if (!b.enabled) {
							bullet = b;
							break;
						}
					}
					if (!bullet) {
						bullet = Instantiate(bulletPrefab);
						bulletPool.Add(bullet);
					}

					if (bulletType == BulletType.RandomDiffusionBullets) {
						shotSpeed = _shotSpeed + Random.Range(randomRangeMin, randomRangeMax);
					}

					bullet.transform.position = transform.position;
					bullet.transform.rotation = transform.rotation;
					bullet.shotSpeed = shotSpeed;
					bullet.shotAngle = shotAngle;
					if (bulletType == BulletType.NWayBullets
				    	|| bulletType == BulletType.CircularBullet
				    	|| bulletType == BulletType.AimNWayBullets
				    	|| bulletType == BulletType.AimRandomNWayBullets
				    	|| bulletType == BulletType.RandomCircularBullet
				    	|| bulletType == BulletType.RotationNWayBullets
				    	|| bulletType == BulletType.WavyNWayBullets
				    	|| bulletType == BulletType.WavyCircularBullet
					    || bulletType == BulletType.DiffusionBullets
					    || bulletType == BulletType.RandomDiffusionBullets
					    || bulletType == BulletType.OvertakingBullets
					    || bulletType == BulletType.CurveOvertakingBullets
					    || bulletType == BulletType.GuidedMissile
					    || bulletType == BulletType.PatternBullets) {

						if (bulletType == BulletType.AimNWayBullets
					    	|| bulletType == BulletType.AimRandomNWayBullets
						    || bulletType == BulletType.GuidedMissile) {
							shotAngle = bullet.SetTarget(targetTag, guideTime);
						}

						if (lineCount != 1) {
							float addAngle = (shotAngleRange / lineCount);
							bullet.shotAngle -= (shotAngleRange / 2.0f);
							bullet.shotAngle += addAngle * i;
						}

						if (bulletType == BulletType.AimRandomNWayBullets
					    	|| bulletType == BulletType.RandomCircularBullet) {
							bullet.shotAngle += Random.Range(-randomRange/2, randomRange/2);
						} else if (bulletType == BulletType.WavyNWayBullets
					    	|| bulletType == BulletType.WavyCircularBullet) {
							bullet.shotAngle += wavingAngleRange * Mathf.Sin(Mathf.PI*2*timer/cycle);
						}

					} else {
						bullet.shotAngle = shotAngle + (i * (360.0f/lineCount));
					}
					bullet.bulletSpeedRate = bulletSpeedRate;
					bullet.bulletAngleRate = bulletAngleRate;

					bullet.Calc();
					bullet.Wakeup();
				}

				if (bulletType == BulletType.SpiralBullet
			    	|| bulletType == BulletType.MultidirectionalSpiralBullet
			    	|| bulletType == BulletType.TurningAcceleratingSpiralBullet
			    	|| bulletType == BulletType.TurningAcceleratedCircularBullet
			    	|| bulletType == BulletType.WashingMachineSpiralBullets
			    	|| bulletType == BulletType.RotationNWayBullets
				    || bulletType == BulletType.CurveOvertakingBullets) {
					shotAngle += shotAngleRate;
				}
				if (bulletType == BulletType.DiffusionBullets
				    || bulletType == BulletType.OvertakingBullets
				    || bulletType == BulletType.CurveOvertakingBullets) {
					shotSpeed += shotSpeedRate;
				}

				restShotCount--;
				restInterval = shotInterval;
			}
		}

		UpdateTimer ();
	}

	public bool Shot() {
		if (restShotCount <= 0) {
			restShotCount = shotCount;
			restInterval  = 0.0f;
			timer = 0.0f;

			shotSpeed = _shotSpeed;
			shotAngle = _shotAngle;
			if (bulletType == BulletType.DiffusionBullets) {
				shotSpeed = _shotSpeed;
			}

			if (bulletType == BulletType.PatternBullets) {
				splitedData = pattern.Replace("\r\n", "\n").Split('\n');
				restShotCount = splitedData.Length;
				if (splitedData[0].Length > 0) {
					lineCount = splitedData[0].Length;
				} else {
					Debug.LogError("Pattern Data Not Found!!!");
				}
			}

			return true;
		}
		return false;
	}

	public List<Bullet> GetAllBullets() {
		return bulletPool;
	}

	public void ClearBulletsAndCache () {
		foreach (var b in bulletPool) {
			GameObject.Destroy(b.gameObject);
		}
		bulletPool.Clear ();
	}

	private void UpdateTimer() {
		if (bulletType == BulletType.WashingMachineSpiralBullets) {
			timer += Time.deltaTime;
			if (timer >= (wIntervalTotal)) {
				timer = 0.0f;
			}
		} else if (bulletType == BulletType.WavyNWayBullets
		           || bulletType == BulletType.WavyCircularBullet
		           || bulletType == BulletType.WinderBullet) {
			timer += Time.deltaTime;
			if (cycle <= timer) {
				timer = 0.0f;
			} 
		}
	}

	void OnValidate() {

	}
}
