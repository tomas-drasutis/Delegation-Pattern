using NUnit.Framework;
using PSPTreciaDalis.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MixinTests
{
    public class AnimalTests
    {
        
        [Test]
        public void Entertain_Succeeds()
        {
            Animal animal = new Animal() { _quality = 3 };

            Assert.AreEqual(4, animal.Entertain(DateTime.Now.AddHours(-2), DateTime.Now));
            Assert.AreEqual(-2, animal._qualityCounter);
        }
    }
}
