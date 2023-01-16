using System;

public class Veicolo
{
	//varibili private
	private string _targa;
	private string _marca;
	private string _modello;
	private string _nome_conducente;
	private int _km_percorsi;
    private int _litri_carburante_attuali_nel_serbatoio;
	private int _litri_carburante_iniziali_nel_serbatoio;
	private double _costo_assicurazione_kasko;
	private double _costo_noleggio;
	private double _costo_carburante_mancante;
	private bool _presenza_kasko;
	

	//variabili della classe
	private static readonly int Vna = -1; //valore_non_accettabile
	private Random rnd = new Random();
    private static double DefCostoCarb = 2.00;
    private static char Sep = ';';
	
	

    //properties
    public string Targa
    {
        get
        {
            if (_targa == null)
                throw new Exception("targa è null");
            else
                return _targa;
        }
	    private set { _targa = value; }
    }
	public string Marca
    {
        get
        {
            if (_marca == null && Conducente != null)
                throw new Exception("marca è null");
            else
                return _marca;
    }
        set 
        {
            if (value == null && Conducente != null)
            {
                throw new Exception("Marca non può essere null");
            }
            else if (GetStatoNoleggio())
                throw new Exception("Auto noleggiata, dati non modificabili");
            else                
                _marca = value;
        }
    }
	public string Modello
	{
        get
        {
            if (_modello == null && Conducente != null)
                throw new Exception("modello è null");
            else
                return _modello;
        }
        set 
        {
            if (value == null && Conducente != null)
            {
                throw new Exception("Modello non può essere null");
            }
            else if (GetStatoNoleggio())
                throw new Exception("Auto noleggiata, dati non modificabili");
            else
                _modello = value;
        }
    }
	public string Conducente
	{
        get
        {
                return _nome_conducente;
        }
        set { _nome_conducente = value; }
    }
	public int Km_Percorsi
    {
        get
        {
            if (_km_percorsi < 0)
                throw new Exception("km percorsi invalido");
            else
                return _km_percorsi;
    }
        protected set 
        {
            if (value < 0 && Conducente != null)
                throw new Exception("Km prcorsi invalidi");
            else 
               _km_percorsi = value; 
        }
    }
	public int Litri_Nel_Serbatoio_Iniziali 
	{
        get
        {
            if (_litri_carburante_iniziali_nel_serbatoio < 0)
                throw new Exception("litri nel serbatorio invalidi");
            else
                return _litri_carburante_iniziali_nel_serbatoio;
	}
        private set 
        {
            if (value < 0 && Conducente != null)
                throw new Exception("litri nel serbatoio invalidi");
            else
                _litri_carburante_iniziali_nel_serbatoio = value; 
        }
    }
    public int Litri_Nel_Serbatoio_Attuali
    {
        get
        {
            if (_litri_carburante_attuali_nel_serbatoio < 0)
                throw new Exception("litri nel serbatorio invalidi");
            else
                return _litri_carburante_attuali_nel_serbatoio;
        }
        protected set
        {
            if (value < 0)
                throw new Exception("litri nel serbatoio invalidi");
            else
                _litri_carburante_attuali_nel_serbatoio = value;
        }
    }

    public double Costo_Kasko
    {
        get
        {
            if (_costo_assicurazione_kasko <= 0)
                throw new Exception("assicurazione kasko non presente");
            else
                return _costo_assicurazione_kasko;
        }
        private set
        {
            if (value < 0 && Conducente!= null)
                throw new Exception("costo noleggio invalido");
            else
                _costo_assicurazione_kasko = value;
        }
    }
	public double Costo_Noleggio
    {
        get
        {
            if (_costo_noleggio <= 0)
                throw new Exception("noleggio non pagato");
            else
                return _costo_noleggio;
        }
        private set 
        {
            if (value < 0 && Conducente != null)
                throw new Exception("costo noleggio invalido");
            else
                _costo_noleggio = value; 
        }
    }
	public double Costo_Carburante_Mancante
    {
        get { return _costo_carburante_mancante; }
        private set
        {
            if (value < 0)
                throw new Exception("costo carburante invalido");
            else
                _costo_carburante_mancante = value;
        }
    }
	public bool Kasko
    {
		get { return _presenza_kasko; }
		private set { _presenza_kasko = value; }
    }	
	


	//costruttori	
    public Veicolo(string marca, string modello, string conducente, int km_Percorsi, int litri_Nel_Serbatoio, double costo_Kasko, double costo_Noleggio, bool aggiuntakasko)
    {
		Targa = GeneraTarga();
		Marca = marca;
		Modello = modello;
        Conducente = conducente;
        Km_Percorsi = km_Percorsi;
        Litri_Nel_Serbatoio_Iniziali = litri_Nel_Serbatoio;
        Costo_Kasko = costo_Kasko;
        Costo_Noleggio = costo_Noleggio;
        Costo_Carburante_Mancante = DefCostoCarb;
        Kasko = aggiuntakasko;
    }
    public Veicolo() : this(null, null, null, Vna, Vna, Vna, Vna, false)
    {
    }
    public Veicolo(string marca, string modello, int litri_Nel_Serbatoio, double costo_Kasko, double costo_noleggio) : this(marca, modello, null, Vna, litri_Nel_Serbatoio, costo_Kasko, costo_noleggio, false)
    {
    }


    //funzioni private
	private string GeneraTarga()
    {
		char[] targa = new char[7];
		int val = 0;
		for (int a = 0; a < 7; a++)
		{
			if (a >= 2 && a <= 4)
            {
				val = rnd.Next(48, 58);
				targa[a] = Convert.ToChar(val);
            }
            else
            {
				val = rnd.Next(65, 91);
				targa[a] = Convert.ToChar(val);
            }
        }	
		return targa.ToString();
    }    


    //funzioni pubbliche
    public override string ToString()
    {
        string str = Targa + Sep + Marca + Sep + Modello + Sep + Conducente;
        string others = Km_Percorsi.ToString() + Sep + Litri_Nel_Serbatoio_Iniziali.ToString() + Sep + Costo_Kasko.ToString() + Sep + Costo_Noleggio.ToString();
        return str + Sep + others;
    }
    public bool Equals(Veicolo v)
    {
        if (v == null)
            return false;
        else return (this == v);
    }
    public Veicolo Clone()
    {
        Veicolo cloned = new Veicolo(this.Targa, this.Modello, this.Conducente, this.Km_Percorsi, this.Litri_Nel_Serbatoio_Iniziali, this.Costo_Kasko, this.Costo_Noleggio, this.Kasko);
        return cloned;
    }
    public bool GetStatoNoleggio()
    {
        if (this.Conducente == null)
            return false;
        else return true;
    }
    public void Noleggia(string conducente, bool kasko)
    {
        if (!GetStatoNoleggio())
        {
            this.Conducente = conducente;
            this.Kasko = kasko;
        }
        else
        {
            throw new Exception("Auto già noleggiata");
        }
    }
    public double Restituisci()
    {       
        if (!GetStatoNoleggio())
        {
            throw new Exception("Auto non noleggiata");
        }
        else
        {
            this.Conducente = null;
            this.Kasko = false;
            double costo = DefCostoCarb * (Litri_Nel_Serbatoio_Iniziali - Litri_Nel_Serbatoio_Attuali);
            this.Km_Percorsi = 0;
            if(Kasko)
            {
                costo += Costo_Kasko;
            }
            costo += Costo_Noleggio;
            return costo;
        }
    }
}
