using Microsoft.VisualStudio.TestTools.UnitTesting;
using Time;


namespace Time_TimePeriod_Tests
{
    [TestClass]
    public class TimeTests
    {
        #region TimeStruct

        [TestMethod]
        [TestCategory("Constructors")]
        public void TimeStruct_ConstructorDiffParameter()
        {
            TimeStruct testTime1 = new TimeStruct(10);
            TimeStruct testTime2 = new TimeStruct(10, 0);
            TimeStruct testTime3 = new TimeStruct(10, 00, 00);
        
            Assert.AreEqual(testTime1, testTime2);
            Assert.AreEqual(testTime1, testTime2);
            Assert.AreEqual(testTime1, testTime3);

        }

        [TestMethod]
        public void TimeStruct_StringConstructor()
        {
            TimeStruct testTime1 = new TimeStruct("14 56 20");
            string testTime1AsString = "14H 56M 20S";
            string testTime1AsStringParse = testTime1.ToString();
            Assert.AreEqual(testTime1AsString, testTime1AsStringParse);
        }

        [TestMethod]
        [TestCategory("Methods, Operators")]

        public void TimeStruct_Equals()
        {
            TimeStruct testTime1 = new TimeStruct(20, 00, 00);
            TimeStruct testTime2 = new TimeStruct(20, 0);

            Assert.IsTrue(testTime1.Equals(testTime2));

        }

        [TestMethod]
        public void TimeStruct_Operator_Equals_IsNotEqual()
        {
            TimeStruct testTime1 = new TimeStruct(20, 00, 00);
            TimeStruct testTime2 = new TimeStruct(20, 0);

            Assert.IsTrue(testTime1 == testTime2);
            Assert.IsFalse(testTime1 != testTime2);
        }

        [TestMethod]
        public void TimeStruct_Operator_Smaller_Bigger_SmallerEqual_BiggerEqual()
        {
            TimeStruct testTime1 = new TimeStruct(19, 46, 12);
            TimeStruct testTime2 = new TimeStruct(14, 0);
            TimeStruct testTime3 = new TimeStruct(19, 0);
            TimeStruct testTime4 = new TimeStruct(20, 20, 20);
            TimeStruct testTime5 = new TimeStruct(19);


            Assert.IsTrue(testTime2 < testTime1);
            Assert.IsTrue(testTime1 > testTime2);
            Assert.IsTrue(testTime3 <= testTime4);
            Assert.IsTrue(testTime4 >= testTime3);
            Assert.IsTrue(testTime5 >= testTime3);
        }

        [TestMethod]
        public void TimeStruct_TimeToSeconds()
        {
            TimeStruct testTime1 = new TimeStruct(1);
            var result = TimeStruct.timeToSeconds(testTime1);

            Assert.AreEqual(3600, result);
        }

        [TestMethod]
        public void TimeStruct_OperatorPlus_OperatorMinus()
        {
            TimeStruct testTime1 = new TimeStruct(10);
            TimeStruct testTime2 = new TimeStruct(5, 0);
            TimeStruct testTime3 = new TimeStruct(15, 0);


            Assert.AreEqual(testTime3, testTime1 + testTime2);
            Assert.AreEqual(testTime2, testTime3 - testTime1);
        }

        #endregion

        #region TimePeriod

        [TestMethod]
        [TestCategory("Constructors")]
        public void TimePeriod_ConstructorDiffParameters()
        {
            TimePeriod testTimePeriod1 = new TimePeriod(100);
            TimePeriod testTimePeriod2 = new TimePeriod(5, 20);
            TimePeriod testTimePeriod3 = new TimePeriod(12, 45, 21);

            Assert.AreEqual("00H 01M 40S", testTimePeriod1.ToString());
            Assert.AreEqual("05H 20M 00S", testTimePeriod2.ToString());
            Assert.AreEqual("12H 45M 21S", testTimePeriod3.ToString());

        }

        [TestMethod]
        [TestCategory("Methods, Operators")]
        public void TimePeriod_OperatorPlus_OperatorMinus()
        {
            TimePeriod testTime1 = new TimePeriod(3600);
            TimePeriod testTime2 = new TimePeriod(2, 0);
            TimePeriod testTime3 = new TimePeriod(3, 0);


            Assert.AreEqual(testTime3, testTime1 + testTime2);
            Assert.AreEqual(testTime1, testTime3 - testTime2);
        }
        [TestMethod]
        public void TimePeriod_Equals()
        {
            TimePeriod testTimePeriod1 = new TimePeriod(100);
            TimePeriod testTimePeriod2 = new TimePeriod(0, 1, 40);

            Assert.IsTrue(testTimePeriod1.Equals(testTimePeriod2));

        }

        [TestMethod]
        public void TimePeriod_Operator_Equals_IsNotEqual()
        {
            TimePeriod testTimePeriod1 = new TimePeriod(100);
            TimePeriod testTimePeriod2 = new TimePeriod(0, 1, 40);

            Assert.IsTrue(testTimePeriod1 == testTimePeriod2);
            Assert.IsFalse(testTimePeriod1 != testTimePeriod2);
        }

        [TestMethod]
        public void TimePeriod_Operator_Smaller_Bigger_SmallerEqual_BiggerEqual()
        {
            TimePeriod testTimePeriod1 = new TimePeriod(1000);
            TimePeriod testTimePeriod2 = new TimePeriod(0, 1, 40);
            TimePeriod testTimePeriod3 = new TimePeriod(80);
            TimePeriod testTimePeriod4 = new TimePeriod(0, 1, 40);
            TimePeriod testTimePeriod5 = new TimePeriod(80);
           


            Assert.IsTrue(testTimePeriod2 < testTimePeriod1);
            Assert.IsTrue(testTimePeriod1 > testTimePeriod2);
            Assert.IsTrue(testTimePeriod3 <= testTimePeriod4);
            Assert.IsTrue(testTimePeriod4 >= testTimePeriod3);
            Assert.IsTrue(testTimePeriod5 >= testTimePeriod3);
        }

        #endregion

    }
}