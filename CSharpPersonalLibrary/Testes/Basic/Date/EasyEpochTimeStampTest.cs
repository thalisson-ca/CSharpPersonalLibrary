using System;
using CSharpPersonalLibrary.Basic.Date;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testes.Basic.Date
{
    [TestClass]
    public class EasyEpochTimeStampTest
    {
        [TestMethod]
        public void GetEpochTimeZero()
        {

            DateTime pointZero = EasyEpochTimeStamp.GetEpochTimeZero();
            DateTime dateTime  = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            Assert.AreEqual(dateTime, pointZero);
            
        }

        [TestMethod]
        public void ConvertDateTimeToEpoch()
        {

            long value;
            long expected;

            value = EasyEpochTimeStamp.ConvertDateTimeToEpoch(DateTime.MinValue);
            expected = -62135589600;
            Assert.AreEqual(expected, value);

            value = EasyEpochTimeStamp.ConvertDateTimeToEpoch(DateTime.MaxValue);
            expected = 253402300799;
            Assert.AreEqual(expected, value);

            value = EasyEpochTimeStamp.ConvertDateTimeToEpoch(new DateTime(1970,1,1,0,0,0,DateTimeKind.Utc));
            expected = 0;
            Assert.AreEqual(expected, value);

        }

        [TestMethod]
        public void ConvertEpochToDateTime()
        {

            DateTime value = EasyEpochTimeStamp.ConvertEpochToDateTime(0);
            Assert.AreEqual(EasyEpochTimeStamp.GetEpochTimeZero(), value);

            value = EasyEpochTimeStamp.ConvertEpochToDateTime(253402300799);
            DateTime expected = DateTime.MaxValue.AddMilliseconds(-999).AddTicks(-9999);
            Assert.AreEqual(expected, value);

            value = EasyEpochTimeStamp.ConvertEpochToDateTime(-62135596800);
            expected = DateTime.MinValue;
            Assert.AreEqual(expected, value);

            Assert.ThrowsException<ArgumentOutOfRangeException>(()=> EasyEpochTimeStamp.ConvertEpochToDateTime(253402300800));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => EasyEpochTimeStamp.ConvertEpochToDateTime(-62135596801));

        }

    }
}
