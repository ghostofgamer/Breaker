Shader "Custom/BackObjects"
{
   Subshader
   {
       Pass
       {
           Stencil{
               Ref 1
               Comp Equal
               }
           }
      }
}
