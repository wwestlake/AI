namespace AITesting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var bb = new Blackboard();
            bb.Set<int>("Speed", 10);

            var child = bb.Create("Child");
            child.Process(
                (x) => {
                    x.Set<float>("Score", 100.0f);

                    var speed = x.Get<int>("Speed");
                    var score = x.Get<float>("Score");

                    Console.WriteLine($"{speed} {bb.GetType("Speed")} {score} {x.GetType("Score")} ");
                });

        }
    }
}