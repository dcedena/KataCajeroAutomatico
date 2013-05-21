using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KataCajeroAutomatico_Tests
{
    public class Cajero
    {
        List<int> _listaBilletesValidos = new List<int>() {200, 100, 50, 20, 10};
            
        /// <summary>
        /// Key = Tipo de billete, Value = Cantidad de billetes disponibles.
        /// </summary>
        Dictionary<int, int> _billetes = new Dictionary<int, int>(); 

        public Cajero()
        {
            _billetes = CreateCajeroVacio();
        }

        public Cajero(bool agregarBilletesPorDefecto) : this()
        {
            _billetes = GetCajeroBilletesPorDefecto();
        }

        private Dictionary<int, int> GetCajeroBilletesPorDefecto()
        {
            Dictionary<int, int> devolver = new Dictionary<int, int>();
            foreach (int key in _listaBilletesValidos)
                devolver.Add(key, 50);
            // Máximo cajero = 200*50 + 100*50 + 50*50 + 20*50 + 10*50 = 10.000 + 5.000 + 2.500 + 1000 + 500 = 19.000 euros
            return devolver;
        }

        private Dictionary<int, int> CreateCajeroVacio()
        {
            Dictionary<int, int> empty = new Dictionary<int, int>();
            foreach (int valor in _listaBilletesValidos)
                empty.Add(valor, 0);
            return empty;
        }

        public int GetNumeroBilletes(int tipoBillete)
        {
            if(!IsValidTipoBillete(tipoBillete))
                throw new ArgumentException("No existe ningún billete de valor " + tipoBillete + ".");

            return _billetes[tipoBillete];
        }

        private bool IsValidTipoBillete(int tipoBillete)
        {
            return _listaBilletesValidos.Contains(tipoBillete);
        }

        public void AddBilletes(int tipoBillete, int cuantos)
        {
            if(!IsValidTipoBillete(tipoBillete))
                throw new ArgumentException("No se admiten billetes de " + tipoBillete + ".");

            if (_billetes.ContainsKey(tipoBillete))
                _billetes[tipoBillete] += cuantos;
            else
                _billetes.Add(tipoBillete, cuantos);
        }

        public bool SubstractBilletes(int tipoBillete, int cuantos)
        {
            if(!IsValidTipoBillete(tipoBillete))
                throw new ArgumentException("No se pueden retirar billetes de " + tipoBillete + ".");

            bool hayBilletesDisponible = true;
            if ((_billetes.ContainsKey(tipoBillete)) && (_billetes[tipoBillete] >= cuantos))
                _billetes[tipoBillete] -= cuantos;
            else
                hayBilletesDisponible = false;

            return hayBilletesDisponible;
        }

        public Dictionary<int, int> GiveMeTheMoney(int euros)
        {
            if(!IsValidEuros(euros))
                throw new ArgumentException("La cantidad solicitada no es válida.");

            Dictionary<int, int> devolver = CreateCajeroVacio();

            int eurosAux = euros;
            foreach (int tipoBillete in _listaBilletesValidos)
            {
                if(eurosAux >= tipoBillete)
                {
                    int cuantos = eurosAux/tipoBillete;

                    if (_billetes[tipoBillete] >= cuantos)
                    {
                        eurosAux -= tipoBillete*cuantos;
                        devolver[tipoBillete] = cuantos;
                    }
                }
            }

            if(eurosAux > 0)
                throw new NoMoneyException("Cantidad no disponible en cajero.");

            return devolver;
        }

        private bool IsValidEuros(int euros)
        {
            return ((euros >= 10) && (euros%10 == 0));
        }
    }
}
