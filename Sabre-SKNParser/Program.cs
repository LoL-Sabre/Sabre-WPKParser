using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Sabre_SKNParser
{
    class Program
    {
        static void Main(string[] args)
        {
            SKNFile skn = new SKNFile("Lux.skn");
            Console.WriteLine("> Version = " + skn.header.Version);
            Console.WriteLine("> Number of Objects = " + skn.header.NumOfObjects);
            Console.WriteLine("> Number of Materials = " + skn.header.NumOfMaterials);
            Console.WriteLine("------<METADATA>------");
            Console.WriteLine("> Indice count = " + skn.IndCount);
            Console.WriteLine("> Face Count { IndCount / 3 } = " + skn.IndCount / 3);
            Console.WriteLine("> Vertice count = " + skn.VertCount);
            Console.WriteLine("------BOUNDING BOX------");
            Console.WriteLine("> Fifty Two = " + skn.boundingbox.Unknown);
            Console.WriteLine("> UInt32 = " + skn.boundingbox.AdditionalsCount);
            Console.WriteLine("> UnkFloat1 = " + skn.boundingbox.MinX);
            Console.WriteLine("> UnkFloat2 = " + skn.boundingbox.MinY);
            Console.WriteLine("> UnkFloat3 = " + skn.boundingbox.MinZ);
            Console.WriteLine("> UnkFloat4 = " + skn.boundingbox.MaxX);
            Console.WriteLine("> UnkFloat5 = " + skn.boundingbox.MaxY);
            Console.WriteLine("> UnkFloat6 = " + skn.boundingbox.MaxZ);
            Console.WriteLine("> UnkFloat7 = " + skn.boundingbox.Radius);
            Console.WriteLine("------INDICES------");
            foreach(UInt16 u in skn.Indices)
            {
                Console.WriteLine("> " + u);
            }
            Console.WriteLine("------VERTS------");
            foreach(var v in skn.Vertices)
            {
                Console.WriteLine("> Position = " + v.Position[0] + ", " + v.Position[1] + ", " + v.Position[2]);
                Console.WriteLine("> Bone Index = " + v.BoneIndex);
                Console.WriteLine("> Weights = " + v.Weights[0] + ", " + v.Weights[1] + ", " + v.BoneHash + ", " + v.WeightValue);
                Console.WriteLine("> Normals = " + v.Normal[0] + ", " + v.Normal[1] + ", " + v.Normal[2]);
                Console.WriteLine("> UV = " + v.UV[0] + ", " + v.UV[1]);
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
