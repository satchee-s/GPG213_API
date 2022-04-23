using System;
using System.Collections.Generic;
using UnityEngine;

namespace API
{
    public class GenerateTerrain
    {
        public void CalculateIndices(out int[] indices, int xSquares, int zSqaures, out Vector3[] normals, Vector3[] coords)
        {
            int totalSquares = xSquares * zSqaures;
            indices = new int[totalSquares * 6];
            int totalVertices = (xSquares + 1) * (zSqaures + 1);
            normals = new Vector3[totalVertices];
            int xVertices = xSquares + 1;
            int index = 0;
            int rowCounter = 0;
            for (int i = 0; i < (totalSquares + zSqaures); i++)
            {
                if (rowCounter == xSquares)
                {
                    rowCounter = 0;
                    continue;
                }
                indices[index] = i;
                indices[index + 1] = i + 1;
                indices[index + 2] = i + xVertices + 1;
                CalculateNormals(indices[index], indices[index + 1], indices[index + 2], normals, coords);
                indices[index + 3] = i + xVertices + 1;
                indices[index + 4] = i + xVertices;
                indices[index + 5] = i;
                CalculateNormals(indices[index + 3], indices[index + 4], indices[index + 5], normals, coords);
                index += 6;
                rowCounter++;
            }
        }

        private void CalculateNormals(int vertice1, int vertice2, int vertice3, Vector3[] verticeNormals, Vector3[] verticeCoordinates)
        {
            Vector3 u1 = verticeCoordinates[vertice2] - verticeCoordinates[vertice1];
            Vector3 v1 = verticeCoordinates[vertice3] - verticeCoordinates[vertice1];
            Vector3 n = -Vector3.Cross(v1, u1).normalized;
            verticeNormals[vertice1] = n;
            verticeNormals[vertice2] = n;
            verticeNormals[vertice3] = n;
        }
    }
}
