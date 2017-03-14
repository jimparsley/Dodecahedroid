using System;
using System.Collections;
using System.Collections.Generic;

namespace Dodecahedroid
{
	public class DodecahedronModel
	{

        static DodecahedronModel()
        {
            ComputeVertices();
        }

        private readonly static float GOLDEN_RATIO = 1.618f;

        //internal readonly static float[] vertices = {
        //	0, 1/GOLDEN_RATIO, GOLDEN_RATIO,
        //          0, -1/GOLDEN_RATIO, -GOLDEN_RATIO,
        //          0, 1/GOLDEN_RATIO, -GOLDEN_RATIO,
        //          0, -1/GOLDEN_RATIO, GOLDEN_RATIO,

        //          GOLDEN_RATIO, 0, 1/GOLDEN_RATIO,
        //          -GOLDEN_RATIO, 0, -1/GOLDEN_RATIO,
        //          GOLDEN_RATIO, 0, -1/GOLDEN_RATIO,
        //          -GOLDEN_RATIO, 0, 1/GOLDEN_RATIO,

        //          1/GOLDEN_RATIO, GOLDEN_RATIO, 0,
        //          -1/GOLDEN_RATIO, -GOLDEN_RATIO, 0,
        //          1/GOLDEN_RATIO, -GOLDEN_RATIO, 0,
        //          -1/GOLDEN_RATIO, GOLDEN_RATIO, 0,

        //          1, 1, 1,
        //          1, 1, -1,
        //          1, -1, 1,
        //          1, -1, -1,
        //          -1, 1, 1,
        //          -1, 1, -1,
        //          -1, -1, 1,
        //          -1, -1, -1,
        //      };
        private readonly static float[] dodecahedron_vertices = {
            1.236f, 0.0f, 1.618f, // 0
            0.382f, 1.1754f, 1.618f, // 1
            -1.0f, 0.7263f, 1.618f, // 2
            -1.0f, -0.7263f, 1.618f, // 3
            0.382f, -1.1754f, 1.618f, // 4

            2.0f, 0.0f, 0.3819f, // 5
            0.618f, 1.902f, 0.3819f, // 6
            -1.6179f, 1.1755f, 0.3819f, // 7
            -1.6179f, -1.1755f, 0.3819f, // 8
            0.618f, -1.902f, 0.3819f, // 9

            -2f, 0.0f, -0.3819f, // 10
            -0.618f, -1.9020f, -0.3819f, // 11
            1.6179f, -1.1755f, -0.3819f, // 12
            1.6179f, 1.1755f, -0.3819f, // 13
            -0.618f, 1.902f, -0.3819f, // 14

            -1.236f, 0.0f, -1.618f, // 15
            -0.382f, -1.1754f, -1.618f, // 16
            1.0f, -0.7263f, -1.618f, // 17
            1.0f, 0.7263f, -1.618f, // 18
            -0.382f, 1.1754f, -1.618f, // 19
        };

        // for pentagon a b c d e
        // triangles are
        // a b d
        // a d e
        // b c d

        // order of specifying vertices affects direction of default normal

		//private static readonly ushort[] dodecahedron_faceIndexes = {
  //          // one of pair of opposite pentagons parallel to xy plane
  //          // 0, 1, 2, 3, 4
  //          1, 0, 3,
  //          0, 4, 3,
  //          1, 3, 2,

  //          // 0, 4, 5, 9, 12
  //          0, 12, 4,
  //          0, 5, 12,
  //          4, 12, 9,

  //          // 3, 4, 8, 9, 11
  //          3, 4, 11,
  //          3, 11, 8,
  //          4, 9, 11,
            
  //          // 2, 3, 7, 8, 10
  //          2, 3, 10,
  //          2, 10, 7,
  //          3, 8, 10,
            
  //          // 1, 2, 6, 7, 14
  //          1, 2, 14,
  //          1, 14, 6,
  //          2, 7, 14,

  //          // 0, 1, 5, 6, 13
  //          0, 1, 13,
  //          0, 13, 5,
  //          1, 6, 13,


  //          // 15, 16, 17, 18, 19
  //          16, 18, 15,
  //          15, 18, 19,
  //          16, 17, 18,

  //          // 15, 19, 10, 14, 7
  //          15, 19, 7,
  //          15, 7, 10,
  //          19, 14, 7,

  //          // 18, 19, 13, 14, 6
  //          18, 6, 19,
  //          18, 13, 6,
  //          19, 6, 14,

  //          // 17, 18, 12, 13, 5
  //          17, 5, 18,
  //          17, 12, 5,
  //          18, 5, 13,

