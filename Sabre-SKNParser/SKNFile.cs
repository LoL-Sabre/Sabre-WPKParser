using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Sabre_SKNParser
{
    class SKNFile
    {
        public BinaryReader br;
        public Header header;
        public BoundingBox boundingbox;
        public List<Material> Materials = new List<Material>();
        public List<UInt16> Indices = new List<UInt16>();
        public List<Vertex> Vertices = new List<Vertex>();
        public UInt32 IndCount;
        public UInt32 VertCount;
        public SKNFile(string fileLocation)
        {
            br = new BinaryReader(File.Open(fileLocation, FileMode.Open));
            header = new Header(br);
            for(int i = 0; i < header.NumOfMaterials; i++)
            {
                Materials.Add(new Material(br));
            }
            IndCount = br.ReadUInt32();
            VertCount = br.ReadUInt32();
            if(header.Version == 4)
            {
                boundingbox = new BoundingBox(br);
            }
            for(int i = 0; i < IndCount; i++)
            {
                Indices.Add(br.ReadUInt16());
            }
            for(int i = 0; i < VertCount; i++)
            {
                Vertices.Add(new Vertex(br));
            }
        }
        public class Header
        {
            public byte[] Magic;
            public UInt16 Version;
            public UInt16 NumOfObjects;
            public UInt32 NumOfMaterials;
            public Header(BinaryReader br)
            {
                Magic = br.ReadBytes(4);
                Version = br.ReadUInt16();
                NumOfObjects = br.ReadUInt16();
                NumOfMaterials = br.ReadUInt32();
            }
        }
        public class Material
        {
            public string Name;
            public UInt32 StartVertex;
            public UInt32 NumOfVertices;
            public UInt32 StartIndex;
            public UInt32 NumOfIndices;
            public Material(BinaryReader br)
            {
                Name = Encoding.ASCII.GetString(br.ReadBytes(68));
                NumOfVertices = br.ReadUInt32();
                StartVertex = br.ReadUInt32();
                NumOfIndices = br.ReadUInt32();
                StartIndex = br.ReadUInt32();
            }
        }
        public class BoundingBox
        {
            public UInt32 FiftyTwo;
            public UInt32 UInt;
            public float Unk1;
            public float Unk2;
            public float Unk3;
            public float Unk4;
            public float Unk5;
            public float Unk6;
            public float Unk7;
            public BoundingBox(BinaryReader br)
            {
                FiftyTwo = br.ReadUInt32();
                UInt = br.ReadUInt32();
                Unk1 = br.ReadSingle();
                Unk2 = br.ReadSingle();
                Unk3 = br.ReadSingle();
                Unk4 = br.ReadSingle();
                Unk5 = br.ReadSingle();
                Unk6 = br.ReadSingle();
                Unk7 = br.ReadSingle();
            }
        }
        public class Vertex
        {
            public float[] Position = new float[3];
			public UInt32 BoneIndex;
			public float[] Weights = new float[4];
			public float[] Normal = new float[3];
			public float[] UV = new float[2];
            public Vertex(BinaryReader br)
            {
                for(int i = 0; i < 3; i++)
                {
                    Position[i] = br.ReadSingle();
                }
                BoneIndex = br.ReadUInt32();
                for(int i = 0; i < 4; i++)
                {
                    Weights[i] = br.ReadSingle();
                }
                for(int i = 0; i < 3; i++)
                {
                    Normal[i] = br.ReadSingle();
                }
                for(int i = 0; i < 2; i++)
                {
                    UV[i] = br.ReadSingle();
                }
            }
        }
    }
}
