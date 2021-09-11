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
	void Start()
	{
		GenerateLevel();
	}

	public enum PlatformType
    {
		None, //Empty Platform.
		Occupied //Platform has either a monster or collectable.
    }
	
	public class PlatformPositionInfo //Nested Class.
    {
		public PlatformType platformType;
		public float yPosition;
		public bool hasMonster, hasHealthCollectable;

		public PlatformPositionInfo(PlatformType type, float posY, bool hasAMonster, bool hasACollectable) //Constructor.
        {
			platformType = type;
			yPosition = posY;
			hasMonster = hasAMonster;
			hasHealthCollectable = hasACollectable;
        }
    }

	void FillOutPositionInfo(PlatformPositionInfo[] platformInfo) //Constructor.
    {
		int currentPlatformInfoIndex = 0;

        for (int i = 0; i < _startPlatformLenght; i++)
        {
			platformInfo[currentPlatformInfoIndex].platformType = PlatformType.None;
			platformInfo[currentPlatformInfoIndex].yPosition = 0f;

			currentPlatformInfoIndex++;
        }

        while (currentPlatformInfoIndex < _levelLenght - _endPlatformLength)
        {
            if (platformInfo[currentPlatformInfoIndex - 1].platformType != PlatformType.None)
            {
				currentPlatformInfoIndex++;
				continue;
            }

			float platformPositionY = Random.Range(_minYPlatformPos, _maxYPlatformPos);

			int platformLength = Random.Range(_minPlatformLength, _maxPlatformLength);

            for (int i = 0; i < platformLength; i++)
            {
				bool hasAMonstaer = Random.Range(0f, 1f) < _monsterSpawnRate;
				bool hasACollectable = Random.Range(0f, 1f) < _collectableSpawnRate;

				platformInfo[currentPlatformInfoIndex].platformType = PlatformType.Occupied;
				platformInfo[currentPlatformInfoIndex].yPosition = platformPositionY;
				platformInfo[currentPlatformInfoIndex].hasMonster = hasAMonstaer;
				platformInfo[currentPlatformInfoIndex].hasHealthCollectable = hasACollectable;

				currentPlatformInfoIndex++;

                if (currentPlatformInfoIndex > _levelLenght - _endPlatformLength)
                {
					currentPlatformInfoIndex = _levelLenght - _endPlatformLength;
					break;
                }
			}

			for (int i = 0; i < _endPlatformLength; i++)
			{
				platformInfo[currentPlatformInfoIndex].platformType = PlatformType.Occupied;
				platformInfo[currentPlatformInfoIndex].yPosition = 0f;

				currentPlatformInfoIndex++;
			}
		}
    }

	void CreatePlatformFromPositionInfo(PlatformPositionInfo[] platformPositionInfo) //Constructor
    {
        for (int i = 0; i < platformPositionInfo.Length; i++)
        {
			PlatformPositionInfo positionInfo = platformPositionInfo[i];
            if (positionInfo.platformType == PlatformType.None)
            {
				continue;
            }

			Vector3 platformPosition;
			// Checking if game has started.
			platformPosition = new Vector3(_distanceBetweenPlatforms * i, positionInfo.yPosition, 0f);
			//Save position x for later.

			Transform createBlock = (Transform)Instantiate(_platform, platformPosition, Quaternion.identity);
			createBlock.parent = _platformParent;

            if (positionInfo.hasMonster)
            {
				//code later
            }

            if (positionInfo.hasHealthCollectable)
            {
				//code later
            }
        }
    }

	public void GenerateLevel()
    {
		PlatformPositionInfo[] platformInfo = new PlatformPositionInfo[_levelLenght];

        for (int i = 0; i < platformInfo.Length; i++)
        {
			platformInfo[i] = new PlatformPositionInfo(PlatformType.None, -1f, false, false); //Using constructor.
        }

		FillOutPositionInfo(platformInfo); //Using constructor.
		CreatePlatformFromPositionInfo(platformInfo); //Using constructor.
	}

	
	
	
}
