using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace KataCajeroAutomatico_Tests
{
    [TestFixture]
    public class TestFixture1
    {
        private Cajero cajero = null;

        [Test]
        public void Test_CrearCajeroSinDinero()
        {
            cajero = new Cajero();

            Assert.AreEqual(0, cajero.GetNumeroBilletes(200));
            Assert.AreEqual(0, cajero.GetNumeroBilletes(100));
            Assert.AreEqual(0, cajero.GetNumeroBilletes(50));
            Assert.AreEqual(0, cajero.GetNumeroBilletes(20));
            Assert.AreEqual(0, cajero.GetNumeroBilletes(10));
        }

        #region Agregar Billetes
        [Test]
        public void Test_AgregarBilletes_200()
        {
            cajero = new Cajero();

            int tipoBillete = 200;
            int cuantos = 15;

            cajero.AddBilletes(tipoBillete, cuantos);
            Assert.AreEqual(cuantos, cajero.GetNumeroBilletes(tipoBillete));
        }

        [Test]
        public void Test_AgregarBilletes_100()
        {
            cajero = new Cajero();

            int tipoBillete = 100;
            int cuantos = 45;

            cajero.AddBilletes(tipoBillete, cuantos);
            Assert.AreEqual(cuantos, cajero.GetNumeroBilletes(tipoBillete));
        }

        [Test]
        public void Test_AgregarBilletes_50()
        {
            cajero = new Cajero();

            int tipoBillete = 50;
            int cuantos = 35;

            cajero.AddBilletes(tipoBillete, cuantos);
            Assert.AreEqual(cuantos, cajero.GetNumeroBilletes(tipoBillete));
        }

        [Test]
        public void Test_AgregarBilletes_20()
        {
            cajero = new Cajero();

            int tipoBillete = 20;
            int cuantos = 150;

            cajero.AddBilletes(tipoBillete, cuantos);
            Assert.AreEqual(cuantos, cajero.GetNumeroBilletes(tipoBillete));
        }

        [Test]
        public void Test_AgregarBilletes_10()
        {
            cajero = new Cajero();

            int tipoBillete = 10;
            int cuantos = 250;

            cajero.AddBilletes(tipoBillete, cuantos);
            Assert.AreEqual(cuantos, cajero.GetNumeroBilletes(tipoBillete));
        }
        #endregion

        #region Agregar Billetes Erroneos
        [Test, ExpectedException("System.ArgumentException")]
        public void Test_AgregarBilletes_150()
        {
            cajero = new Cajero();

            int tipoBillete = 150;
            int cuantos = 10;

            cajero.AddBilletes(tipoBillete, cuantos);
            // Assert.AreEqual(cuantos, cajero.GetNumeroBilletes(tipoBillete));
        }
        #endregion

        #region Restar Billetes
        [Test]
        public void Test_RestarBilletes_200_5Iniciales_Menos2_Disponible()
        {
            cajero = new Cajero();
            int tipoBillete = 200;
            int cuantosIniciales = 5;
            int cuantosMenos = 2;

            cajero.AddBilletes(tipoBillete, cuantosIniciales);
            cajero.SubstractBilletes(tipoBillete, cuantosMenos);

            Assert.AreEqual(cuantosIniciales - cuantosMenos, cajero.GetNumeroBilletes(tipoBillete));
        }

        [Test]
        public void Test_RestarBilletes_200_5Iniciales_Menos6_NoDisponibles()
        {
            cajero = new Cajero();
            int tipoBillete = 200;
            int cuantosIniciales = 5;
            int cuantosMenos = 6;

            cajero.AddBilletes(tipoBillete, cuantosIniciales);

            Assert.IsFalse(cajero.SubstractBilletes(tipoBillete, cuantosMenos));
        }
        #endregion

        #region Devolver distintos tipos de Billetes
        [Test]
        public void Test_Cantidad_10_Devolver_1b10()
        {
            cajero = new Cajero(true);
            Dictionary<int ,int> devuelve = cajero.GiveMeTheMoney(10);

            Assert.AreEqual(1, devuelve[10]);
            Assert.AreEqual(0, devuelve[20]);
            Assert.AreEqual(0, devuelve[50]);
            Assert.AreEqual(0, devuelve[100]);
            Assert.AreEqual(0, devuelve[200]);
        }

        [Test]
        public void Test_Cantidad_20_Devolver_1b20()
        {
            cajero = new Cajero(true);
            Dictionary<int, int> devuelve = cajero.GiveMeTheMoney(20);

            Assert.AreEqual(0, devuelve[10]);
            Assert.AreEqual(1, devuelve[20]);
            Assert.AreEqual(0, devuelve[50]);
            Assert.AreEqual(0, devuelve[100]);
            Assert.AreEqual(0, devuelve[200]);
        }

        [Test]
        public void Test_Cantidad_30_Devolver_1b20_1b10()
        {
            cajero = new Cajero(true);
            Dictionary<int, int> devuelve = cajero.GiveMeTheMoney(30);

            Assert.AreEqual(1, devuelve[10]);
            Assert.AreEqual(1, devuelve[20]);
            Assert.AreEqual(0, devuelve[50]);
            Assert.AreEqual(0, devuelve[100]);
            Assert.AreEqual(0, devuelve[200]);
        }

        [Test]
        public void Test_Cantidad_40_Devolver_2b20()
        {
            cajero = new Cajero(true);
            Dictionary<int, int> devuelve = cajero.GiveMeTheMoney(40);

            Assert.AreEqual(0, devuelve[10]);
            Assert.AreEqual(2, devuelve[20]);
            Assert.AreEqual(0, devuelve[50]);
            Assert.AreEqual(0, devuelve[100]);
            Assert.AreEqual(0, devuelve[200]);
        }

        [Test]
        public void Test_Cantidad_50_Devolver_1b50()
        {
            cajero = new Cajero(true);
            Dictionary<int, int> devuelve = cajero.GiveMeTheMoney(50);

            Assert.AreEqual(0, devuelve[10]);
            Assert.AreEqual(0, devuelve[20]);
            Assert.AreEqual(1, devuelve[50]);
            Assert.AreEqual(0, devuelve[100]);
            Assert.AreEqual(0, devuelve[200]);
        }

        [Test]
        public void Test_Cantidad_60_Devolver_1b50_1b10()
        {
            cajero = new Cajero(true);
            Dictionary<int, int> devuelve = cajero.GiveMeTheMoney(60);

            Assert.AreEqual(1, devuelve[10]);
            Assert.AreEqual(0, devuelve[20]);
            Assert.AreEqual(1, devuelve[50]);
            Assert.AreEqual(0, devuelve[100]);
            Assert.AreEqual(0, devuelve[200]);
        }

        [Test]
        public void Test_Cantidad_70_Devolver_1b50_1b20()
        {
            cajero = new Cajero(true);
            Dictionary<int, int> devuelve = cajero.GiveMeTheMoney(70);

            Assert.AreEqual(0, devuelve[10]);
            Assert.AreEqual(1, devuelve[20]);
            Assert.AreEqual(1, devuelve[50]);
            Assert.AreEqual(0, devuelve[100]);
            Assert.AreEqual(0, devuelve[200]);
        }

        [Test]
        public void Test_Cantidad_80_Devolver_1b50_1b20_1b10()
        {
            cajero = new Cajero(true);
            Dictionary<int, int> devuelve = cajero.GiveMeTheMoney(80);

            Assert.AreEqual(1, devuelve[10]);
            Assert.AreEqual(1, devuelve[20]);
            Assert.AreEqual(1, devuelve[50]);
            Assert.AreEqual(0, devuelve[100]);
            Assert.AreEqual(0, devuelve[200]);
        }

        [Test]
        public void Test_Cantidad_90_Devolver_1b50_2b20()
        {
            cajero = new Cajero(true);
            Dictionary<int, int> devuelve = cajero.GiveMeTheMoney(90);

            Assert.AreEqual(0, devuelve[10]);
            Assert.AreEqual(2, devuelve[20]);
            Assert.AreEqual(1, devuelve[50]);
            Assert.AreEqual(0, devuelve[100]);
            Assert.AreEqual(0, devuelve[200]);
        }

        [Test]
        public void Test_Cantidad_100_Devolver_1b100()
        {
            cajero = new Cajero(true);
            Dictionary<int, int> devuelve = cajero.GiveMeTheMoney(100);

            Assert.AreEqual(0, devuelve[10]);
            Assert.AreEqual(0, devuelve[20]);
            Assert.AreEqual(0, devuelve[50]);
            Assert.AreEqual(1, devuelve[100]);
            Assert.AreEqual(0, devuelve[200]);
        }

        [Test]
        public void Test_Cantidad_250_Devolver_1b200_1b50()
        {
            cajero = new Cajero(true);
            Dictionary<int, int> devuelve = cajero.GiveMeTheMoney(250);

            Assert.AreEqual(0, devuelve[10]);
            Assert.AreEqual(0, devuelve[20]);
            Assert.AreEqual(1, devuelve[50]);
            Assert.AreEqual(0, devuelve[100]);
            Assert.AreEqual(1, devuelve[200]);
        }

        [Test]
        public void Test_Cantidad_470_Devolver_2b200_1b50_1b20()
        {
            cajero = new Cajero(true);
            Dictionary<int, int> devuelve = cajero.GiveMeTheMoney(470);

            Assert.AreEqual(0, devuelve[10]);
            Assert.AreEqual(1, devuelve[20]);
            Assert.AreEqual(1, devuelve[50]);
            Assert.AreEqual(0, devuelve[100]);
            Assert.AreEqual(2, devuelve[200]);
        }
 
        [Test]
        public void Test_Cantidad_50_SinBilletes50_2b20_1b10()
        {
            cajero = new Cajero(true);

            cajero.SubstractBilletes(50, cajero.GetNumeroBilletes(50));

            Dictionary<int, int> devuelve = cajero.GiveMeTheMoney(50);

            Assert.AreEqual(1, devuelve[10]);
            Assert.AreEqual(2, devuelve[20]);
            Assert.AreEqual(0, devuelve[50]);
            Assert.AreEqual(0, devuelve[100]);
            Assert.AreEqual(0, devuelve[200]);
        }

        [Test]
        public void Test_Cantidad_80_SinBilletes50_4b20()
        {
            cajero = new Cajero(true);

            cajero.SubstractBilletes(50, cajero.GetNumeroBilletes(50));

            Dictionary<int, int> devuelve = cajero.GiveMeTheMoney(80);

            Assert.AreEqual(0, devuelve[10]);
            Assert.AreEqual(4, devuelve[20]);
            Assert.AreEqual(0, devuelve[50]);
            Assert.AreEqual(0, devuelve[100]);
            Assert.AreEqual(0, devuelve[200]);
        }

        [Test]
        public void Test_Cantidad_1250_SinBilletes50_SinBilletes20_6b200_5b10()
        {
            cajero = new Cajero(true);

            cajero.SubstractBilletes(50, cajero.GetNumeroBilletes(50));
            cajero.SubstractBilletes(20, cajero.GetNumeroBilletes(20));

            Dictionary<int, int> devuelve = cajero.GiveMeTheMoney(1250);

            Assert.AreEqual(5, devuelve[10]);
            Assert.AreEqual(0, devuelve[20]);
            Assert.AreEqual(0, devuelve[50]);
            Assert.AreEqual(0, devuelve[100]);
            Assert.AreEqual(6, devuelve[200]);
        }

        [Test]
        public void Test_Cantidad_1250_SinBilletes200_12b100_1b50()
        {
            cajero = new Cajero(true);

            cajero.SubstractBilletes(200, cajero.GetNumeroBilletes(200));

            Dictionary<int, int> devuelve = cajero.GiveMeTheMoney(1250);

            Assert.AreEqual(0, devuelve[10]);
            Assert.AreEqual(0, devuelve[20]);
            Assert.AreEqual(1, devuelve[50]);
            Assert.AreEqual(12, devuelve[100]);
            Assert.AreEqual(0, devuelve[200]);
        }

        [Test]
        public void Test_Cantidad_1250_SinBilletes200_SinBilletes100_25b50()
        {
            cajero = new Cajero(true);

            cajero.SubstractBilletes(200, cajero.GetNumeroBilletes(200));
            cajero.SubstractBilletes(100, cajero.GetNumeroBilletes(100));

            Dictionary<int, int> devuelve = cajero.GiveMeTheMoney(1250);

            Assert.AreEqual(0, devuelve[10]);
            Assert.AreEqual(0, devuelve[20]);
            Assert.AreEqual(25, devuelve[50]);
            Assert.AreEqual(0, devuelve[100]);
            Assert.AreEqual(0, devuelve[200]);
        }

        [Test, ExpectedException("KataCajeroAutomatico_Tests.NoMoneyException")]
        public void Test_Cantidad_19000_CantidadNoDisponible()
        {
            cajero = new Cajero(true);

            Dictionary<int, int> devuelve = cajero.GiveMeTheMoney(19000);
        }
        #endregion
    }
}
