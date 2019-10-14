using NUnit.Framework;
using PSPTreciaDalis.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MixinTests
{
    public class EnclosureTests
    {
        
        [Test]
        public void Entertain_Succeeds()
        {
            Enclosure enclosure = new Enclosure() { _quality = 3 };

            Assert.AreEqual(4, enclosure.Enclose(DateTime.Now.AddHours(-2), DateTime.Now));
            Assert.AreEqual(-2, enclosure._qualityCounter);
        }
    }
}