  //          // 16, 17, 11, 12, 9
  //          16, 9, 17,
  //          16, 11, 9,
  //          17, 9, 12,

  //          // 15, 16, 10, 11, 8
  //          15, 8, 16,
  //          15, 10, 8,
  //          16, 8, 11
  //      };

        private static readonly ushort[] dodecahedron_faceIndexes_flipped = {
            // one of pair of opposite pentagons parallel to xy plane
            // 0, 1, 2, 3, 4
            1, 3, 0,
            0, 3, 4,
            1, 2, 3,

            // 0, 4, 5, 9, 12
            0, 4, 12,
            0, 12, 5,
            4, 9, 12,

            // 3, 4, 8, 9, 11
            3, 11, 4,
            3, 8, 11,
            4, 11, 9,
            
            // 2, 3, 7, 8, 10
            2, 10, 3,
            2, 7, 10,
            3, 10, 8,
            
            // 1, 2, 6, 7, 14
            1, 14, 2,
            1, 6, 14,
            2, 14, 7,

            // 0, 1, 5, 6, 13
            0, 13, 1,
            0, 5, 13,
            1, 13, 6,


            // 15, 16, 17, 18, 19
            16, 15, 18,
            15, 19, 18,
            16, 18, 17,

            // 15, 19, 10, 14, 7
            15, 7, 19,
            15, 10, 7,
            19, 7, 14,

            // 18, 19, 13, 14, 6
            18, 19, 6,
            18, 6, 13,
            19, 14, 6,

            // 17, 18, 12, 13, 5
            17, 18, 5,
            17, 5, 12,
            18, 13, 5,

            // 16, 17, 11, 12, 9
            16, 17, 9,
            16, 9, 11,
            17, 12, 9,

            // 15, 16, 10, 11, 8
            15, 16, 8,
            15, 8, 10,
            16, 11, 8
        };

        private static float[,] contractionMappings = new float[20, 12]
        {
            {0.382f, 0.0f, 0.0f, 0.0f, 0.382f, 0.0f, 0.0f, 0.0f, 0.382f, 1.236f, 0.0f, 1.618f },
            {0.382f, 0.0f, 0.0f, 0.0f, 0.382f, 0.0f, 0.0f, 0.0f, 0.382f, 0.382f, 1.1754f, 1.618f },
            {0.382f, 0.0f, 0.0f, 0.0f, 0.382f, 0.0f, 0.0f, 0.0f, 0.382f, -1.0f, 0.7263f, 1.618f },
            {0.382f, 0.0f, 0.0f, 0.0f, 0.382f, 0.0f, 0.0f, 0.0f, 0.382f, -1.0f, -0.7263f, 1.618f},
            {0.382f, 0.0f, 0.0f, 0.0f, 0.382f, 0.0f, 0.0f, 0.0f, 0.382f, 0.382f, -1.1754f, 1.618f},

            {0.382f, 0.0f, 0.0f, 0.0f, 0.382f, 0.0f, 0.0f, 0.0f, 0.382f, -1.236f, 0.0f, -1.618f},
            {0.382f, 0.0f, 0.0f, 0.0f, 0.382f, 0.0f, 0.0f, 0.0f, 0.382f, -0.382f, -1.1754f, -1.618f},
            {0.382f, 0.0f, 0.0f, 0.0f, 0.382f, 0.0f, 0.0f, 0.0f, 0.382f, 1.0f, -0.7263f, -1.618f},
            {0.382f, 0.0f, 0.0f, 0.0f, 0.382f, 0.0f, 0.0f, 0.0f, 0.382f, 1.0f, 0.7263f, -1.618f},
            {0.382f, 0.0f, 0.0f, 0.0f, 0.382f, 0.0f, 0.0f, 0.0f, 0.382f, -0.382f, 1.1754f, -1.618f},

            {0.382f, 0.0f, 0.0f, 0.0f, 0.382f, 0.0f, 0.0f, 0.0f, 0.382f, 2.0f, 0.0f, 0.3819f},
            {0.382f, 0.0f, 0.0f, 0.0f, 0.382f, 0.0f, 0.0f, 0.0f, 0.382f, 0.618f, 1.902f, 0.3819f},
            {0.388f, 0.0f, 0.0f, 0.0f, 0.382f, 0.0f, 0.0f, 0.0f, 0.382f, -1.6179f, 1.1755f, 0.3819f},
            {0.382f, 0.0f, 0.0f, 0.0f, 0.382f, 0.0f, 0.0f, 0.0f, 0.382f, -1.6179f, -1.1755f, 0.3819f},
            {0.382f, 0.0f, 0.0f, 0.0f, 0.382f, 0.0f, 0.0f, 0.0f, 0.382f, 0.618f, -1.902f, 0.3819f},

            {0.382f, 0.0f, 0.0f, 0.0f, 0.382f, 0.0f, 0.0f, 0.0f, 0.382f, -2f, 0.0f, -0.3819f},
            {0.382f, 0.0f, 0.0f, 0.0f, 0.382f, 0.0f, 0.0f, 0.0f, 0.382f, -0.618f, -1.9020f, -0.3819f},
            {0.382f, 0.0f, 0.0f, 0.0f, 0.382f, 0.0f, 0.0f, 0.0f, 0.382f, 1.6179f, -1.1755f, -0.3819f},
            {0.382f, 0.0f, 0.0f, 0.0f, 0.382f, 0.0f, 0.0f, 0.0f, 0.382f, 1.6179f, 1.1755f, -0.3819f},
            {0.382f, 0.0f, 0.0f, 0.0f, 0.382f, 0.0f, 0.0f, 0.0f, 0.382f, -0.618f, 1.902f, -0.3819f }
        };

