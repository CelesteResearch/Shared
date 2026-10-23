cbuffer Presentation : register(b0)
{
    float4 SourceRectangle;
};
#if ARRAY_SOURCE
Texture2DArray<float4> Source : register(t0);
#else
Texture2D<float4> Source : register(t0);
#endif
SamplerState PointClamp : register(s0);
struct VertexOutput
{
    float4 Position : SV_Position;
    float2 UV : TEXCOORD0;
};
VertexOutput VertexMain(uint vertex : SV_VertexID)
{
    float2 uv = float2((vertex << 1) & 2, vertex & 2);
    VertexOutput output;
    output.Position = float4(uv.x * 2 - 1, 1 - uv.y * 2, 0, 1);
    output.UV = SourceRectangle.xy + uv * SourceRectangle.zw;
    return output;
}
float4 PixelMain(VertexOutput input) : SV_Target0
{
#if ARRAY_SOURCE
    return Source.SampleLevel(PointClamp, float3(input.UV, 0), 0);
#else
    return Source.SampleLevel(PointClamp, input.UV, 0);
#endif
}
