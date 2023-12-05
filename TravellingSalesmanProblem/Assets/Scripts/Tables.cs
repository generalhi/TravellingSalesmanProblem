using System.Collections.Generic;
using Helpers;
using UnityEngine;

public class Tables
{
    private List<Vector3> _points;
    private int[] _indices;
    private ConnectionsTable _connections;
    private int[,] _multiplicity;
    private float[] _pathLength;
    private int _minIndex;

    public void Run(List<Vector3> points)
    {
        _points = points;
        CreateTableElements();
        _connections = new ConnectionsTable(_points);

        var f = MathHelper.Factorial(_points.Count - 1);
        _multiplicity = new int[f, _points.Count - 1];
        _pathLength = new float[f];

        var multiplicityIndex = 0;
        Step(_indices, 0, _indices.Length - 1, ref multiplicityIndex);

        CalcPathLength();
        _minIndex = GetMinPathIndex();
    }

    private void CreateTableElements()
    {
        _indices = new int[_points.Count - 1];
        for (var i = 0; i < _points.Count - 1; i++)
        {
            _indices[i] = i + 1;
        }
    }

    private void Step(int[] indices, int i, int n, ref int multiplicityIndex)
    {
        if (i == n)
        {
            ArrayHelper.Copy(in indices, ref _multiplicity, multiplicityIndex);
            multiplicityIndex++;
        }
        else
        {
            for (var j = i; j <= n; j++)
            {
                ArrayHelper.Swap(ref indices[i], ref indices[j]);
                Step(indices, i + 1, n, ref multiplicityIndex);
                ArrayHelper.Swap(ref indices[i], ref indices[j]);
            }
        }
    }

    private void CalcPathLength()
    {
        for (var i = 0; i < _pathLength.Length; i++)
        {
            var distance = 0f;
            var a = 0;
            var b = _multiplicity[i, 0];
            distance += _connections[a, b].Distance;
            for (var j = 0; j < _indices.Length - 1; j++)
            {
                a = _multiplicity[i, j];
                b = _multiplicity[i, j + 1];
                distance += _connections[a, b].Distance;
            }

            a = _multiplicity[i, _indices.Length - 1];
            b = 0;
            distance += _connections[a, b].Distance;

            _pathLength[i] = distance;
        }
    }

    private int GetMinPathIndex()
    {
        var min = float.PositiveInfinity;
        var minI = -1;
        for (var i = 0; i < _pathLength.Length; i++)
        {
            if (_pathLength[i] < min)
            {
                min = _pathLength[i];
                minI = i;
            }
        }

        return minI;
    }

    public void GizmosDrawAllConnections()
    {
        for (var i = 0; i < _points.Count; i++)
        {
            for (var j = i + 1; j < _points.Count; j++)
            {
                //if (_connections[i, j].Enable)
                //{
                Gizmos.color = Color.grey;
                //}
                //else
                //{
                //    Gizmos.color = Color.magenta;                    
                //}
                Gizmos.DrawLine(_points[i], _points[j]);
            }
        }
    }

    public void GizmosDrawPath()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(_points[0], _points[_multiplicity[_minIndex, 0]]);
        for (var i = 0; i < _indices.Length - 1; i++)
        {
            var a = _multiplicity[_minIndex, i];
            var b = _multiplicity[_minIndex, i + 1];
            Gizmos.DrawLine(_points[a], _points[b]);
        }

        Gizmos.DrawLine(_points[_multiplicity[_minIndex, _indices.Length - 1]], _points[0]);
    }
}
