using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
    public static CheckPointManager instance;

    [SerializeField]
    private CheckPointLogic[] m_checkPoints;

    [SerializeField]
    private Vector3 m_spawnPoint;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        m_checkPoints = FindObjectsOfType<CheckPointLogic>();

        m_spawnPoint = PlayerLogic.instance.GetPlayerPosition();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DeactivateCheckPoints()
    {
        for (int i = 0; i < m_checkPoints.Length; i++)
        {
            m_checkPoints[i].ResetCheckPoint();
        }
    }

    public void SetSpawnPoint(Vector3 newSpawnPoint)
    {
        m_spawnPoint = newSpawnPoint;
    }

    public Vector3 GetSpawnPoint()
    {
        return m_spawnPoint;
    }
}
