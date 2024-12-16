namespace MapCalculator
{
    internal class Program
    {


        //  AFR MAP
        //  INPUTS:
        //      RPM
        //      LOAD
        //  OUTPUTS:
        //      AFR Ratio
        //  MAP FORMAT:
        //      TAB SEPERATED, NEWLINE EX: 14,4\t14,5\t...12,2\r\n14,3\t14,3\t...12,1

        readonly static Dictionary<string, IMapCalculator> MAP_TYPES = new Dictionary<string, IMapCalculator>();

        static void Main(string[] args)
        {
            MAP_TYPES.Add("afr", new AFRMap());

            if (MAP_TYPES.Count == 0)
            {
                Console.WriteLine("no types available!");
                return;
            }

            IMapCalculator? calculator = null;
            while (calculator is null)
            {
                calculator = MapSelection();

                Console.WriteLine("Map Path:");
                string filePath = Console.ReadLine();

                calculator.InputMap(File.ReadAllText(filePath));

                Console.WriteLine("Map Read Succesfully...");

                string userInput = "";
                while (userInput != "exit")
                {
                    Console.WriteLine("Input X Value");
                    userInput = Console.ReadLine();

                    double xValue = 0;
                    if (!double.TryParse(userInput, out xValue))
                    {
                        Console.WriteLine("Invalid Input.");
                        continue;
                    }

                    Console.WriteLine("Input Y Value");
                    userInput = Console.ReadLine();

                    double yValue = 0;
                    if (!double.TryParse(userInput, out yValue))
                    {
                        Console.WriteLine("Invalid Input.");
                        continue;
                    }

                    Console.WriteLine($"Value at {xValue} and {yValue} in map is: {calculator.GetValue(xValue, yValue)}");
                }
            }
        }

        public static IMapCalculator MapSelection()
        {
            Console.WriteLine("Please select input from the following;");

            foreach (var value in MAP_TYPES.Keys)
            {
                Console.Write(value);
                Console.Write(", ");

            }
            Console.WriteLine();

            string inputvalue = Console.ReadLine().Trim().ToLower();

            IMapCalculator? mapcalculator = null;
            if (MAP_TYPES.TryGetValue(inputvalue, out mapcalculator))
            {
                return mapcalculator;
            }
            else
            {
                Console.WriteLine("That type does not exist...");
            }

            return null;
        }
    }
}
