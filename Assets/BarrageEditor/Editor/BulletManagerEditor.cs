using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(BulletManager))]
public class BulletEditor : Editor {

	public override void OnInspectorGUI() {

		var obj = target as BulletManager;

		obj.bulletType = (BulletManager.BulletType)EditorGUILayout.EnumPopup ("Bullet Type", obj.bulletType);
		obj.bulletPrefab = (Bullet)EditorGUILayout.ObjectField( "Bullet Sprite", obj.bulletPrefab, typeof( Bullet ), false );
		if (obj.bulletType != BulletManager.BulletType.PatternBullets) {
			obj.shotCount = EditorGUILayout.IntField ("Shot Count", obj.shotCount);
		}

		if (obj.bulletType == BulletManager.BulletType.DirectionBullets) {
			obj._shotAngle = EditorGUILayout.FloatField ("Shot Angle", obj._shotAngle);
			obj._shotSpeed = EditorGUILayout.FloatField ("Shot Speed", obj._shotSpeed);
			obj.shotInterval = EditorGUILayout.FloatField ("Shot Interval", obj.shotInterval);

			obj.lineCount = 1;
			obj.bulletSpeedRate = 0.0f;
			obj.bulletAngleRate = 0.0f;
			obj.guideTime = 0;
		} else if (obj.bulletType == BulletManager.BulletType.SpiralBullet) {
			obj._shotAngle = EditorGUILayout.FloatField ("Start Shot Angle", obj._shotAngle);
			obj._shotSpeed = EditorGUILayout.FloatField ("Shot Speed", obj._shotSpeed);
			obj.shotInterval = EditorGUILayout.FloatField ("Shot Interval", obj.shotInterval);
			obj.shotAngleRate = EditorGUILayout.FloatField ("Shot Angle Rate", obj.shotAngleRate);

			obj.lineCount = 1;
			obj.bulletSpeedRate = 0.0f;
			obj.bulletAngleRate = 0.0f;
			obj.guideTime = 0;
		} else if (obj.bulletType == BulletManager.BulletType.MultidirectionalSpiralBullet) {
			obj._shotAngle = EditorGUILayout.FloatField ("Start Shot Angle", obj._shotAngle);
			obj._shotSpeed = EditorGUILayout.FloatField ("Shot Speed", obj._shotSpeed);
			obj.shotInterval = EditorGUILayout.FloatField ("Shot Interval", obj.shotInterval);
			obj.shotAngleRate = EditorGUILayout.FloatField ("Shot Angle Rate", obj.shotAngleRate);
			obj.lineCount = EditorGUILayout.IntField ("Spiral Count", obj.lineCount);

			obj.bulletSpeedRate = 0.0f;
			obj.bulletAngleRate = 0.0f;
			obj.guideTime = 0;
		} else if (obj.bulletType == BulletManager.BulletType.TurningAcceleratingSpiralBullet) {
			obj._shotAngle = EditorGUILayout.FloatField ("Start Shot Angle", obj._shotAngle);
			obj._shotSpeed = EditorGUILayout.FloatField ("Shot Speed", obj._shotSpeed);
			obj.shotInterval = EditorGUILayout.FloatField ("Shot Interval", obj.shotInterval);
			obj.shotAngleRate = EditorGUILayout.FloatField ("Shot Angle Rate", obj.shotAngleRate);
			obj.bulletSpeedRate = EditorGUILayout.FloatField ("Bullet Speed Rate", obj.bulletSpeedRate);
			obj.bulletAngleRate = EditorGUILayout.FloatField ("Bullet Angle Rate", obj.bulletAngleRate);

			obj.lineCount = 1;
			obj.guideTime = 0;
		} else if (obj.bulletType == BulletManager.BulletType.WashingMachineSpiralBullets) {
			obj._shotAngle = EditorGUILayout.FloatField ("Start Shot Angle", obj._shotAngle);
			obj._shotSpeed = EditorGUILayout.FloatField ("Shot Speed", obj._shotSpeed);
			obj.shotInterval = EditorGUILayout.FloatField ("Shot Interval", obj.shotInterval);
			obj.maxShotAngleRate = EditorGUILayout.FloatField ("Max Shot Angle Rate", obj.maxShotAngleRate);
			obj.maxBulletAngleRate = EditorGUILayout.FloatField ("Max Bullet Angle Rate", obj.maxBulletAngleRate);
			obj.lineCount = EditorGUILayout.IntField ("Spiral Count", obj.lineCount);
			EditorGUILayout.LabelField ("Washing Process Intervals");
			obj.wInterval_1 = EditorGUILayout.FloatField ("Spiral Time", obj.wInterval_1);
			obj.wInterval_2 = EditorGUILayout.FloatField ("Spiral to Reverse Spiral Time", obj.wInterval_2);
			obj.wInterval_3 = EditorGUILayout.FloatField ("Reverse Spiral Time", obj.wInterval_3);
			obj.wInterval_4 = EditorGUILayout.FloatField ("Reverse Spiral to Spiral Time", obj.wInterval_4);
			EditorGUILayout.Space ();

			obj.shotAngleRate = 0.0f;
			obj.shotAngleRange = 360.0f;
			obj.bulletSpeedRate = 0.0f;
			obj.bulletAngleRate = 0.0f;
			obj.guideTime = 0;
		} else if (obj.bulletType == BulletManager.BulletType.NWayBullets) {
			obj._shotAngle = EditorGUILayout.FloatField ("Shot Angle", obj._shotAngle);
			obj._shotSpeed = EditorGUILayout.FloatField ("Shot Speed", obj._shotSpeed);
			obj.shotInterval = EditorGUILayout.FloatField ("Shot Interval", obj.shotInterval);
			obj.shotAngleRange = EditorGUILayout.FloatField ("Shot Range", obj.shotAngleRange);
			obj.lineCount = EditorGUILayout.IntField ("N Count", obj.lineCount);
			
			obj.bulletSpeedRate = 0.0f;
			obj.bulletAngleRate = 0.0f;
			obj.guideTime = 0;
		} else if (obj.bulletType == BulletManager.BulletType.CircularBullet) {
			obj._shotAngle = EditorGUILayout.FloatField ("Shot Angle", obj._shotAngle);
			obj._shotSpeed = EditorGUILayout.FloatField ("Shot Speed", obj._shotSpeed);
			obj.shotInterval = EditorGUILayout.FloatField ("Shot Interval", obj.shotInterval);
			obj.lineCount = EditorGUILayout.IntField ("Line Count", obj.lineCount);

			obj.shotAngleRange = 360;
			obj.bulletSpeedRate = 0.0f;
			obj.bulletAngleRate = 0.0f;
			obj.guideTime = 0;
		} else if (obj.bulletType == BulletManager.BulletType.TurningAcceleratedCircularBullet) {
			obj._shotAngle = EditorGUILayout.FloatField ("Shot Angle", obj._shotAngle);
			obj._shotSpeed = EditorGUILayout.FloatField ("Shot Speed", obj._shotSpeed);
			obj.shotInterval = EditorGUILayout.FloatField ("Shot Interval", obj.shotInterval);
			obj.lineCount = EditorGUILayout.IntField ("Line Count", obj.lineCount);
			obj.shotAngleRate = EditorGUILayout.FloatField ("Shot Angle Rate", obj.shotAngleRate);
			obj.bulletSpeedRate = EditorGUILayout.FloatField ("Bullet Speed Rate", obj.bulletSpeedRate);
			obj.bulletAngleRate = EditorGUILayout.FloatField ("Bullet Angle Rate", obj.bulletAngleRate);

			obj.shotAngleRange = 360;
			obj.guideTime = 0;
		} else if (obj.bulletType == BulletManager.BulletType.AimNWayBullets) {
			obj._shotSpeed = EditorGUILayout.FloatField ("Shot Speed", obj._shotSpeed);
			obj.shotInterval = EditorGUILayout.FloatField ("Shot Interval", obj.shotInterval);
			obj.shotAngleRange = EditorGUILayout.FloatField ("Shot Range", obj.shotAngleRange);
			obj.lineCount = EditorGUILayout.IntField ("N Count", obj.lineCount);
			obj.targetTag = EditorGUILayout.TextField ("Target Tag Name", obj.targetTag);
			
			obj.bulletSpeedRate = 0.0f;
			obj.bulletAngleRate = 0.0f;
			obj.guideTime = 0;
		} else if (obj.bulletType == BulletManager.BulletType.AimRandomNWayBullets) {
			obj._shotSpeed = EditorGUILayout.FloatField ("Shot Speed", obj._shotSpeed);
			obj.shotInterval = EditorGUILayout.FloatField ("Shot Interval", obj.shotInterval);
			obj.shotAngleRange = EditorGUILayout.FloatField ("Shot Range", obj.shotAngleRange);
			obj.lineCount = EditorGUILayout.IntField ("N Count", obj.lineCount);
			obj.targetTag = EditorGUILayout.TextField ("Target Tag Name", obj.targetTag);
			obj.randomRange = EditorGUILayout.FloatField ("Random Range", obj.randomRange);
			
			obj.bulletSpeedRate = 0.0f;
			obj.bulletAngleRate = 0.0f;
			obj.guideTime = 0;
		} else if (obj.bulletType == BulletManager.BulletType.RandomCircularBullet) {
			obj._shotAngle = EditorGUILayout.FloatField ("Shot Angle", obj._shotAngle);
			obj._shotSpeed = EditorGUILayout.FloatField ("Shot Speed", obj._shotSpeed);
			obj.shotInterval = EditorGUILayout.FloatField ("Shot Interval", obj.shotInterval);
			obj.lineCount = EditorGUILayout.IntField ("Line Count", obj.lineCount);
			obj.randomRange = EditorGUILayout.FloatField ("Random Range", obj.randomRange);

			obj.shotAngleRange = 360;
			obj.bulletSpeedRate = 0.0f;
			obj.bulletAngleRate = 0.0f;
			obj.guideTime = 0;
		} else if (obj.bulletType == BulletManager.BulletType.RotationNWayBullets) {
			obj._shotAngle = EditorGUILayout.FloatField ("Shot Angle", obj._shotAngle);
			obj._shotSpeed = EditorGUILayout.FloatField ("Shot Speed", obj._shotSpeed);
			obj.shotInterval = EditorGUILayout.FloatField ("Shot Interval", obj.shotInterval);
			obj.shotAngleRange = EditorGUILayout.FloatField ("Shot Range", obj.shotAngleRange);
			obj.bulletAngleRate = EditorGUILayout.FloatField ("Bullet Angle Rate", obj.bulletAngleRate);
			obj.lineCount = EditorGUILayout.IntField ("N Count", obj.lineCount);
			
			obj.bulletSpeedRate = 0.0f;
			obj.guideTime = 0;
		} else if (obj.bulletType == BulletManager.BulletType.WavyNWayBullets) {
			obj._shotAngle = EditorGUILayout.FloatField ("Shot Angle", obj._shotAngle);
			obj._shotSpeed = EditorGUILayout.FloatField ("Shot Speed", obj._shotSpeed);
			obj.shotInterval = EditorGUILayout.FloatField ("Shot Interval", obj.shotInterval);
			obj.shotAngleRange = EditorGUILayout.FloatField ("Shot Range", obj.shotAngleRange);
			obj.wavingAngleRange = EditorGUILayout.FloatField ("Waving Angle Range", obj.wavingAngleRange);
			obj.cycle = EditorGUILayout.FloatField ("Waving Cycle", obj.cycle);
			obj.lineCount = EditorGUILayout.IntField ("N Count", obj.lineCount);
			
			obj.bulletSpeedRate = 0.0f;
			obj.bulletAngleRate = 0.0f;
			obj.guideTime = 0;
		} else if (obj.bulletType == BulletManager.BulletType.WavyCircularBullet) {
			obj._shotAngle = EditorGUILayout.FloatField ("Shot Angle", obj._shotAngle);
			obj._shotSpeed = EditorGUILayout.FloatField ("Shot Speed", obj._shotSpeed);
			obj.shotInterval = EditorGUILayout.FloatField ("Shot Interval", obj.shotInterval);
			obj.wavingAngleRange = EditorGUILayout.FloatField ("Waving Angle Range", obj.wavingAngleRange);
			obj.cycle = EditorGUILayout.FloatField ("Waving Cycle", obj.cycle);
			obj.lineCount = EditorGUILayout.IntField ("Line Count", obj.lineCount);

			obj.shotAngleRange = 360;
			obj.bulletSpeedRate = 0.0f;
			obj.bulletAngleRate = 0.0f;
			obj.guideTime = 0;
		} else if (obj.bulletType == BulletManager.BulletType.WinderBullet) {
			obj.shotAngleBase = EditorGUILayout.FloatField ("Shot Angle", obj.shotAngleBase);
			obj._shotSpeed = EditorGUILayout.FloatField ("Shot Speed", obj._shotSpeed);
			obj.shotInterval = EditorGUILayout.FloatField ("Shot Interval", obj.shotInterval);
			obj.shotAngleRange = EditorGUILayout.FloatField ("Shot Range", obj.shotAngleRange);
			obj.winderAngleRange = EditorGUILayout.FloatField("Winder Angle Range", obj.winderAngleRange);
			obj.cycle = EditorGUILayout.FloatField ("Winder Cycle", obj.cycle);
			obj.lineCount = EditorGUILayout.IntField ("Line Count", obj.lineCount);

			obj.bulletSpeedRate = 0.0f;
			obj.bulletAngleRate = 0.0f;
			obj.guideTime = 0;
		} else if (obj.bulletType == BulletManager.BulletType.DiffusionBullets) {
			obj._shotAngle = EditorGUILayout.FloatField ("Shot Angle", obj._shotAngle);
			obj._shotSpeed = EditorGUILayout.FloatField ("Shot Speed", obj._shotSpeed);
			obj.shotAngleRange = EditorGUILayout.FloatField ("Shot Range", obj.shotAngleRange);
			obj.shotSpeedRate = EditorGUILayout.FloatField("Shot Speed Rate", obj.shotSpeedRate);
			obj.lineCount = EditorGUILayout.IntField ("Line Count", obj.lineCount);

			obj.shotInterval = 0.0f;
			obj.bulletSpeedRate = 0.0f;
			obj.bulletAngleRate = 0.0f;
			obj.guideTime = 0;
		} else if (obj.bulletType == BulletManager.BulletType.RandomDiffusionBullets) {
			obj._shotAngle = EditorGUILayout.FloatField ("Shot Angle", obj._shotAngle);
			obj._shotSpeed = EditorGUILayout.FloatField ("Shot Speed", obj._shotSpeed);
			obj.shotAngleRange = EditorGUILayout.FloatField ("Shot Range", obj.shotAngleRange);

			EditorGUILayout.LabelField ("Random Shot Speed Range ");
			obj.randomRangeMin = EditorGUILayout.FloatField ("Min", obj.randomRangeMin);
			obj.randomRangeMax = EditorGUILayout.FloatField ("Max", obj.randomRangeMax);
			EditorGUILayout.Space();

			obj.lineCount = EditorGUILayout.IntField ("Line Count", obj.lineCount);
			
			obj.shotInterval = 0.0f;
			obj.bulletSpeedRate = 0.0f;
			obj.bulletAngleRate = 0.0f;
			obj.guideTime = 0;
		} else if (obj.bulletType == BulletManager.BulletType.OvertakingBullets) {
			obj._shotAngle = EditorGUILayout.FloatField ("Shot Angle", obj._shotAngle);
			obj._shotSpeed = EditorGUILayout.FloatField ("Shot Speed", obj._shotSpeed);
			obj.shotSpeedRate = EditorGUILayout.FloatField ("Add Speed Rate", obj.shotSpeedRate);
			obj.shotInterval = EditorGUILayout.FloatField ("Shot Interval", obj.shotInterval);
			obj.shotAngleRange = EditorGUILayout.FloatField ("Shot Range", obj.shotAngleRange);
			obj.lineCount = EditorGUILayout.IntField ("Line Count", obj.lineCount);

			obj.bulletSpeedRate = 0.0f;
			obj.bulletAngleRate = 0.0f;
			obj.guideTime = 0;
		} else if (obj.bulletType == BulletManager.BulletType.CurveOvertakingBullets) {
			obj._shotAngle = EditorGUILayout.FloatField ("Shot Angle", obj._shotAngle);
			obj._shotSpeed = EditorGUILayout.FloatField ("Shot Speed", obj._shotSpeed);
			obj.shotAngleRate = EditorGUILayout.FloatField ("Shot Angle Rate", obj.shotAngleRate);
			obj.shotSpeedRate = EditorGUILayout.FloatField ("Add Speed Rate", obj.shotSpeedRate);
			obj.shotInterval = EditorGUILayout.FloatField ("Shot Interval", obj.shotInterval);
			obj.shotAngleRange = EditorGUILayout.FloatField ("Shot Range", obj.shotAngleRange);
			obj.lineCount = EditorGUILayout.IntField ("Line Count", obj.lineCount);

			obj.bulletSpeedRate = 0.0f;
			obj.bulletAngleRate = 0.0f;
			obj.guideTime = 0;
		} else if (obj.bulletType == BulletManager.BulletType.GuidedMissile) {
			obj._shotSpeed = EditorGUILayout.FloatField ("Shot Speed", obj._shotSpeed);
			obj.shotInterval = EditorGUILayout.FloatField ("Shot Interval", obj.shotInterval);
			obj.guideTime = EditorGUILayout.FloatField("Guide Time", obj.guideTime);
			obj.targetTag = EditorGUILayout.TextField ("Target Tag Name", obj.targetTag);

			obj.lineCount = 1;
			obj.shotAngleRange = 0.0f;
			obj.bulletSpeedRate = 0.0f;
			obj.bulletAngleRate = 0.0f;
		} else if (obj.bulletType == BulletManager.BulletType.PatternBullets) {
			obj._shotAngle = EditorGUILayout.FloatField ("Shot Angle", obj._shotAngle);
			obj._shotSpeed = EditorGUILayout.FloatField ("Shot Speed", obj._shotSpeed);
			obj.shotAngleRange = EditorGUILayout.FloatField("Shot Angle Range", obj.shotAngleRange);
			obj.shotInterval = EditorGUILayout.FloatField ("Shot Interval", obj.shotInterval);
			obj.pattern = EditorGUILayout.TextArea(obj.pattern, GUILayout.Height(96.0f));

			obj.bulletSpeedRate = 0.0f;
			obj.bulletAngleRate = 0.0f;
		}


		if(GUILayout.Button("Shot"))
		{
			obj.Shot();
		}
	}

}
