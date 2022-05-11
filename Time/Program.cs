using Time;

//!!!VISUAL STUDIO 2022 , .NET 6.0!!!//

//Creating test object 1
TimeStruct testtime = new TimeStruct(01, 00, 00);
Console.WriteLine(testtime);
//Creating test object 2(from string)
TimeStruct testtime2 = new TimeStruct("02 00 00");
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
/******************************************************************/
//Creating test object 1
TimePeriod testTimePeriod1 = new TimePeriod(200);
Console.WriteLine(testTimePeriod1);
//Creating test object 2
TimePeriod testTimePeriod2 = new TimePeriod(100);
Console.WriteLine(testTimePeriod2);
//Creating test object 3
TimePeriod testTimePeriod3 = new TimePeriod(1200,5);
Console.WriteLine(testTimePeriod3);
//Testing Methods
Console.WriteLine(testTimePeriod1.Equals(testTimePeriod2));
Console.WriteLine(testTimePeriod1 + testTimePeriod2);
Console.WriteLine(testTimePeriod1 - testTimePeriod2);
/******************************************************************/