namespace MONO.Distribution.Common
{
    public class CharacterStringHelper
    {
        public static string CombinationKeyAndValue(string key, string value)
        {
            return string.Format("{0}:{1}", key, value);
        }
        
        public static string CombinationKeyAndValue(string key, string value, string symbols)
        {
            return string.Format("{0}:{1}{2}", key, value, symbols);
        }
    }
}
