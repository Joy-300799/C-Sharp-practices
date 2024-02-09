// dotnet new classlib -o MathLib
// # Note that the new project created has similar files (.csproj and .cs)
// # But the .csproj does not have an OutputType

namespace MathLibNamespace
{
    public class MathLibClass
    {
        public int Add(int x, int y)
        {
            return x + y;
        }
    }
}

//cd MathLib
//dotnet build