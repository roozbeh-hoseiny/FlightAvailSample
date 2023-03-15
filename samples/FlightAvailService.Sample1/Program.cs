do
{
    Console.WriteLine("Choose a Sample or 'q' to exit : ");
    Console.WriteLine("\t1 : Simple");
    Console.WriteLine("\t2 : using IServiceProvider and getting service as IEnumerable<IFlightSupplier>");
    Console.WriteLine("\t3 : using IServiceProvider and getting service as its concrete class");
    Console.WriteLine("\t4 : using IServiceProvider and a supplier repository");
    Console.WriteLine("\t5 : using IServiceProvider and a supplier repository using Scrutor");
    Console.WriteLine("\t6 : Decorated Supplier using Scrutor");

    Console.Write(":>");
    var select = Console.ReadLine();
    if ((select ?? "").Equals("q", StringComparison.InvariantCultureIgnoreCase)) return;
    
    await SampleRunner.Run(new string[] { select ?? "" });
    Console.WriteLine(new string('*', 35));
} while (true);