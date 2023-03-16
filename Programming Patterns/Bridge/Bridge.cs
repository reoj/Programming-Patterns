using Programming_Patterns.Bridge.Contracts;

namespace Programming_Patterns.Bridge
{
    public class VectorRenderer : IRenderer
    {
        public string WhatToRenderAs => "lines";
    }
    public class RasterRenderer : IRenderer
    {
        public string WhatToRenderAs => "pixels";
    }
}
