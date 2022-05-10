using Time;

//Creating test object 1
TimeStruct testtime = new TimeStruct(03, 30,00);
Console.WriteLine(testtime);
//Creating test object 2(from string)
TimeStruct testtime2 = new TimeStruct("20 00 00");
Console.WriteLine(testtime2);
//Creating test object 3
TimeStruct testtime3 = new TimeStruct(23, 30);
Console.WriteLine(testtime3);
//Creating test object 4(from string)
TimeStruct testtime4 = new TimeStruct("3 0 0");
Console.WriteLine(testtime4);
//Testing methods
Console.WriteLine(testtime.Equals(testtime2));
Console.WriteLine(testtime + testtime2);
Console.WriteLine(testtime3 - testtime4);
