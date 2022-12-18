namespace api.Utilities
{
    public static class RandomToken
    {
        public static string TokenGenerator()
        {
            return Guid.NewGuid().ToString();
        }
    }
}