using System;
using System.Collections.Generic;
using UnityEngine;

namespace API
{
    public class Coordinates
    {
        public void SetCoordinates(out Vector3[] coordinates, Texture2D heightMap, int xVertices, int zVertices, int heightMultiplier = 1)
        {
            coordinates = new Vector3[xVertices*zVertices];
            int index = 0;
            for (int z = 0; z < zVertices; z++)
            {
                for (int x = 0; x < xVertices; x++)
                {
                    float xRatio = (float)heightMap.width / (float)xVertices;
                    float zRatio = (float)heightMap.height / (float)zVertices;
                    coordinates[index] = new Vector3(x, heightMap.GetPixel((int)(x * xRatio),
                                                            (int)(z * zRatio)).r * heightMultiplier, -z);
                    index++;
                }
            }
        }
    }
}
