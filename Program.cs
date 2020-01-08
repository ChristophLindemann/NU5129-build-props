using System;

namespace NU5129.Build.Props.Problem
{
    public static class Program
    {
        public static int Main(string[] args)
        {
            return (args ?? Array.Empty<string>()).Length;
        }
    }
}