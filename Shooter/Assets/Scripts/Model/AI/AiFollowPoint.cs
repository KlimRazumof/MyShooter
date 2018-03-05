using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Model.AI
{
    public class AiFollowPoint : MonoBehaviour
    {
        [SerializeField] private Transform _startPoint;
        [SerializeField] private Transform _endPoint;
        private NavMeshPath _navMeshPath; //Хранение пути, который расчитывает алгоритм А*
        private float _elapsed;

        private void Start()
        {
            _navMeshPath = GetComponent<NavMeshPath>();
            _elapsed = 0;
        }

        private void Update()
        {
            _elapsed += Time.deltaTime;

            if (_elapsed > 1.0f)
            {
                _elapsed -= 1.0f;
                NavMesh.CalculatePath(_startPoint.position, _endPoint.position, NavMesh.AllAreas, _navMeshPath);
            }

            for(var i = 0; i < _navMeshPath.corners.Length - 1; i++)
            {
                Debug.DrawLine(_navMeshPath.corners[i], _navMeshPath.corners[i + 1], Color.yellow);
            }
        }
    }
}
