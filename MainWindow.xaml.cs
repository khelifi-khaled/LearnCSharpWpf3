using LearnCSharpWpf3.Models;
using LearnCSharpWpf3.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LearnCSharpWpf3.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string PIC_DIR = @"C:\Users\Admin\Desktop\IRAM-ps\poo\photos";
        private const string USERS_CSV_FILE = @"C:\Users\Admin\Desktop\IRAM-ps\poo\Utilisateurs.csv";

        public MainWindowVM MainVM;
        public MainWindow()
        {
            MainVM = new MainWindowVM();

            DataContext = MainVM;
            InitializeComponent();
        }
        private void ButtonTestCreateFirstUsers_Click(object sender, RoutedEventArgs e)
        {
            //User u1 = new User(lastName: "Beumier", firstName: "Damien", idUser: 0, levelAccess: 1, password: "Bidule01", picture: PIC_DIR + "beumier.jpg", gender: true, birthday: DateTime.Parse("20/03/2002"));
            ////appel du constructeur avec des paramètres nommés
            //User u2 = new User(lastName: "Deroisin", firstName: "Sophie", idUser: 1, levelAccess: 1, password: "Pourquoi1000", picture: PIC_DIR + "deroisin.jpg", gender: false, birthday: DateTime.Parse("18/08/1999"));



            ////appel du constructeur sans paramètres nommés
            //User u3 = new User(DateTime.Parse("23/05/1998"), "Durant", "Pierre", 2, 3, "Ampoule23", PIC_DIR + "durant.jpg", true);

            //u3._password = "Stone123";
            //u3._login = "DurDur";
            //u3._levelAccess = 1000;
            //MessageBox.Show($"Le mot de passe de u3 est {u3._password}");

            ////si rien n'est précisé, paramètres par défaut
            //User u4 = new User(DateTime.Parse("14/1/1995"), "Flaux");
            ////crée une référence vers une instance qui n'existe pas encore
            //User u5;
            //u5 = new User(DateTime.Parse("29/08/1984"));




        }
        private void ButtonTestEncapsulation_Click(object sender, RoutedEventArgs e)
        {
            //User u = new User(lastName: "Deroisin", firstName: "Sophie", idUser: 1, levelAccess: 1, password: "Pourquoi1000", picture: PIC_DIR + "deroisin.jpg", gender: false, birthday: DateTime.Parse("18/08/1999"));

            //Console.WriteLine($"Prénom avant modification : {u.FirstName}");
            //u.FirstName = "Marie-Sophie";
            //Console.WriteLine($"Prénom après tentative de modification : {u.FirstName}");

            //Console.WriteLine($"Genre avant modification : {u.Gender}");
            //u.Gender = true;
            //Console.WriteLine($"Genre après tentative de modification : {u.Gender}");

            //Console.WriteLine($"Date de naissance avant modification : {u.Birthday}");
            //u.Birthday = DateTime.Parse("04/04/2001");
            //Console.WriteLine($"Date de naissance après tentative de modification : {u.Birthday}");

            //Console.WriteLine($"Login de l'utilisateur : {u.Login}");
            //u.FirstName = "Jeanne";
            //Console.WriteLine($"Login de l'utilisateur après modification du prénom : {u.Login}");
            //u.LastName = "De Bon-Voisin";
            //Console.WriteLine($"Login de l'utilisateur après modification du nom : {u.Login}");

            //User u = new User(lastName: "Beumier", firstName: "Damien", idUser: 0, levelAccess: 1, password:"TrucMachin01", picture: PIC_DIR +"beumier.jpg", gender: true, birthday: DateTime.Parse("20/03/ 2002"));
            ////MessageBox.Show($"Voici votre mot de passe {u.Password }");
            ////u.Password = "Bidule01";
            //Console.WriteLine($" mot de passe correct ? : {u.IsRightPassword("DmBeum007")}");
            //Console.WriteLine($" mot de passe correct ? : {u.IsRightPassword("TrucMachin01")}");



            //User firstUser = new User(lastName: "Beumier", firstName: "Damien", idUser: 0, levelAccess: 1, password: "Password01", picture: PIC_DIR + "beumier.jpg", gender: true, birthday: DateTime.Parse("20/03/2002"));
            //User secondUser = new User(lastName: "Deroisin", firstName: "Sophie", idUser: 1, levelAccess: 4, password: "Password01", picture: PIC_DIR + "deroisin.jpg", gender: false, birthday: DateTime.Parse("18/08/1999"));
            //Console.WriteLine($"Niveau d'accès de l'utilisateur {firstUser.LastName} avant tentative de modification: { firstUser.LevelAccess}");
            //firstUser.LevelAccess = 3; //non autorisé à mettre en commentaires
            //secondUser.ChangeLevelAccess(3, firstUser); //secondUser essaie de changer le niveaud'accès de firstUser
            //Console.WriteLine($"Niveau d'accès de l'utilisateur {firstUser.LastName} après tentative de modification: { firstUser.LevelAccess}");
            //Console.WriteLine($"Niveau d'accès de l'utilisateur {secondUser.LastName} avant tentative de modification: { secondUser.LevelAccess}");
            //firstUser.ChangeLevelAccess(2, secondUser); //firstUser essaie de changer le niveau d'accès de secondUser
            //Console.WriteLine($"Niveau d'accès de l'utilisateur {secondUser.LastName} après tentative de modification: { secondUser.LevelAccess}");
        }
        private void ButtonTestStatic_Click(object sender, RoutedEventArgs e)
        {
            //User.Company = "Solutech";
            //User u1 = new User(DateTime.Parse("1/02/2000"), "Beumier", "Damien", 2, picture: PIC_DIR + "beumier.jpg");
            //User u2 = new User(DateTime.Parse("18/08/1998"), "Deroisin", "Sophie", 3, picture: PIC_DIR + "deroisin.jpg", gender: false);
            //MessageBox.Show($"Le nom de la société de tous les collaborateurs {u1.LastName},{u2.LastName}, ... est {User.Company}");
        }
        private void ButtonTestStaticCreateEmployees_Click_1(object sender, RoutedEventArgs e)
        {
            //Electrician e1 = new Electrician(isBA5: true, highVoltage: false, isBA4: true, isOnCall: false, overtime: 0, birthday: DateTime.Parse("20/03/2002"), lastName: "Beumier", firstName: "Damier", idUser: 0, levelAccess: 1, password: "TrucMachin", picture: PIC_DIR + "beumier.png", gender: true);
            //MessageBox.Show($"Le Electrician {e1.FirstName},{e1.LastName},a ete bien crie ");

            //TechnicalDir td = new TechnicalDir();
            //td.RandomPasswordChange();

            //WorkshopSupervisor ws = new WorkshopSupervisor();

            //ws.EquipmentOrder();


        }
        private void ButtonTestCollections_Click_1(object sender, RoutedEventArgs e)
        {
            ////besoin de rajouter using System.Collections.ObjectModel
            //ObservableCollection<Worker> wOc = new ObservableCollection<Worker>();



            //Worker e1 = new Electrician(isBA5: true, highVoltage: false, isBA4: true, isOnCall: false, overtime: 0, birthday: DateTime.Parse("20/03/2002"), lastName: "Beumier", firstName: "Damien", idUser: 0, password: "TrucMachin01", picture: PIC_DIR + "beumier.jpg");



            //Worker e2 = new Electrician(isBA5: true, highVoltage: true, isBA4: true, isOnCall: false, overtime: 0, birthday: DateTime.Parse("10/06/1995"), lastName: "Duquenne", firstName: "Cedric", idUser: 1, picture: PIC_DIR + "duquenne.jpg");



            //Worker m1 = new Mechanic(isWelder: false, isBA4: true, isOnCall: false, overtime: 0, birthday: DateTime.Parse("4/12/1997"), lastName: "Vandersmissen", firstName: "Sebastien", idUser: 2, picture: PIC_DIR + "vandersmissen.png");



            //Worker m2 = new Mechanic(isWelder: true, isBA4: true, isOnCall: true, overtime: 2.0, birthday: DateTime.Parse("24/11/1997"), lastName: "Maggi", firstName: "Tony", idUser: 3, picture: PIC_DIR + "maggi.png");



            ////remplit la collection d'ouvriers
            //wOc.Add(e1);
            //wOc.Add(e2);
            //wOc.Add(m1);
            //wOc.Add(m2);



            //Console.WriteLine($"nombre d'ouvriers dans la collection : {wOc.Count}");
            //Console.WriteLine("Parcours de la liste avec une boucle for each :");



            //foreach (Worker w in wOc)
            //{



            //    Console.WriteLine($"{w.FullName}");
            //}



            //Console.WriteLine("\nParcours de la liste avec un index, collection semblable à un tableau");
            //for (int i = 0; i < wOc.Count; i++)
            //{



            //    Console.WriteLine(wOc[i].FullName);
            //}
            //Console.WriteLine($"\n3ème élément de la collection : {wOc[2].FirstName} - {wOc[2].LastName}\n");
            //Console.WriteLine($"\n3ème élément de la collection : {wOc[2].FullName}\n");
            //Console.WriteLine("Supression du 3ème élément");



            //wOc.RemoveAt(2);//suppression du 3ème élément (index 2)
            //Console.WriteLine($"nombre d'ouvriers dans la collection : {wOc.Count}");



            //foreach (Worker w in wOc)
            //{



            //    Console.WriteLine(w.FullName);
            //}

        }
        private void ButtonTestReadWriteCsvFile_Click_1(object sender, RoutedEventArgs e)
        {
            //const string PROJECT_DIR = @"C:\Users\Admin\source\repos\LearnCSharpWpf3\";



            //List<string> listFileReader = new List<string>();

            //listFileReader = System.IO.File.ReadAllLines(PROJECT_DIR + "Utilisateurs.csv").ToList();

            //foreach (string s in listFileReader)
            //{
            //    Console.WriteLine(s);
            //}
            //List<string> listFileWriter = new List<string>();
            //listFileWriter = listFileReader.ToList();
            //listFileWriter.Add("Electrician;Bruno;Demoulin;11;1;1;Julien14;23-09-90;demoulin.jpg");
            //listFileWriter.Add("Mechanic;Jean;Virelle;12;1;1;3Tondeuse;5-07-92;virelle.jpg");
            //System.IO.File.WriteAllLines(@"c:\temp\UtilisateursCopy2.csv", listFileWriter);
            ////Apprend ajoute au fichier existant sans l'écraser.
            ////System.IO.File.AppendAllLines(PROJECT_DIR + "UtilisateursCopy.csv", listFileWriter);

        }
        private void ButtonTestLambdasOnList_Click_1(object sender, RoutedEventArgs e)
        {
            ////récupération de la liste des employés 
            //List<User> employees = MainVM.Users.ToList<User>();

            ////recherche du personnel de sexe féminin
            //Console.WriteLine("Employées :\n---------------------- - ");
            //List<User> selectionList = employees.FindAll(u => !u.Gender );// ou ==false 
            //selectionList.ForEach(u => Console.WriteLine(u.FullName));

            ////recherche du personnel de niveau d'accès supérieur à 2V.
            //Console.WriteLine("\nEmployés de niveau d'accès supérieur à 2 :\n----------------------------------- - ");
            //selectionList = employees.FindAll(u => u.LevelAccess >= 2);
            //selectionList.ForEach(u => Console.WriteLine($"{u.FullName} niveau d'accès :{u.LevelAccess}"));



            ////recherche du personnel Electriciens
            //Console.WriteLine("\nElectriciens : \n--------------------");
            //selectionList = employees.FindAll(u => u.GetType().ToString().Contains("Electrician"));
            //selectionList.ForEach(u => Console.WriteLine($"{u.FullName} type :{u.GetType().ToString()}"));


            ////recherche des hommes de plus de 30 ans
            //Console.WriteLine("\nHommes de plus de 30 ans : \n------------------------------");
            //selectionList = employees.FindAll(u => DateTime.Now.AddYears(-30) > u.Birthday && u.Gender); //ou == true 
            //selectionList.ForEach(u => Console.WriteLine($"{u.FullName} date de naissance : {u.Birthday}"));



            ////recherche de Pierre Durant
            //Console.WriteLine("\nRecherche de Pierre Durant dans la liste : \n-------------------------------- - ");
            //User employee = employees.Find(u => u.FullName.Equals("Pierre Durant"));
            //Console.WriteLine((employee != null) ? $"employé Pierre Durant trouvé {employee.Birthday}:" : "Pierre Durant pas trouvé");


            ////si on veut seulement savoir si Pierre Durant est dans la liste
            //Console.WriteLine(employees.Exists(u => u.FullName.Equals("Pierre Durant")) ? "Pierre Durant Existe bien" : "PierreDurantn'existe pas");


            ////recherche de l'ainé de sexe masculin
            //Console.WriteLine("\nRecherche de l'ainé : \n-----------------------------");
            //User oldest = employees.Find(u => u.Birthday == employees.Min(x => x.Birthday) && u.Gender);
            //Console.WriteLine($"L'ainé est :{ oldest.FullName} année de naissance : {oldest.Birthday.Year}");



            ////recherche Au moins une femme dans le personnel
            ////
            //Console.WriteLine("\nAu moins une femme dans le personnel ? : \n------------------------");
            //Console.WriteLine(employees.All(u => u.Gender) ? "Non, tout le personnel est masculin" : "Oui, au moins une femme dans le personnel");


            ////moyenne des niveaux d'accès
            //Console.WriteLine($"Niveau d'accès moyen { employees.Average(u => u.LevelAccess)}");


            ////Tri par ordre alphabétique
            //Console.WriteLine("\nTri alphabétique par nom de famille : \n------------------------ ");
            //List<User> sortedUsers = employees.OrderBy(u => u.LastName).ToList();
            //sortedUsers.ForEach(u => Console.WriteLine($"{u.LastName}"));

            ////tous les employés masculins nés à partir de 2000
            //Console.WriteLine("\ntous les employés masculins nés à partir de 2000 : \n------------------------ ");
            //List<User> masculins2000 = employees.FindAll(u=>u.Gender &&  u.Birthday.Year >=2000 );
            //masculins2000.ForEach(u => Console.WriteLine($"{u.FullName} {u.Birthday}"));

            ////tous les employés dont le mot de passe n’aurait pas été changé et serait encore "Password01"
            //Console.WriteLine("\ntous les employés dont le mot de passe n’aurait pas été changé et serait encore Password01: \n------------------------ ");
            //List<User> Password = employees.FindAll(u => !u.IsSafePassword);
            //Password.ForEach(u => Console.WriteLine(u.FullName));


            ////tous les employés dont la photo n’est pas renseignée 
            //Console.WriteLine("\ntous les employés dont la photo n’est pas renseignée \n------------------------ ");
            //List<User> photo = employees.FindAll(u => Directory.Exists(u.Picture)  );
            //photo.ForEach (u => Console.WriteLine(u.FullName));

            ////tous les employés dont le N° identifiant est pair
            //Console.WriteLine("\ntous les employés dont le N° identifiant est pair \n------------------------ ");
            //List<User> idp = employees.FindAll(u => u.IdUser%2==0 );
            //idp.ForEach(u => Console.WriteLine(u.FullName +" "+u.IdUser));

            ////savoir s’il y a au moins un employé né avant 1965 
            //Console.WriteLine("\nsavoir s’il y a au moins un employé né avant 1965 \n------------------------ ");
            //bool older  = employees.Exists(u => u.Birthday.Year< 1965);
            //Console.WriteLine(older? "il existe bien":"n existe pas ");

            ////le classement des employés par ordre décroissant des niveaux d’accès 
            //Console.WriteLine("\nle classement des employés par ordre décroissant des niveaux d’accès \n------------------------ ");
            ////var l = from u in employees orderby u.LevelAccess descending select u;

            ////foreach (var list in l)
            ////{
            ////    Console.WriteLine($"le nom : {list.FullName}, niveaux d’accès : { list.LevelAccess}");
            ////}
            // sortedUsers = employees.OrderByDescending(u => u.LevelAccess).ToList();
            //sortedUsers.ForEach(u => Console.WriteLine($"{u.FullName} niveau d'accès :{u.LevelAccess}"));


        }
        private void ButtonTestPolymorphisme_Click(object sender, RoutedEventArgs e)
        {
            //Electrician e1 = new Electrician(isBA5: true, highVoltage: false, isBA4: true, isOnCall: false, overtime: 0,birthday: DateTime.Parse("20/03/2002"), lastName: "Beumier", firstName: "Damien", idUser: 0, levelAccess: 1, password: "TrucMachin01", picture: PIC_DIR + "beumier.jpg", gender: true);
            //Worker w = e1;
            //User u = e1;
            ////La méthode GetType() sur l’objet u, pourtant de type User, renvoie Electrician
            //MessageBox.Show($"type d'objet : {u.GetType()}");

            //on peux pas faire ca , le type doit etre la class parent 
            //User employee = new User();
            //Electrician electrician = employee;


            //Electrician e1 = new Electrician(isBA5: true, highVoltage: false, isBA4: true, isOnCall: false,overtime: 0, birthday: DateTime.Parse("20/03/2002"), lastName: "Beumier", firstName: "Damien", idUser: 0, levelAccess: 1, password: "TrucMachin01", picture: "beumier.jpg", gender: true);

            //Worker w = e1; 
            //User u = e1;
            ////Il est aussi possible de revenir à une référence d’objet plus spécifique par un cast et sans aucune
            ////perte d’informations
            //Electrician elec = (Electrician)u;



        }//end ButtonTestPolymorphisme_Click
        private void ButtonHideMethod_Click_1(object sender, RoutedEventArgs e)
        {
          //  WorkshopSupervisor ws1 = new WorkshopSupervisor(birthday: DateTime.Parse("20/03/2002"), lastName: "Durant",
          //firstName: "Pierre", idUser: 0, levelAccess: 3);

          //  //ws1.WageCalculation();//inherits from base class

          //  Electrician e1 = new Electrician(isBA5: true, highVoltage: false, isBA4: true, isOnCall: false, overtime: 0, birthday: DateTime.Parse("20/03/2002"), lastName: "Beumier", firstName: "Damien", idUser: 0, levelAccess: 1, password: "TrucMachin01", picture: "beumier.jpg", gender: true);


          // // e1.WageCalculation();


          //  SalesMan s1 = new SalesMan(birthday: DateTime.Parse("24/11/1997"), lastName: "Maggi", firstName: "Tony", idUser: 8, levelAccess: 2);


          //  //s1.WageCalculation();

          //  List<User> users = new List<User>();
          //  users.Add(ws1);
          //  users.Add(e1);
          //  users.Add(s1);


          //  foreach(User u in users)
          //  {
          //      u.WageCalculation();
          //  }




        }//end ButtonHideMethod_Click_1
        private void ButtonOverrideMethod_Click_1(object sender, RoutedEventArgs e)
        {
            foreach (User u in MainVM.Users)
            {
                u.WageCalculation();
            }

        }//end ButtonOverrideMethod_Click_1
    }//end class

}//end project 
