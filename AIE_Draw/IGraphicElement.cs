
using System.Reflection;

namespace AIE_Draw
{
    public interface IGraphicElement
    {        
        void DrawOn(Graphics graphics);
    }

    public class GraphicElementFactory
    {
        private static IEnumerable<Type> GetAllTypesThatImplementInterface<T>()
        {
            return System.Reflection.Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(type => typeof(T).IsAssignableFrom(type) && !type.IsInterface);
        }

        private static bool SuperStupidEquals(string a, string b)//have no idea why i'm having to do this
        {
            if (a.Length != b.Length) return false;
            int bIndex = 0;
            foreach (var ac in a.ToArray())
            {                
                bool charBool = ((int)ac) == ((int)b.ToArray()[bIndex]);
                if (charBool == false)
                {
                    return false;
                }                
            }
            return true;
        }

        public static IGraphicElement InitializeFrom(string elementDefinition)
        {
            var nameAndParams = elementDefinition.Split(':');

            foreach (Type type in GetAllTypesThatImplementInterface<IGraphicElement>())
            {
                if (type.Name.IndexOf(nameAndParams[0]) != -1)
                {
                    var propertiesDef = nameAndParams[1].Split(",");
                    var instance = type.GetConstructor(new Type[0]).Invoke(null);

                    foreach (var prop in type.GetProperties())
                    {
                        foreach (var propDef in propertiesDef)
                        {
                            var nameAndValue = propDef.Split('=');
                            string a = prop.Name;
                            string b = nameAndValue[0];
                            if (a.Trim() == b.Trim())
                            {
                                if (prop.PropertyType == typeof(string))
                                {
                                    prop.SetValue(instance, nameAndValue[1]);
                                }
                                if (prop.PropertyType == typeof(int))
                                {
                                    prop.SetValue(instance, int.Parse(nameAndValue[1]));
                                }
                                if (prop.PropertyType == typeof(float))
                                {
                                    prop.SetValue(instance, float.Parse(nameAndValue[1]));
                                }
                            }
                        }
                    }
                    return (IGraphicElement)instance;
                }
            }
            return null;
        }
    }

    internal class DrawElementPropertyAttribute : Attribute
    {
    }
}