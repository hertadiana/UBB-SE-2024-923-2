﻿using Backend.Models;
using Backend.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace UBB_Business_Ads.Tests.RepoTests
{
    using NUnit;
    using NUnit.Framework;
    using NUnit.Framework.Legacy;
    using Moq;

    [TestFixture]
    public class TODORepoTest
    {
        private TODORepository _TODOrepo;

        [SetUp]
        public void Setup()
        {
            _TODOrepo = new TODORepository();
        }
        [Test]
        public void Test_GetTODOS()
        {
            var result = _TODOrepo.getTODOS();
            var expectedCount = _TODOrepo.getTODOS().Count();
            
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(expectedCount));
        }
        [Test]
        public void Test_AddTODOS()
        {
            int initialTODOsCount=_TODOrepo.getTODOS().Count();
            var newTODO=new TODOClass("New task");
            _TODOrepo.addingTODO(newTODO);
            var todosList = _TODOrepo.getTODOS(); // Get updated todos list
            var updatedTodosCount = todosList.Count;

            Assert.That(updatedTodosCount, Is.EqualTo(initialTODOsCount+ 1));
            Assert.That(todosList.Contains(newTODO), Is.True);

        }

        public void Test_RemoveTODOS()
        {
            int initialTODOsCount = _TODOrepo.getTODOS().Count();
            var newTODO = new TODOClass("Remove this task");
            _TODOrepo.addingTODO(newTODO);
            _TODOrepo.removingTODO(newTODO);
            var todosList = _TODOrepo.getTODOS(); 
            var updatedTodosCount = todosList.Count;

            Assert.That(updatedTodosCount, Is.EqualTo(initialTODOsCount -1));
            Assert.That(todosList.Contains(newTODO), Is.False);

        }

    }
}