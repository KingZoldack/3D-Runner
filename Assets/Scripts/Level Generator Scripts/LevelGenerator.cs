using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

	[SerializeField]
	int _levelLenght, _startPlatformLenght = 5, _endPlatformLength = 5, _distanceBetweenPlatforms, _minPlatformLength, _maxPlatformLength;

	[SerializeField]
	float _minYPlatformPos = 0f, _maxYPlatformPos = 10f, _monsterSpawnRate = 0.25f, _collectableSpawnRate = 0.1f, _minYHealthCollectablePos, _maxYHealthCollectablePos;

	[SerializeField]
	Transform _platform, _platformParent, _monstaer, _monsterParent, _healthCollectable, _healthCollectableParent;

	float _platformLastPosX;


	
	// Use this for initialization
	void Start () {
		
	}
	
	
}
