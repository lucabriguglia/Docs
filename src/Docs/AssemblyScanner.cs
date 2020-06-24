using System.Reflection;

namespace Docs
{
    public class AssemblyScanner : IAssemblyScanner
    {
        public void Scan()
        {
            var assembly = Assembly.GetExecutingAssembly();

            foreach (var type in assembly.GetTypes())
            {
                var targetAttribute = type.GetCustomAttribute(typeof(DocTargetAttribute));

                if (targetAttribute != null)
                {

                }

                var requestAttribute = type.GetCustomAttribute(typeof(DocRequestAttribute));

                if (requestAttribute != null)
                {
                    var request = (DocRequestAttribute)requestAttribute;
                    var target = request.Target;
                }
            }
        }
    }
}