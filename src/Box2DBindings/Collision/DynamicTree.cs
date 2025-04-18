using System.Runtime.InteropServices;

namespace Box2D
{
    public unsafe struct DynamicTree
    {
        private TreeNode* nodes;

        private int root;
        private int nodeCount;
        private int nodeCapacity;
        private int freeList;
        private int proxyCount;
        private int* leafIndices;
        private AABB* leafBoxes;
        private Vec2 leafCenters;
        private int* binIndices;
        private int rebuildCapacity;

        /// <summary>
        /// Constructing the tree initializes the node pool.
        /// </summary>
        [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DynamicTree_Create")]
        public static extern DynamicTree Create();

        [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DynamicTree_Destroy")]
        private static extern void Destroy(in DynamicTree tree);

        /// <summary>
        /// Destroy the tree, freeing the node pool.
        /// </summary>
        public void Destroy()
        {
            Destroy(in this);
        }

        [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DynamicTree_CreateProxy")]
        private static extern int CreateProxy(in DynamicTree tree, AABB aabb, uint64_t categoryBits, uint64_t userData);

        /// <summary>
        /// Create a proxy. Provide an AABB and a userData value.
        /// </summary>
        public int CreateProxy(AABB aabb, uint64_t categoryBits, uint64_t userData)
        {
            return CreateProxy(in this, aabb, categoryBits, userData);
        }

        [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DynamicTree_DestroyProxy")]
        private static extern void DestroyProxy(in DynamicTree tree, int proxyId);

        /// <summary>
        /// Destroy a proxy. This asserts if the id is invalid.
        /// </summary>
        public void DestroyProxy(int proxyId)
        {
            DestroyProxy(in this, proxyId);
        }

        [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DynamicTree_MoveProxy")]
        private static extern void MoveProxy(in DynamicTree tree, int proxyId, AABB aabb);

        /// <summary>
        /// Move a proxy to a new AABB by removing and reinserting into the tree.
        /// </summary>
        public void MoveProxy(int proxyId, AABB aabb)
        {
            MoveProxy(in this, proxyId, aabb);
        }

        [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DynamicTree_EnlargeProxy")]
        private static extern void EnlargeProxy(in DynamicTree tree, int proxyId, AABB aabb);

        /// <summary>
        /// Enlarge a proxy and enlarge ancestors as necessary.
        /// </summary>
        public void EnlargeProxy(int proxyId, AABB aabb)
        {
            EnlargeProxy(in this, proxyId, aabb);
        }

        [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DynamicTree_SetCategoryBits")]
        private static extern void SetCategoryBits(in DynamicTree tree, int proxyId, uint64_t categoryBits);

        /// <summary>
        /// Modify the category bits on a proxy. This is an expensive operation.
        /// </summary>
        public void SetCategoryBits(int proxyId, uint64_t categoryBits)
        {
            SetCategoryBits(in this, proxyId, categoryBits);
        }

        [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DynamicTree_GetCategoryBits")]
        private static extern uint64_t GetCategoryBits(in DynamicTree tree, int proxyId);

        /// <summary>
        /// Get the category bits on a proxy.
        /// </summary>
        public uint64_t GetCategoryBits(int proxyId)
        {
            return GetCategoryBits(in this, proxyId);
        }

        [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DynamicTree_Query")]
        private static extern TreeStats Query(in DynamicTree tree, AABB aabb, uint64_t maskBits,
            TreeQueryCallbackFcn callback, void* context);

        /// <summary>
        /// Query an AABB for overlapping proxies. The callback class is called for each proxy that overlaps the supplied AABB.
        /// </summary>
        /// <returns>Performance data</returns>
        public TreeStats Query(AABB aabb, uint64_t maskBits, TreeQueryCallbackFcn callback, void* context)
        {
            return Query(in this, aabb, maskBits, callback, context);
        }
        
        [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DynamicTree_RayCast")]
        private static extern TreeStats RayCast(in DynamicTree tree, in RayCastInput input, uint64_t maskBits,
            TreeRayCastCallbackFcn callback, void* context);

        /// <summary>
        /// Ray cast against the proxies in the tree. This relies on the callback
        /// to perform a exact ray cast in the case were the proxy contains a shape.
        /// The callback also performs the any collision filtering. This has performance
        /// roughly equal to k * log(n), where k is the number of collisions and n is the
        /// number of proxies in the tree.
        /// </summary>
        /// <param name="input">The ray cast input data. The ray extends from p1 to p1 + maxFraction * (p2 - p1)</param>
        /// <param name="maskBits">Mask bit hint: `bool accept = (maskBits &amp; node-&gt;categoryBits) != 0;`</param>
        /// <param name="callback">A callback class that is called for each proxy that is hit by the ray</param>
        /// <param name="context">User context that is passed to the callback</param>
        /// <returns>Performance data</returns>
        public TreeStats RayCast(in RayCastInput input, uint64_t maskBits, TreeRayCastCallbackFcn callback, void* context)
        {
            return RayCast(in this, input, maskBits, callback, context);
        }
        
        [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DynamicTree_ShapeCast")]
        private static extern TreeStats ShapeCast(in DynamicTree tree, in ShapeCastInput input, uint64_t maskBits,
            TreeShapeCastCallbackFcn callback, void* context);

        /// <summary>
        /// Ray cast against the proxies in the tree. This relies on the callback
        /// to perform a exact ray cast in the case were the proxy contains a shape.
        /// The callback also performs the any collision filtering. This has performance
        /// roughly equal to k * log(n), where k is the number of collisions and n is the
        /// number of proxies in the tree.
        /// </summary>
        /// <param name="input">The ray cast input data. The ray extends from p1 to p1 + maxFraction * (p2 - p1).</param>
        /// <param name="maskBits">Filter bits: `bool accept = (maskBits &amp; node-&gt;categoryBits) != 0;`</param>
        /// <param name="callback">A callback class that is called for each proxy that is hit by the shape</param>
        /// <param name="context">User context that is passed to the callback</param>
        /// <returns>Performance data</returns>
        public TreeStats ShapeCast(in ShapeCastInput input, uint64_t maskBits, TreeShapeCastCallbackFcn callback, void* context)
        {
            return ShapeCast(in this, input, maskBits, callback, context);
        }
        
        [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DynamicTree_GetHeight")]
        private static extern int GetHeight(in DynamicTree tree);
        
        /// <summary>
        /// Get the height of the binary tree.
        /// </summary>
        public int Height => GetHeight(in this);
        
        [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DynamicTree_GetAreaRatio")]
        private static extern float GetAreaRatio(in DynamicTree tree);
        
        /// <summary>
        /// Get the ratio of the sum of the node areas to the root area.
        /// </summary>
        public float AreaRatio => GetAreaRatio(in this);
        
        [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DynamicTree_GetRootBounds")]
        private static extern AABB GetRootBounds(in DynamicTree tree);
        
        /// <summary>
        /// Get the bounding box that contains the entire tree
        /// </summary>
        public AABB RootBounds => GetRootBounds(in this);
        
        [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DynamicTree_GetProxyCount")]
        private static extern int GetProxyCount(in DynamicTree tree);
        
        /// <summary>
        /// Get the number of proxies created
        /// </summary>
        public int ProxyCount => GetProxyCount(in this);
        
        [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DynamicTree_Rebuild")]
        private static extern int Rebuild(in DynamicTree tree, bool fullBuild);
        
        /// <summary>
        /// Rebuild the tree while retaining subtrees that haven't changed. Returns the number of boxes sorted.
        /// </summary>
        /// <param name="fullBuild">If true, the tree is fully rebuilt. If false, only the boxes that have changed are rebuilt.</param>
        /// <returns>The number of boxes sorted.</returns>
        public int Rebuild(bool fullBuild)
        {
            return Rebuild(in this, fullBuild);
        }
        
        [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DynamicTree_GetByteCount")]
        private static extern int GetByteCount(in DynamicTree tree);
        
        /// <summary>
        /// Get the number of bytes used by this tree
        /// </summary>
        public int ByteCount => GetByteCount(in this);
        
        [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DynamicTree_GetUserData")]
        private static extern uint64_t GetUserData(in DynamicTree tree, int proxyId);
        
        /// <summary>
        /// Get proxy user data
        /// </summary>
        public uint64_t GetUserData(int proxyId)
        {
            return GetUserData(in this, proxyId);
        }
        
        [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DynamicTree_GetAABB")]
        private static extern AABB GetAABB(in DynamicTree tree, int proxyId);
        
        /// <summary>
        /// Get the AABB of a proxy
        /// </summary>
        public AABB GetAABB(int proxyId)
        {
            return GetAABB(in this, proxyId);
        }
        
        [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DynamicTree_Validate")]
        private static extern void Validate(in DynamicTree tree);
        
        /// <summary>
        /// Validate this tree. For testing.
        /// </summary>
        public void Validate()
        {
            Validate(in this);
        }
        
        [DllImport("box2d", CallingConvention = CallingConvention.Cdecl, EntryPoint = "b2DynamicTree_ValidateNoEnlarged")]
        private static extern void ValidateNoEnlarged(in DynamicTree tree);
        
        /// <summary>
        /// Validate this tree. For testing.
        /// </summary>
        public void ValidateNoEnlarged()
        {
            ValidateNoEnlarged(in this);
        }
    }
}
