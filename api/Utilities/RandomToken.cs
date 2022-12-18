namespace api.Utilities
{
    public static class RandomToken
    {
        public static string TokenGenerator()
        {
            return Convert.ToBase64String(Guid.NewGuid().ToByteArray());
        }
    }
}