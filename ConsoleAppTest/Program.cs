using Core;
using Domain;
using System;

namespace ConsoleAppTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var sessionFactory = UnitOfWork.CreateSessionFactory();
            using (var session = sessionFactory.OpenSession())
            {


                // retreive all entries and display them
                using (session.BeginTransaction())
                {
                    //var all = session.CreateSQLQuery("SELECT * FROM dbo.Patient");
                    //var Patients = all.List();
                    var Patients = session.CreateCriteria(typeof(PatientData))
                      .List<PatientData>();

                    foreach (var p in Patients)
                    {
                        Console.WriteLine(p.Firstname);
                    }
                }

                Console.ReadKey();
            }
        }
    }
}
