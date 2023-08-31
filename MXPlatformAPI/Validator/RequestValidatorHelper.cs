namespace MXPlatformAPI.Validator
{
    public class RequestValidatorHelper
    {
        public bool IsValidName(string name)
        {
            return name.All(Char.IsLetter);
        }
    }
}
