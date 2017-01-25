namespace OnePos.Framework.Validation
{
    public class ValidationError
    {
        public string Message { get; set; }
        public string Key { get; set; }
        public object AttemptedValue { get; set; }
    }
}
