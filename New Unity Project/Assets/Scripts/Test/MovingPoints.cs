using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
namespace Tests
{
    public class MovingPoints : MonoBehaviour
    {
        [SerializeField] private Bot _agent;
        [SerializeField] private Transform _point;
        private readonly Queue<Vector3> _points = new Queue<Vector3>();
        private readonly Color _c1 = Color.red;
        private readonly Color _c = Color.blue;
        private LineRenderer _lineRenderer;
        private Camera _mainCamera;

        private NavMeshPath _path;
        private Vector3 _startPoint;

        private void Start()
        {
            var lineRendererGo = new GameObject("LineRenderer");
            _lineRenderer = lineRendererGo.AddComponent<LineRenderer>();
            _lineRenderer.startWidth = 0.5F;
            _lineRenderer.endWidth = 0.2F;

            _lineRenderer.startColor = _c;
            _lineRenderer.endColor = _c1;
            _startPoint = _agent.transform.position;
            _path = new NavMeshPath();

            _mainCamera = Camera.main;
        }

        private void Update()
        {
            if (Physics.Raycast(_mainCamera.ScreenPointToRay(Input.mousePosition), out var hit))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    DrawPoint(hit.point);
                }

                if (Time.frameCount % 2 == 0)
                {
                    NavMesh.CalculatePath(_startPoint, hit.point, NavMesh.AllAreas, _path);
                }
                else
                {
                    _lineRenderer.positionCount = _path.corners.Length;
                    //var cornersArrayCount = _points.ToArray().Length + _path.corners.Length;
                    //var cornersArray = new Vector3[cornersArrayCount];
                    //for(int i=0;i<cornersArray.Length;i++)
                    //{
                    //совместить точки на сцене и точки до курсора
                    //}
                    _lineRenderer.SetPositions(_path.corners);
                }
            }

            if (_isMove)
            {
                if (_points.Count < 0) return;
                if (!_agent.Agent.hasPath)
                {
                    var point = _points.Dequeue();
                    _agent.MovePoint(point);
                    _startPoint = point;
                }
            }
        }

        private void DrawPoint(Vector3 position)
        {
            var point = Instantiate(_point, position, Quaternion.identity);
            point.GetComponent<DestroyPoint>().OnFinishChange += MovePoint;
            _points.Enqueue(point.position);
            MovePoint();
        }

        private bool _isMove;
        private void MovePoint()
        {
            _isMove = true;
        }
    }
}