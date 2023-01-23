using System.Reflection;

namespace EasyHiring.Repository.Maps;

public class MongoDomainMapsRegistrar
{
    public static void RegisterDocumentMaps(Assembly assembly)
    {
        var classMaps = assembly.GetTypes()
            .Where(t => t.BaseType != null && t.BaseType.IsGenericType &&
                        t.BaseType.GetGenericTypeDefinition() == typeof(MongoDbClassMap<>)).ToArray();

        foreach (var classMap in classMaps)
        {
            Activator.CreateInstance(classMap, true);
        }
    }
}