using Monitorizare_Sanatate.Data;
using Monitorizare_Sanatate.Models;

namespace Monitorizare_Sanatate
{
    class Program
    {
        static List<MasuratoriGlicemie> listaGlicemie = new List<MasuratoriGlicemie>();
        static List<MasuratoriCardiovasculare> listaTensiune = new List<MasuratoriCardiovasculare>();
        static AdministratorPacienti admin = new AdministratorPacienti();
        static Pacient pacientNou = null;
        static void Main(string[] args)
        {
            Console.WriteLine("Monitorizare sanatatii pacientilor");
            Pacient pacient1 = new Pacient("Rusu", "Luiza", new DateTime(1989,06,04) , "rusu_luiza@gmail.com", "0756337910");
            MasuratoriGlicemie glicemie1 = new MasuratoriGlicemie(new DateTime(2024,08,10),  90, "mg/dl", pacient1);
            MasuratoriCardiovasculare tensiune1 = new MasuratoriCardiovasculare(new DateTime(2024,08,10), 150, 90, 100, pacient1);
            SistemeAlerta alerta = new SistemeAlerta();
            alerta.VerificareGlicemie(glicemie1);
            alerta.VerificareTensiune(tensiune1);
            alerta.VerificarePuls(tensiune1);
            Console.WriteLine(alerta.VerificareGlicemie(glicemie1));
            Console.WriteLine(alerta.VerificareTensiune(tensiune1));
            Console.WriteLine(pacient1.ToString() + "\n" + glicemie1.ToString() + "\n" + tensiune1.ToString());
            string optiune;
            do
            {
                Console.WriteLine("1.Citire informatii pacient de la tastatura");
                Console.WriteLine("2.Afisare informatii pacient");
                Console.WriteLine("3.Afisare istoric valori glicemie");
                Console.WriteLine("4.Afisare istoric valori tensiune arteriala");
                Console.WriteLine("5.Cauta pacient dupa nume");
                Console.WriteLine("6.Inchide programul");
                Console.WriteLine("7.Alegeti optiunea dorita:");
                optiune = Console.ReadLine();
                switch (optiune)
                {
                    case "1":
                        Console.WriteLine("Introduceti numele pacientului: ");
                        string nume = Console.ReadLine();
                        Console.WriteLine("Introduceti prenumele pacientului: ");
                        string prenume = Console.ReadLine();
                        Console.WriteLine("Introduceti data nasterii pacientului (an/luna/zi):");
                        DateTime dataNasterii = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("Introduceti emailul pacientului: ");
                        string email = Console.ReadLine();
                        Console.WriteLine("Introduceti numarul de telefon al pacientului: ");
                        string telefon = Console.ReadLine();
                        pacientNou = new Pacient(nume, prenume, dataNasterii, email, telefon);
                        admin.AdaugaPacient(pacientNou);
                        break;
                    case "2":
                        if (pacientNou != null)
                        {
                            Console.WriteLine(pacientNou.ToString());
                        }
                        else
                        {
                            Console.WriteLine("Nu exista informatii despe pacient");

                        }
                        break;
                    case "3":
                        if (pacientNou != null)
                        {
                            Console.WriteLine("Introduceti valoarea glicemiei: ");
                            double valoareaGlicemiei = double.Parse(Console.ReadLine());
                            MasuratoriGlicemie glicemieNoua = new MasuratoriGlicemie(DateTime.Now, valoareaGlicemiei, "mg/dl", pacientNou);
                            listaGlicemie.Add(glicemieNoua);
                            Console.WriteLine("Valoarea a fost adaugata in istoric");

                        }
                        else
                        {
                            Console.WriteLine("Nu exista informatii despe pacient");
                        }
                        break;
                    case "4":
                        if (pacientNou != null)
                        {
                            Console.WriteLine("Introduceți tensiunea sistolica: ");
                            int sistolica = int.Parse(Console.ReadLine());
                            Console.Write("Introduceți tensiunea diastolica: ");
                            int diastolica = int.Parse(Console.ReadLine());
                            Console.Write("Introduceți pulsul: ");
                            int puls = int.Parse(Console.ReadLine());
                            MasuratoriCardiovasculare tensiuneNoua = new MasuratoriCardiovasculare(DateTime.Now, sistolica, diastolica, puls, pacientNou);
                            listaTensiune.Add(tensiuneNoua);
                            Console.WriteLine("Valoarea a fost adaugata in istoric");

                        }
                        else
                        {
                            Console.WriteLine("Nu exista informatii despe pacient");
                        }
                        break;
                    case "5":
                        
                        Console.WriteLine("Introduceti numele pacientului: ");
                        string numeCautat = Console.ReadLine();
                        var pacientGasit = admin.CautaDupaNume(numeCautat);
                        if(pacientGasit.Any())
                        {
                            foreach(var pacient in pacientGasit)
                            {
                                Console.WriteLine(pacient);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Nu exista informatii despre pacient");

                        }
                        break;
                    case "6":
                        Console.WriteLine("Aplicatia va fi inchisa");
                        return;

                    default:
                        Console.WriteLine("Optiune inexistenta");
                        break;
                }

            } while (optiune!="6");



                }


            }



        }
    