        private static void ComputeVertices()
        {
            List<float> vertexList = new List<float>();

            float factor = 1f / (1f - 0.382f);
            //float factor = 1.618f;
            //float factor = 1f;

            for (int i=0; i<dodecahedron_faceIndexes_flipped.Length; i+=3)
            {
                // calc normal
                int i1 = dodecahedron_faceIndexes_flipped[i] * 3;
                int i2 = dodecahedron_faceIndexes_flipped[i+1] * 3;
                int i3 = dodecahedron_faceIndexes_flipped[i+2] * 3;
                
                float ax = dodecahedron_vertices[i1] * factor;
                float ay = dodecahedron_vertices[i1+1] * factor;
                float az = dodecahedron_vertices[i1+2] * factor;

                float bx = dodecahedron_vertices[i2] * factor;
                float by = dodecahedron_vertices[i2+1] * factor;
                float bz = dodecahedron_vertices[i2+2] * factor;

                float cx = dodecahedron_vertices[i3] * factor;
                float cy = dodecahedron_vertices[i3+1] * factor;
                float cz = dodecahedron_vertices[i3+2] * factor;

                float ux = ax - bx;
                float uy = ay - by;
                float uz = az - bz;

                float vx = cx - bx;
                float vy = cy - by;
                float vz = cz - bz;

                float nx = (uy * vz) - (uz * vy);
                float ny = (uz * vx) - (ux * vz);
                float nz = (ux * vy) - (uy * vx);

                // append vertices, normals and texcoords to list
                vertexList.AddRange(new List<float> { ax, ay, az, nx, ny, nz, 0f, 0f });
                vertexList.AddRange(new List<float> { bx, by, bz, nx, ny, nz, 0f, 1f });
                vertexList.AddRange(new List<float> { cx, cy, cz, nx, ny, nz, 1f, 0f });
            }
            
            vertices = ApplyContractionMappings(vertexList.ToArray());
            vertices = ApplyContractionMappings(vertices);
            vertices = ApplyContractionMappings(vertices);
            //vertices = ApplyContractionMappings(vertices);


            faceIndexes = new uint[vertices.Length];
            for(uint i=0; i< faceIndexes.Length; i++)
            {
                faceIndexes[i] = i;
            }
        }

        private static float[] ApplyContractionMappings(float[] vertices)
        {
            List<float> vertexList = new List<float>();

            for (int m = 0; m < contractionMappings.GetLength(0); m++)
            {
                for (int n = 0; n < vertices.Length; n+=8)
                {
                    float x = vertices[n];
                    float y = vertices[n+1];
                    float z = vertices[n+2];
                    
                    float a = contractionMappings[m, 0];
                    float b = contractionMappings[m, 1];
                    float c = contractionMappings[m, 2];
                    float d = contractionMappings[m, 3];
                    float e = contractionMappings[m, 4];
                    float f = contractionMappings[m, 5];
                    float g = contractionMappings[m, 6];
                    float h = contractionMappings[m, 7];
                    float i = contractionMappings[m, 8];
                    float j = contractionMappings[m, 9];
                    float k = contractionMappings[m, 10];
                    float l = contractionMappings[m, 11];

                    float xdash = a * x + b * y + c * z + j;
                    float ydash = d * x + e * y + f * z + k;
                    float zdash = g * x + h * y + i * z + l;

                    vertexList.AddRange(new List<float>() { xdash, ydash, zdash, vertices[n+3], vertices[n + 4], vertices[n + 5], vertices[n + 6], vertices[n + 7] });
                }
            }
            return vertexList.ToArray();
        }

        internal static float[] vertices;
        internal static uint[] faceIndexes;
	}

    
}
