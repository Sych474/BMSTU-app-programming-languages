
namespace BaseConstructions
{
    public class NamespacesExample
    {
        public void Bar()
        {
            Nested.NestedClass.Foo();
        }
    }

    namespace Nested
    {
        public static class NestedClass
        {
            public static void Foo()
            {
                Console.WriteLine("Foo");
            }
        }
    }    
}

