using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Dodecahedroid
{
    public class DodecahedronModel
    {
        private readonly static float GOLDEN_RATIO = (float)((1 + Math.Sqrt(5)) / 2);  // = 1.618f;

        // explicit vertices from http://mathworld.wolfram.com/RegularDodecahedron.html
        // 2*Math.Cos(2*0*Math.PI/5) = 2*Math.Cos(0) = 2 = 1.236*GOLDEN_RATIO
        // 2*Math.Sin(2*0*Math.PI/5) = 2*Math.Sin(0) = 0

        // 2*Math.Cos(2*1*Math.PI/5) = 0.618f = 0.382*GOLDEN_RATIO = GOLDEN_RATIO-1
        // 2*Math.Sin(2*1*Math.PI/5) = 1.9021 = 1.1756f*GOLDEN_RATIO

        // 2*Math.Cos(2*2*Math.PI/5) = -GOLDEN_RATIO
        // 2*Math.Sin(2*2*Math.PI/5) = 1.1756f = 0.7266*GOLDEN_RATIO

        // 2*Math.Cos(2*3*Math.PI/5) = -GOLDEN_RATIO
        // 2*Math.Sin(2*3*Math.PI/5) = -1.1756f = -0.7266*GOLDEN_RATIO

        // 2*Math.Cos(2*4*Math.PI/5) = 0.618f = 0.382*GOLDEN_RATIO = GOLDEN_RATIO-1
        // 2*Math.Sin(2*4*Math.PI/5) = -1.9021 = -1.1756f*GOLDEN_RATIO

        // 2*GOLDEN_RATIO*Math.Cos(2*0*Math.PI/5) = 2*GOLDEN_RATIO 
        // 2*GOLDEN_RATIO*Math.Sin(2*0*Math.PI/5) = 0

        // 2*GOLDEN_RATIO*Math.Cos(2*1*Math.PI/5) = 0.618f*GOLDEN_RATIO = (GOLDEN_RATIO-1)*GOLDEN_RATIO = 1
        // 2*GOLDEN_RATIO*Math.Sin(2*1*Math.PI/5) = 1.9021*GOLDEN_RATIO = 1.1756f*GOLDEN_RATIO*GOLDEN_RATIO

        // 2*GOLDEN_RATIO*Math.Cos(2*2*Math.PI/5) = -GOLDEN_RATIO*GOLDEN_RATIO
        // 2*GOLDEN_RATIO*Math.Sin(2*2*Math.PI/5) = 1.1756f*GOLDEN_RATIO = 0.7266*GOLDEN_RATIO*GOLDEN_RATIO

        // 2*GOLDEN_RATIO*Math.Cos(2*3*Math.PI/5) = -GOLDEN_RATIO*GOLDEN_RATIO
        // 2*GOLDEN_RATIO*Math.Sin(2*3*Math.PI/5) = -1.1756f*GOLDEN_RATIO = -0.7266*GOLDEN_RATIO*GOLDEN_RATIO

        // 2*GOLDEN_RATIO*Math.Cos(2*4*Math.PI/5) = 0.618f*GOLDEN_RATIO = (GOLDEN_RATIO-1)*GOLDEN_RATIO = 1
        // 2*GOLDEN_RATIO*Math.Sin(2*4*Math.PI/5) = -1.9021*GOLDEN_RATIO = -1.1756f*GOLDEN_RATIO*GOLDEN_RATIO


        private static readonly float[] explicitDodecahedronVertices = {
            (float)(2*Math.Cos(2*0*Math.PI/5)), (float)(2*Math.Sin(2*0*Math.PI/5)), GOLDEN_RATIO+1, // 0
            (float)(2*Math.Cos(2*1*Math.PI/5)), (float)(2*Math.Sin(2*1*Math.PI/5)), GOLDEN_RATIO+1, // 1
            (float)(2*Math.Cos(2*2*Math.PI/5)), (float)(2*Math.Sin(2*2*Math.PI/5)), GOLDEN_RATIO+1, // 2
            (float)(2*Math.Cos(2*3*Math.PI/5)), (float)(2*Math.Sin(2*3*Math.PI/5)), GOLDEN_RATIO+1, // 3
            (float)(2*Math.Cos(2*4*Math.PI/5)), (float)(2*Math.Sin(2*4*Math.PI/5)), GOLDEN_RATIO+1, // 4

            (float)(2*GOLDEN_RATIO*Math.Cos(2*0*Math.PI/5)), (float)(2*GOLDEN_RATIO*Math.Sin(2*0*Math.PI/5)), GOLDEN_RATIO-1, // 5
            (float)(2*GOLDEN_RATIO*Math.Cos(2*1*Math.PI/5)), (float)(2*GOLDEN_RATIO*Math.Sin(2*1*Math.PI/5)), GOLDEN_RATIO-1, // 6
            (float)(2*GOLDEN_RATIO*Math.Cos(2*2*Math.PI/5)), (float)(2*GOLDEN_RATIO*Math.Sin(2*2*Math.PI/5)), GOLDEN_RATIO-1, // 7
            (float)(2*GOLDEN_RATIO*Math.Cos(2*3*Math.PI/5)), (float)(2*GOLDEN_RATIO*Math.Sin(2*3*Math.PI/5)), GOLDEN_RATIO-1, // 8
            (float)(2*GOLDEN_RATIO*Math.Cos(2*4*Math.PI/5)), (float)(2*GOLDEN_RATIO*Math.Sin(2*4*Math.PI/5)), GOLDEN_RATIO-1, // 9

            (float)(-2*GOLDEN_RATIO*Math.Cos(2*0*Math.PI/5)), (float)(-2*GOLDEN_RATIO*Math.Sin(2*0*Math.PI/5)), -(GOLDEN_RATIO-1), // 10
            (float)(-2*GOLDEN_RATIO*Math.Cos(2*1*Math.PI/5)), (float)(-2*GOLDEN_RATIO*Math.Sin(2*1*Math.PI/5)), -(GOLDEN_RATIO-1), // 11
            (float)(-2*GOLDEN_RATIO*Math.Cos(2*2*Math.PI/5)), (float)(-2*GOLDEN_RATIO*Math.Sin(2*2*Math.PI/5)), -(GOLDEN_RATIO-1), // 12
            (float)(-2*GOLDEN_RATIO*Math.Cos(2*3*Math.PI/5)), (float)(-2*GOLDEN_RATIO*Math.Sin(2*3*Math.PI/5)), -(GOLDEN_RATIO-1), // 13
            (float)(-2*GOLDEN_RATIO*Math.Cos(2*4*Math.PI/5)), (float)(-2*GOLDEN_RATIO*Math.Sin(2*4*Math.PI/5)), -(GOLDEN_RATIO-1), // 14

            (float)(-2*Math.Cos(2*0*Math.PI/5)), (float)(-2*Math.Sin(2*0*Math.PI/5)), -(GOLDEN_RATIO+1), // 15
            (float)(-2*Math.Cos(2*1*Math.PI/5)), (float)(-2*Math.Sin(2*1*Math.PI/5)), -(GOLDEN_RATIO+1), // 16
            (float)(-2*Math.Cos(2*2*Math.PI/5)), (float)(-2*Math.Sin(2*2*Math.PI/5)), -(GOLDEN_RATIO+1), // 17
            (float)(-2*Math.Cos(2*3*Math.PI/5)), (float)(-2*Math.Sin(2*3*Math.PI/5)), -(GOLDEN_RATIO+1), // 18
            (float)(-2*Math.Cos(2*4*Math.PI/5)), (float)(-2*Math.Sin(2*4*Math.PI/5)), -(GOLDEN_RATIO+1), // 19
        };

        // for pentagon a b c d e
        // triangles are
        // a b d
        // a d e
        // b c d

        // order of specifying triangle vertices affects direction of default normal

        // each group of 3 defines a triangle
        // each group of 3 triangles defines a pentagon
        // there are 12 pentagons altogether defining a dodecahedron
        private static readonly ushort[] dodecahedronFaceIndexes = {
            // one of pair of opposite pentagons parallel to xy plane
            // 0, 1, 2, 3, 4
            1, 3, 0,
            1, 2, 3,
            0, 3, 4,

            // 0, 4, 5, 9, 12
            4, 12, 0,
            12, 5, 0,
            12, 4, 9,

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

            // the other one of pair of opposite pentagons parallel to xy plane?
            // 15, 16, 17, 18, 19
            15, 18, 16,
            15, 19, 18,
            16, 18, 17,

            // 15, 19, 10, 14, 7
            15, 7, 19,
            15, 10, 7,
            19, 7, 14,

            // 18, 19, 13, 14, 6
            19, 6, 18,
            6, 13, 18,
            6, 19, 14, 

            // 17, 18, 12, 13, 5
            18, 5, 17,
            5, 12, 17,
            5, 18, 13, 

            // 16, 17, 11, 12, 9
            17, 9, 16,
            9, 11, 16,
            9, 17, 12, 

            // 15, 16, 10, 11, 8
            16, 8, 15,
            8, 10, 15,
            8, 16, 11
        };
        

        // we pick a scale factor so that in the corresponding 2 dimensional sierpinski pentagon,
        // the scaled pentagons are just touching each other. This scale factor also gives a pleasing
        // appearance for the sierpinski dodecahedron.
        private static float scaleFactor = 1/(1+GOLDEN_RATIO); // = 0.382

        private static float[][] contractionMappings = BuildContractionMappings(explicitDodecahedronVertices);

        private static float[][] BuildContractionMappings(float[] vertices)
        {
            float[][] cm = new float[20][];

            for (int i = 0; i < cm.Length; i++)
            {
                float x = vertices[i * 3];
                float y = vertices[1 + i * 3];
                float z = vertices[2 + i * 3];

                cm[i] = new float[] {
                    scaleFactor,
                    0.0f,
                    0.0f,
                    0.0f,
                    scaleFactor,
                    0.0f,
                    0.0f,
                    0.0f,
                    scaleFactor,
                    x - scaleFactor*x,
                    y - scaleFactor*y,
                    z - scaleFactor*z };
            }

            return cm;
        }

        public static void ComputeVertices()
        {
            List<float> vertexList = new List<float>();
            
            int pentagonSegment = 0;

            for (int i = 0; i < dodecahedronFaceIndexes.Length; i += 3)
            {

                int i1 = dodecahedronFaceIndexes[i] * 3;
                int i2 = dodecahedronFaceIndexes[i + 1] * 3;
                int i3 = dodecahedronFaceIndexes[i + 2] * 3;

                // get the vertices for this triangular pentagon segement
                float ax = explicitDodecahedronVertices[i1];
                float ay = explicitDodecahedronVertices[i1 + 1];
                float az = explicitDodecahedronVertices[i1 + 2];

                float bx = explicitDodecahedronVertices[i2];
                float by = explicitDodecahedronVertices[i2 + 1];
                float bz = explicitDodecahedronVertices[i2 + 2];

                float cx = explicitDodecahedronVertices[i3];
                float cy = explicitDodecahedronVertices[i3 + 1];
                float cz = explicitDodecahedronVertices[i3 + 2];

                // calc normals
                float ux = ax - bx;
                float uy = ay - by;
                float uz = az - bz;

                float vx = cx - bx;
                float vy = cy - by;
                float vz = cz - bz;

                float nx = (uy * vz) - (uz * vy);
                float ny = (uz * vx) - (ux * vz);
                float nz = (ux * vy) - (uy * vx);

                // get the texture coordinates
                // todo: lookup table
                float texa_x, texa_y, texb_x, texb_y, texc_x, texc_y;
                switch (pentagonSegment)
                {
                    case 0:
                        texa_x = 1 - 0.7847f;
                        texa_y = 1 - 0.0639f;
                        texb_x = 1 - 0.5f;
                        texb_y = 1 - 0.9375f;
                        texc_x = 1 - 0.2167f;
                        texc_y = 1 - 0.0639f;
                        pentagonSegment = 1;
                        break;

                    case 1:
                        texa_x = 1 - 0.7847f;
                        texa_y = 1 - 0.0639f;
                        texb_x = 1 - 0.9597f;
                        texb_y = 1 - 0.6056f;
                        texc_x = 1 - 0.5f;
                        texc_y = 1 - 0.9375f;
                        pentagonSegment = 2;
                        break;

                    case 2:
                        texa_x = 1 - 0.2167f;
                        texa_y = 1 - 0.0639f;
                        texb_x = 1 - 0.5f;
                        texb_y = 1 - 0.9375f;
                        texc_x = 1 - 0.0417f;
                        texc_y = 1 - 0.6056f;
                        pentagonSegment = 0;
                        break;

                    default:
                        texa_x = 1 - 0.7847f;
                        texa_y = 1 - 0.0639f;
                        texb_x = 1 - 0.5f;
                        texb_y = 1 - 0.9375f;
                        texc_x = 1 - 0.2167f;
                        texc_y = 1 - 0.0639f;
                        pentagonSegment = 1;
                        break;
                }

                // append vertices, normals and texcoords to list
                vertexList.AddRange(new List<float> { ax, ay, az, nx, ny, nz, texa_x, texa_y });
                vertexList.AddRange(new List<float> { bx, by, bz, nx, ny, nz, texb_x, texb_y });
                vertexList.AddRange(new List<float> { cx, cy, cz, nx, ny, nz, texc_x, texc_y });
            }

            vertices = vertexList.ToArray();
            vertices = ApplyContractionMappings(vertices, 3);


            faceIndexes = new uint[vertices.Length];
            for (uint i = 0; i < faceIndexes.Length; i++)
            {
                faceIndexes[i] = i;
            }
        }

        private static float[] ApplyContractionMappings(float[] vertices, int iterations)
        {
            List<float> vertexList = new List<float>();
            
            for (int m = 0; m < contractionMappings.GetLength(0); m++)
            {
                for (int n = 0; n < vertices.Length; n += 8)
                {
                    float x = vertices[n];
                    float y = vertices[n + 1];
                    float z = vertices[n + 2];

                    float a = contractionMappings[m][0];
                    float b = contractionMappings[m][1];
                    float c = contractionMappings[m][2];
                    float d = contractionMappings[m][3];
                    float e = contractionMappings[m][4];
                    float f = contractionMappings[m][5];
                    float g = contractionMappings[m][6];
                    float h = contractionMappings[m][7];
                    float i = contractionMappings[m][8];
                    float j = contractionMappings[m][9];
                    float k = contractionMappings[m][10];
                    float l = contractionMappings[m][11];

                    float xdash = a * x + b * y + c * z + j;
                    float ydash = d * x + e * y + f * z + k;
                    float zdash = g * x + h * y + i * z + l;

                    vertexList.AddRange(new List<float>() { xdash, ydash, zdash, vertices[n + 3], vertices[n + 4], vertices[n + 5], vertices[n + 6], vertices[n + 7] });
                }
            }
            var vertexArray = vertexList.ToArray();
            return iterations > 1 ? ApplyContractionMappings(vertexArray, iterations - 1) : vertexArray;
        }

        internal static float[] vertices;
        internal static uint[] faceIndexes;
    }
}