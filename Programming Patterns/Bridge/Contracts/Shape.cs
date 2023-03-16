namespace Programming_Patterns.Bridge.Contracts
{
    public abstract class Shape
    {
        public string Name { get; set; }
        public IRenderer Renderer { get; set; }

        public override string ToString() => $"Drawing {Name} as {Renderer.WhatToRenderAs}";

        internal Shape(IRenderer renderer)
        {
            this.Renderer = renderer;
            this.Name = nameof(Shape);
        }
    }
}
