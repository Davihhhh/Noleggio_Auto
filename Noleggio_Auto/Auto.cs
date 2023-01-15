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
	
	

    //properties
    public string Targa
    {
		get { return _targa; }	
		private set { _targa = value; }
    }
	public string Marca
    {
		get { return _marca; }
		private set { _marca = value; }
    }
	public string Modello
	{
		get { return _modello; }
		private set { _modello = value; }
	}
	public string Conducente
	{
		get { return _nome_conducente; }
		private set { _nome_conducente = value; }
	}
	public int Km_Percorsi
    {
		get { return _km_percorsi; }
		private set { _km_percorsi = value; }
    }
	public int Litri_Nel_Serbatoio
	{
		get { return _litri_carburante_nel_serbatorio; }
		private set { _litri_carburante_nel_serbatorio = value; }
	}
	public int Costo_Kasko
    {
		get { return _costo_assicurazione_kasko; }
		private set { _costo_assicurazione_kasko = value; }
    }
	public int Costo_Noleggio
    {
		get { return _costo_noleggio; }
		private set { _costo_noleggio = value; }
    }
	public double Costo_Carburante_Mancante
    {
		get { return 2.00; }
		private set { _costo_carburante_mancante = value; }
    }
	public bool Kasko
    {
		get { return _presenza_kasko; }
		private set { _presenza_kasko = value; }
    }	
	


	//costruttori	
	public Veicolo(string marca, string modello, string conducente, int km_Percorsi, int litri_Nel_Serbatoio, int costo_Kasko, int costo_Noleggio, bool kasko)
    {
		Targa = GeneraTarga();
		Marca = marca;
		Modello = modello;
        Conducente = conducente;
        Km_Percorsi = km_Percorsi;
        Litri_Nel_Serbatoio = litri_Nel_Serbatoio;
        Costo_Kasko = costo_Kasko;
        Costo_Noleggio = costo_Noleggio;
		Kasko = kasko;
    }
	public Veicolo() : this(null, null, null, Vna, Vna, Vna, Vna, false)
	{		
	}
	public Veicolo(string marca, string modello, string nome_conducente) : this(marca, modello, nome_conducente, Vna, Vna, Vna, Vna, false)
    {
    }


	//funzioni
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

}
