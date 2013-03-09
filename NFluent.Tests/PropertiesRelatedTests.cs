﻿namespace NFluent.Tests
{
    using System;
    using System.Collections.Generic;

    using NUnit.Framework;

    [TestFixture]
    public class PropertiesRelatedTests
    {
        #region Properties extension method with IEnumerable

        [Test]
        public void PropertiesWorksWithEnumerable()
        {
            var enumerable = new List<Person>
                                 {
                                     new Person { Name = "Thomas", Age = 38 },
                                     new Person { Name = "Achille", Age = 10, Nationality = Nationality.French },
                                     new Person { Name = "Anton", Age = 7, Nationality = Nationality.French },
                                     new Person { Name = "Arjun", Age = 7, Nationality = Nationality.Indian }
                                 };

            Check.That(enumerable.Properties("Name")).ContainsExactly("Thomas", "Achille", "Anton", "Arjun");
            Check.That(enumerable.Properties("Age")).ContainsExactly(38, 10, 7, 7);
            Check.That(enumerable.Properties("Nationality")).ContainsExactly(Nationality.Unknown, Nationality.French, Nationality.French, Nationality.Indian);

            // more fluent than the following classical NUnit way, isn't it? 
            // CollectionAssert.AreEquivalent(enumerable.Properties("Age"), new[] { 38, 10, 7, 7 });

            // it's maybe even more fluent than the java versions
            // FEST fluent assert v 2.x:
            // assertThat(extractProperty("name" , String.class).from(inn.getItems())).containsExactly("+5 Dexterity Vest", "Aged Brie", "Elixir of the Mongoose", "Sulfuras, Hand of Ragnaros", "Backstage passes to a TAFKAL80ETC concert", "Conjured Mana Cake");
            // FEST fluent assert v 1.x:
            // assertThat(inn.getItems()).onProperty("name").containsExactly("+5 Dexterity Vest", "Aged Brie", "Elixir of the Mongoose", "Sulfuras, Hand of Ragnaros", "Backstage passes to a TAFKAL80ETC concert", "Conjured Mana Cake");
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PropertiesThrowInvalidOperationExceptionIfPropertyDoesNotExist()
        {
            var enumerable = new List<Person>
                                 {
                                     new Person { Name = "MethodMan", Age = 38 },
                                     new Person { Name = "GZA", Nationality = Nationality.American }
                                 };

            // Forced to enumerate the result so that the Properties extension method is executed (IEnumerable's lazy evaluation)
            foreach (var propertyValue in enumerable.Properties("Portnaouaq"))
            {
            }
        }

        [Test]
        public void PropertiesWorksEvenWithPrivateProperty()
        {
            var enumerable = new List<Person>
                                 {
                                     new Person { Name = "Ali G" },
                                     new Person { Name = "Borat" }
                                 };

            Check.That(enumerable.Properties("PrivateHesitation")).ContainsExactly("Kamoulox !", "Kamoulox !");
        }

        #endregion

        #region Properties extension method with Array

        [Test]
        public void PropertiesWorksWithArray()
        {
            Person[] persons = new Person[]
                                 {
                                     new Person { Name = "Thomas", Age = 38 },
                                     new Person { Name = "Achille", Age = 10, Nationality = Nationality.French },
                                     new Person { Name = "Anton", Age = 7, Nationality = Nationality.French },
                                     new Person { Name = "Arjun", Age = 7, Nationality = Nationality.Indian }
                                 };

            Check.That(persons.Properties("Name")).ContainsExactly("Thomas", "Achille", "Anton", "Arjun");
            Check.That(persons.Properties("Age")).ContainsExactly(38, 10, 7, 7);
            Check.That(persons.Properties("Nationality")).ContainsExactly(Nationality.Unknown, Nationality.French, Nationality.French, Nationality.Indian);
        }

        #endregion
    }
}
