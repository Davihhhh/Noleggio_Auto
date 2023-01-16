using bacheca_pausaidattica;
namespace Tester_Ferrari
{
    public class UnitTest1
    {
        Bacheca bc;
        Promemoria pr;

        [Fact]
        public void TestCreaBacheca()
        {
            bc = new Bacheca("bacheca", "questa è una bacheca", "akar");
            Assert.True(bc.getPromemoria(10) == null); //restituisce un valore anzichè eccezione da gestire
        }

        [Fact]
        public void TestAggiuntaPromemoria_prima()
        {
            bc = new Bacheca("bacheca", "questa è una bacheca", "akar");
            Assert.Throws<Exception>(() => bc.Aggiungi(pr));  //eccezione null non gestita
            pr = new Promemoria("promemoria", "datafalsa");
            bc.Aggiungi(pr);
        }

        [Fact]
        public void TestAggiuntaPromemoria_dopo()
        {
            bc = new Bacheca("bacheca", "questa è una bacheca", "akar");
            pr = new Promemoria("promemoria", "datafalsa");
            bc.Aggiungi(pr);
            Assert.True(bc.getPromemoria(1) == pr); 
        }

        [Fact]
        public void TestOttieniTuttiPromemoria()
        {
            Promemoria pr1 = new Promemoria("promemoria", "11/09/2001");
            Promemoria pr2;
            Promemoria pr3;
            Assert.Throws<Exception>(() => pr2 = new Promemoria("promemoriaaaaa prommm", "datafalsa")); //data invalida
            Assert.Throws<Exception>(() => pr3 = new Promemoria("pròmemoria", "datafalsa"));

            pr2 = new Promemoria("promemoriaaaaa prommm", "datafalsa");
            pr3 = new Promemoria("pròmemoria", "datafalsa");

            bc = new Bacheca("bacheca", "questa è una bacheca", "akar");
            bc.Aggiungi(pr1);
            bc.Aggiungi(pr1);
            bc.Aggiungi(pr1);
            bc.Aggiungi(pr2);
            bc.Aggiungi(pr3);

            Promemoria cb = bc.getPromemoria(12); //non restituisce DIRETTAMENTE tutti i promemoria
            Assert.True(cb == null);
        }

        [Fact]
        public void TestOttieniPromemoriaConNome()
        {
            pr = new Promemoria("qualcosa da fare", "datafalsa");
            Promemoria pr2 = new Promemoria("qualcosa", "data");
            string str = "qualcosa";
            bc = new Bacheca("bacheca", "questa è una bacheca", "akar");
            bc.Aggiungi(pr);
            bc.Aggiungi(pr2);

            string[] test = { pr.P, pr2.P, "?????" };
            string[] risultato = bc.getPromemoriaConParola(str, test); //confusionale, getPromemoria ma restituisce string
            Assert.True(risultato != null);
        }

        [Fact]
        public void TestOttieniPromemoriaConData()
        {
            string str = "20/20/1000";
            pr = new Promemoria("qualcosa da fare", "datafalsa");
            Promemoria pr1 = new Promemoria("qualcosa da fare", str);
            bc = new Bacheca("bacheca", "questa è una bacheca", "akar");

            string[] test = { pr.Data, str, pr1.Data, "?????", "111111" };
            string[] risultato = bc.getPromemoriaConData(str, test);
            Assert.True(risultato != null);
           
        }

        [Fact]
        public void TestElimina()
        {
            pr = new Promemoria("qualcosa", "ciao");
            bc = new Bacheca("bacheca", "questa è una bacheca", "akar");

            bc.Aggiungi(pr);
            bc.Rimuovi(pr);

            Assert.True(bc.getPromemoria(1) != pr);
            Assert.True(bc.getPromemoria(1) == null);
        }

        [Fact]
        public void TestSposta()
        {
            pr = new Promemoria("qualcosa", "ciao");
            bc = new Bacheca("bacheca", "questa è una bacheca", "akar");
            Bacheca bc1 = new Bacheca("bacheca", "questa è una bacheca", "akar");

            bc.Aggiungi(pr);
            bc.Sposta(bc1, pr);

            Assert.True(bc.getPromemoria(1) == null);
            Assert.True(bc1.getPromemoria(1) == pr);
        }
    }
}