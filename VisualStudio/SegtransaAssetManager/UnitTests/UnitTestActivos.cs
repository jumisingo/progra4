using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Backend.DAL;
using Backend.Entities;

namespace UnitTests
{
    [TestClass]
    public class UnitTestActivos
    {
        [TestMethod]
        public void TestMethodAdd()
        {
            IActivosDAL activosDAL = new ActivosImplDAL();
            int count = activosDAL.GetActivos().Count;

            Activos activo = new Activos
            {

            };
        }
    }
}
