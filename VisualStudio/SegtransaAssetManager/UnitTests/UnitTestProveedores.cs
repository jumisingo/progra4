using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Backend.DAL;
using Backend.Entities;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class UnitTestProveedores
    {
        [TestMethod]
        public void TestMethodAdd()
        {
            IProveedoresDAL proveedoresDAL = new ProveedoresImplDAL();
            int count = proveedoresDAL.GetProveedores().Count;

            Proveedores proveedor = new Proveedores
            {
                idProveedor = 100001,
                nombre = "test",
                telefono = "+506-2266-8996",
                correo = "test@proveedor.com",
                direccion = "San Jose, Costa Rica",
            };
            proveedoresDAL.Add(proveedor);
            Assert.AreEqual(count + 1, proveedoresDAL.GetProveedores().Count);
        }
    }
}
