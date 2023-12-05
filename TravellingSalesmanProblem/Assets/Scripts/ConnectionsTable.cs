using System;
using System.Collections.Generic;
using Entities;
using Helpers;
using UnityEngine;

public class ConnectionsTable
{
    private int _size;

    /// <summary>
    /// Table of connections
    /// --
    /// 0 u u R u
    /// x 0 u u u
    /// x x 0 u u
    /// x x x 0 u
    /// x x x x 0
    /// --
    /// U - Used
    /// R - 
    /// 0 and X - Unused 
    /// </summary>
    private Connection[,] _connections;

    public ref Connection this[int i, int j]
    {
        get
        {
            if (i < j)
            {
                return ref _connections[i, j];
            }

            return ref _connections[j, i];
        }
    }

    public ConnectionsTable(IReadOnlyList<Vector3> points)
    {
        CreateTableDistances(points);
        //RemoveCrossConnections(points);
    }

    private void CreateTableDistances(IReadOnlyList<Vector3> points)
    {
        _size = points.Count;
        _connections = new Connection[_size, _size];

        for (var i = 0; i < _size; i++)
        {
            for (var j = i + 1; j < _size; j++)
            {
                //_connections[i, j].Enable = true;
                _connections[i, j].Distance = Vector3.Distance(points[i], points[j]);
            }
        }
    }

    /*
    private void RemoveCrossConnections(IReadOnlyList<Vector3> points)
    {
        for (var ai = 0; ai < _size; ai++)
        {
            for (var aj = ai + 1; aj < _size; aj++)
            {
                // Line A
                var a1 = new Vector2(points[ai].x, points[ai].z);
                var a2 = new Vector2(points[aj].x, points[aj].z);

                for (var bi = 0; bi < _size; bi++)
                {
                    for (var bj = bi + 1; bj < _size; bj++)
                    {
                        if (ai == bi && aj == bj)
                        {
                            continue;
                        }

                        // Line B
                        var b1 = new Vector2(points[bi].x, points[bi].z);
                        var b2 = new Vector2(points[bj].x, points[bj].z);

                        var result = MathHelper.IntersectionPointOfTwoLineSegments(a1, a2, b1, b2);

                        if (float.IsInfinity(result.x) &&
                            float.IsInfinity(result.y))
                        {
                            continue;
                        }

                        var distA = _connections[ai, aj].Distance;
                        var distB = _connections[bi, bj].Distance;
                        if (distA > distB)
                        {
                            _connections[ai, aj].Enable = false;
                        }
                        else if(Math.Abs(distA - distB) < 0.0001f)
                        {
                            _connections[ai, aj].Enable = false;
                            _connections[bi, bj].Enable = false;
                        }
                        else
                        {
                            //_connections[ib, jb].Enable = false;
                        }
                    }
                }
            }
        }
    }
    */
}
