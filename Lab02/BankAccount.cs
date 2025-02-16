namespace Lab02
{
    public class BankAccount
    {
        public string Wlasciciel { get; private set; }
        private decimal _saldo;
        public decimal Saldo
        {
            get { return _saldo; }
        }


        public BankAccount(string wlasciciel, decimal saldo)
        {
            Wlasciciel = wlasciciel;
            this._saldo = saldo;
        }
        public void Wplata(decimal kwota)
        {
            if (kwota <= 0)
            {
                throw new ArgumentException("Kwota wpłaty musi być większa niż 0");
            }
            else
            {
                Console.WriteLine($"Saldo przed wpłatą: {_saldo}");
                _saldo += kwota;
                Console.WriteLine($"Saldo po wpłacie: {_saldo}");
            }
   
        }
        public void Wyplata(decimal kwota)
        {
            if(_saldo < kwota)
            {
                throw new ArgumentException("Kwota jest wyższa niż saldo");
            }
            else if (kwota <= 0)
            {
                throw new ArgumentException("Kwota wypłaty musi być większa niż 0");
            }
            else
            {
                Console.WriteLine($"Saldo przed wypłatą: {_saldo}");
                _saldo -= kwota;
                Console.WriteLine($"Saldo po wypłacie: {_saldo}");
            }
        }
    }
}
