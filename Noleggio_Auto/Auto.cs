using System;

public class Veicolo
{
	//varibili private
	private string _targa;
	private string _marca;
	private string _modello;
	private string _nome_conducente;
	private int _km_percorsi;
	private int _litri_carburante_nel_serbatorio;
	private int _costo_assicurazione_kasko;
	private int _costo_noleggio;
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
            if (_marca == null)
                throw new Exception("marca è null");
            else
                return _marca;
    }
        set { _marca = value; }
    }
	public string Modello
	{
        get
        {
            if (_modello == null)
                throw new Exception("modello è null");
            else
                return _modello;
	}
        set { _modello = value; }
    }
	public string Conducente
	{
        get
        {
            if (_nome_conducente == null)
                throw new Exception("conducente è null");
            else
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
        set { _km_percorsi = value; }
    }
	public int Litri_Nel_Serbatoio
	{
        get
        {
            if (_litri_carburante_nel_serbatorio < 0)
                throw new Exception("litri nel serbatorio invalido");
            else
                return _litri_carburante_nel_serbatorio;
	}
        set { _litri_carburante_nel_serbatorio = value; }
    }
	public int Costo_Kasko
    {
        get
        {
            if (_costo_assicurazione_kasko <= 0)
                throw new Exception("assicurazione kasko non pagata");
            else
                return _costo_assicurazione_kasko;
        }
        set { _costo_assicurazione_kasko = value; }
    }
	public int Costo_Noleggio
    {
        get
        {
            if (_costo_noleggio <= 0)
                throw new Exception("noleggio non pagato");
            else
                return _costo_noleggio;
        }
        set { _costo_noleggio = value; }
    }
	public double Costo_Carburante_Mancante
    {
        get { return _costo_carburante_mancante; }
        set
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
    public Veicolo(string marca, string modello, string conducente, int km_Percorsi, int litri_Nel_Serbatoio, int costo_Kasko, int costo_Noleggio)
    {
		Targa = GeneraTarga();
		Marca = marca;
		Modello = modello;
        Conducente = conducente;
        Km_Percorsi = km_Percorsi;
        Litri_Nel_Serbatoio = litri_Nel_Serbatoio;
        Costo_Kasko = costo_Kasko;
        Costo_Noleggio = costo_Noleggio;
        Costo_Carburante_Mancante = DefCostoCarb;
        Kasko = CheckKasko();
    }
    public Veicolo() : this(null, null, null, Vna, Vna, Vna, Vna)
	{		
	}
    public Veicolo(string marca, string modello, int litri_Nel_Serbatoio, int costo_Kasko, int costo_noleggio) : this(marca, modello, null, Vna, litri_Nel_Serbatoio, costo_Kasko, costo_noleggio)
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
    private bool CheckKasko()
    {
        if (Costo_Kasko > 0)
            return true;
        else
            return false;
    }


    //funzioni pubbliche

    public override string ToString()
    {
        string str = Targa + Sep + Marca + Sep + Modello + Sep + Conducente;
        string others = Km_Percorsi.ToString() + Sep + Litri_Nel_Serbatoio.ToString() + Sep + Costo_Kasko.ToString() + Sep + Costo_Noleggio.ToString();
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
        Veicolo cloned = new Veicolo(this.Targa, this.Modello, this.Conducente, this.Km_Percorsi, this.Litri_Nel_Serbatoio, this.Costo_Kasko, this.Costo_Noleggio);
        return cloned;
    }
    public bool CheckNoleggio()
    {
        if (this.Conducente == null)
            return false;
        else return true;
    }

}
