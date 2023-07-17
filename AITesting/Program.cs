namespace AITesting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var bb = new Blackboard();
            bb.Set<int>("Speed", 10);

            var child = bb.Create("Child");
            if (child.IsSuccess)
            {
                Blackboard? cbb = child.Value;
                cbb.Set<float>("Score", 100.0f);

                var speed = cbb.Get<int>("Speed");
                var score = cbb.Get<float>("Score");

                Console.WriteLine($"{speed} {score}");
            }

        }
    }
}