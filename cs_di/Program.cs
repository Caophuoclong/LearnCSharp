using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace cs_di
{
    // Inverted dependency
    public interface IClassB
    {
        public void ActionB();
    }
    public interface IClassC
    {
        public void ActionC();
    }
    public class ClassA
    {
        IClassB b_dependency;
        public ClassA(IClassB b)
        {
            b_dependency = b;
        }
        public void ActionA()
        {
            System.Console.WriteLine("Action A!");
            b_dependency.ActionB();
        }
    }
    public class ClassB : IClassB
    {
        IClassC c_dependency;
        public ClassB(IClassC _c_dependency, string msg)
        {
            c_dependency = _c_dependency;
            System.Console.WriteLine(msg);
        }
        public void ActionB()
        {
            System.Console.WriteLine("Action B!");
            c_dependency.ActionC();
        }
    }
    public class ClassC : IClassC
    {
        public ClassC()
        {
            System.Console.WriteLine("Class C is created!");
        }
        public void ActionC()
        {
            System.Console.WriteLine("Action C!");
        }
    }
    public class ApplicationConfig
    {
        public string color { get; set; }
        public int fontSize { get; set; }

        public string bgColor { get; set; }
        public int lineHeight { get; set; }

    }
    public class MyService
    {
        public string color { get; set; }
        public int fontSize { get; set; }
        public int lineHeight { get; set; }
        public string bgColor { get; set; }
        public MyService(IOptions<ApplicationConfig> options)
        {
            ApplicationConfig config = options.Value;
            color = config.color;
            fontSize = config.fontSize;
            lineHeight = config.lineHeight;
            bgColor = config.bgColor;
        }
        public void PrintData()
        {
            Console.WriteLine(new
            {
                Mau = color,
                MauNen = bgColor,
                DoRong = lineHeight,
                CoChu = fontSize

            });
        }
    }
    public class Program
    {
        // TODO: Inject dependency to class
        public static void Main(string[] args)
        {
            ServiceCollection service = new ServiceCollection();
            // Use Implementation to register service
            service.AddSingleton<IClassC, ClassC>();
            // Use delegate to register services 
            service.AddSingleton<IClassB>((IServiceProvider provider) =>
            {
                return new ClassB(provider.GetService<IClassC>(), "Hello moi nguoi");
            });
            service.AddSingleton<ClassA>();
            service.AddSingleton<MyService>();
            // Use file json to add config 
            IConfigurationBuilder builder = new ConfigurationBuilder()
                                            .SetBasePath(Directory.GetCurrentDirectory())
                                            .AddJsonFile("config.json");
            IConfigurationRoot rootConfig = builder.Build();
            // Use option to init service in Dependency Injection
            // To sperate service and option, ServiceCollection support IOption interface to do this job
            // Class ApplicationConfig 
            service.Configure<ApplicationConfig>(rootConfig.GetSection("settings"));
            ServiceProvider provider = service.BuildServiceProvider();
            ClassA a = provider.GetService<ClassA>();
            MyService m = provider.GetService<MyService>();
            // a.ActionA();
            m.PrintData();
        }
    }
}