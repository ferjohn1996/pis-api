namespace PlanningInfoSystemAPI
{
    public class APIResponseClass
    {
    }

    public class APIResponseClass<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }

        public APIResponseClass()
        {
            // Ensure Data is initialized with a non-null value
            Data = default(T);
        }
    }
}
