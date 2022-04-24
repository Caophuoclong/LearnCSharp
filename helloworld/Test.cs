using Microsoft.Extensions.Options;

namespace helloworld
{
    public class Test
    {
        public TestOptions Options { get; set; }
        public Test(IOptions<TestOptions> x)
        {

        }
    }
}