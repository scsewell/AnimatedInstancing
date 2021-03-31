﻿using UnityEngine;

namespace AnimationInstancing
{
    /// <summary>
    /// A class containing constant values.
    /// </summary>
    public class Constants
    {
        /// <summary>
        /// The maximum number of LODs an instance can use.
        /// </summary>
        public const int k_maxLodCount = 5;
        
        /// <summary>
        /// The number of elements processed in a scan bucket.
        /// </summary>
        internal const int k_scanBucketSize = 512;
        
        /// <summary>
        /// The number of elements processed by each thread.
        /// </summary>
        internal const int k_sortElementsPerThread = 4;
        
        /// <summary>
        /// The number of bits of the keys that are processed in a single sorting pass.
        /// </summary>
        internal const int k_sortBitsPerPass = 4;
        
        /// <summary>
        /// The number of sorting bins needed per thread.
        /// </summary>
        internal const int k_sortBinCount = (1 << k_sortBitsPerPass);
    }

    /// <summary>
    /// A class containing shader property IDs.
    /// </summary>
    static class Properties
    {
        public static class Culling
        {
            public static readonly int _ConstantBuffer = Shader.PropertyToID("CullingPropertyBuffer");

            public static readonly int _LodData = Shader.PropertyToID("_LodData");
            public static readonly int _AnimationData = Shader.PropertyToID("_AnimationData");
            public static readonly int _InstanceData = Shader.PropertyToID("_InstanceData");
            public static readonly int _DrawArgs = Shader.PropertyToID("_DrawArgs");
            public static readonly int _IsVisible = Shader.PropertyToID("_IsVisible");
        }
        
        public static class Scan
        {
            public static readonly int _ScanIn = Shader.PropertyToID("_ScanIn");
            public static readonly int _ScanOut = Shader.PropertyToID("_ScanOut");
            public static readonly int _ScanIntermediate = Shader.PropertyToID("_ScanIntermediate");
        }

        public static class Sort
        {
            public static readonly int _ConstantBuffer = Shader.PropertyToID("SortingPropertyBuffer");
            
            public static readonly int _ShiftBit = Shader.PropertyToID("_ShiftBit");
            public static readonly int _SrcBuffer = Shader.PropertyToID("_SrcBuffer");
            public static readonly int _DstBuffer = Shader.PropertyToID("_DstBuffer");
            public static readonly int _SumTable = Shader.PropertyToID("_SumTable");
            public static readonly int _ReduceTable = Shader.PropertyToID("_ReduceTable");
            public static readonly int _ScanSrc = Shader.PropertyToID("_ScanSrc");
            public static readonly int _ScanDst = Shader.PropertyToID("_ScanDst");
            public static readonly int _ScanScratch = Shader.PropertyToID("_ScanScratch");
        }

        public static class Compact
        {
            public static readonly int _ConstantBuffer = Shader.PropertyToID("CullingPropertyBuffer");

            public static readonly int _InstanceData = Shader.PropertyToID("_InstanceData");
            public static readonly int _IsVisible = Shader.PropertyToID("_IsVisible");
            public static readonly int _ScanInBucket = Shader.PropertyToID("_ScanInBucket");
            public static readonly int _ScanAcrossBuckets = Shader.PropertyToID("_ScanAcrossBuckets");
            public static readonly int _DrawCallCounts = Shader.PropertyToID("_DrawCallCounts");
            public static readonly int _InstanceProperties = Shader.PropertyToID("_InstanceProperties");
            public static readonly int _DrawArgs = Shader.PropertyToID("_DrawArgs");
        }

        public static class Main
        {
            public static readonly int _Animation = Shader.PropertyToID("_Animation");
            public static readonly int _DrawArgsOffset = Shader.PropertyToID("_DrawArgsOffset");
            public static readonly int _DrawArgs = Shader.PropertyToID("_DrawArgs");
            public static readonly int _AnimationData = Shader.PropertyToID("_AnimationData");
            public static readonly int _InstanceProperties = Shader.PropertyToID("_InstanceProperties");
        }
    }

    /// <summary>
    /// A class containing compute shader kernel names.
    /// </summary>
    static class Kernels
    {
        public static class Culling
        {
            public const string k_main = "CSMain";
        }
        
        public static class Scan
        {
            public const string k_inBucket = "ScanInBucket";
            public const string k_acrossBuckets = "ScanAcrossBuckets";
        }
        
        public static class Sort
        {
            public const string k_count = "Count";
            public const string k_countReduce = "CountReduce";
            public const string k_scan = "Scan";
            public const string k_scanAdd = "ScanAdd";
            public const string k_scatter = "Scatter";
        }

        public static class Compact
        {
            public const string k_main = "CSMain";
        }
    }
}

