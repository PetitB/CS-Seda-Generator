﻿/*****************************************************************************************
 * 
 * Générateur de bordereaux de transfert guidé par le profil d'archivage
 *                         -----------------------
 * Département du Morbihan
 * Direction des systèmes d'information
 * Service Études
 * Patrick Percot
 * Mars-mai 2015
 * 
 * Réutilisation du code autorisée dans l'intérêt des collectivités territoriales
 * 
 * ****************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Specialized;
using System.Configuration;
using SedaSummaryGenerator;

namespace SedaSummaryGeneratorTester {
    class Program {

        static void Main(string[] args) {
            genererMarcheUneUnite();

            // genererPES();
            // genererESCO();
        }

        static void genererMarcheUneUnite() {
            StreamWriter streamWriter = null;

            String accordVersement = "CG56_ACCORD_MARCHE_TEST_8";
            String fichier_donnees = @"D:\DEV_PPE\tests\keywords\liste-fichiers1-01.txt";
            String fichier_bordereau = @"D:\DEV_PPE\tests\keywords\bordereau-debug-KW.xml";
            String traceFile = @"D:\DEV_PPE\tests\keywords\traces-debug-KW.txt";

            /*
            String accordVersement = "CD29_ACCORD_ENREG_SONORES";
            String fichier_donnees = @"D:\DEV_PPE\devel\gw-quimper\liste_repetition_une_unite-deux_documents.txt";
            String fichier_bordereau = @"D:\DEV_PPE\devel\gw-quimper\bordereau-enrson-1.xml";
            String traceFile = @"D:\DEV_PPE\devel\gw-quimper\traces-enrson-1.txt";
            */
            //string accordversement = "cg56_accord_marche_test_1";
            //string fichier_donnees = @"d:\dev_ppe\tests\marches\liste_repetition_une_unite-1.txt";
            //string fichier_bordereau = @"d:\dev_ppe\tests\work\bordereau-marche-une-unite.xml";
            //string tracefile = "d:/dev_ppe/traces/trace-marche-une-unite.txt";

            //String accordVersement = "CG56_ACCORD_MARCHE_TEST_2";
            //String fichier_donnees = @"D:\DEV_PPE\tests\marches\liste_repetition_une_unite_avec_sous_unites-1.txt";
            //String fichier_bordereau = @"D:\DEV_PPE\tests\work\bordereau-marche-une-unite_avec_sous_unites.xml";
            //String traceFile = "D:/DEV_PPE/traces/trace-marche-une-unite_avec_sous_unites.txt";

            //String accordVersement = "CG56_ACCORD_MARCHE_TEST_3";
            //String fichier_donnees = @"D:\DEV_PPE\tests\marches\liste_repetition_deux_unites_avec_sous_unites-1.txt";
            //String fichier_bordereau = @"D:\DEV_PPE\tests\work\bordereau-marche-deux_unites_avec_sous_unites.xml";
            //String traceFile = "D:/DEV_PPE/traces/trace-marche-deux_unites_avec_sous_unites.txt";

            //String accordVersement = "CG56_ACCORD_MARCHE_TEST_4";
            //String fichier_donnees = @"D:\DEV_PPE\tests\marches\liste_repetition_une_unite-deux_documents.txt";
            //String fichier_bordereau = @"D:\DEV_PPE\tests\work\bordereau-marche-une_unite-deux_documents.xml";
            //String traceFile = "D:/DEV_PPE/traces/trace-marche-une_unite-deux_documents.txt";

            //string accordVersement = "cg56_accord_marche_test_5";
            //string fichier_donnees = @"d:\dev_ppe\tests\marches\liste_repetition_une_unite-1.txt";
            //string fichier_bordereau = @"d:\dev_ppe\tests\work\bordereau-marche-une-unite-v1_0.xml";
            //string tracefile = "d:/dev_ppe/traces/trace-marche-une-unite-v1_0.txt";

            //String accordVersement = "CG56_ACCORD_MARCHE_TEST_6";
            //String fichier_donnees = @"D:\DEV_PPE\tests\CGI\20150619Profil_avec_doc_falcultatif_donne_avant_engagement\Sans documents dans MP_OetD_analyse_decision1\liste-fichiers-marches-V5bis.txt";
            //String fichier_bordereau = @"D:\DEV_PPE\tests\CGI\Test_MARCHES-V5bis\WORK\bordereau-marches-V5bis.xml";
            //String traceFile = @"D:/DEV_PPE\tests\CGI\Test_MARCHES-V5bis\WORK\trace-marches-V5bis.txt";
            //
            //String fichier_donnees = @"D:\DEV_PPE\tests\CGI\20150619Profil_avec_doc_falcultatif_donne_avant_engagement\Avec documents dans MP_OetD_analyse_decision1\liste-fichiers-marches-V5bis.txt";
            //String fichier_bordereau = @"D:\DEV_PPE\tests\CGI\Test_MARCHES-V5bis\WORK\bordereau-marches-V5bis-avec-optionnel.xml";
            //String traceFile = @"D:/DEV_PPE\tests\CGI\Test_MARCHES-V5bis\WORK\trace-marches-V5bis-avec-optionnel.txt";

            //string accordVersement = "CG56_ACCORD_MARCHE_TEST_7";
            //String fichier_donnees = @"D:\DEV_PPE\tests\marches\liste_repetition_une_unite-trois_documents.txt";
            //String fichier_bordereau = @"D:\DEV_PPE\tests\work\bordereau-marche-une_unite-trois_documents.xml";
            //String traceFile = @"D:/DEV_PPE/traces/trace-marche-une_unite-trois_documents.txt";

            String informationsDatabase = ConfigurationManager.AppSettings["databaseConnexion"];

            Action<Exception, String> eh = (ex, str) =>
            {
                Console.WriteLine(ex.GetType().Name + " while trying to use trace file: " + traceFile + ". Complementary message: " + str);
                throw ex;
            };

            try
            {
                streamWriter = new StreamWriter(traceFile);
            }
            catch (IOException e) { eh(e, "Mauvaise syntaxe de nom de fichier"); }
            catch (UnauthorizedAccessException e) { eh(e, "Droits d'accès à corriger"); }
            catch (System.Security.SecurityException e) { eh(e, "Droits d'accès à corriger"); }


            String baseURI = "http://test";

            StringCollection errors;

            SedaSummaryGenerator.SedaSummaryGenerator ssg = new SedaSummaryRngGenerator();
            ssg.setTracesWriter(streamWriter);

            ssg.prepareInformationsWithDatabase(informationsDatabase, baseURI, accordVersement);

            ssg.prepareArchiveDocumentsWithFile(@"D:\DEV_PPE\tests\marches", fichier_donnees);
            
            ssg.generateSummaryFile(fichier_bordereau);

            ssg.close();
            streamWriter.Close();

            errors = ssg.getErrorsList();

            if (errors != null && errors.Count != 0)
            {
                Console.WriteLine("Il y a eu des erreurs.");
                foreach (String str in errors)
                {
                    Console.WriteLine(str);
                }
            }
            Console.WriteLine("Fin de la liste des erreurs du programme de génération du bordereau");
            Console.WriteLine("Tapez une touche pour arrêter");
            Console.ReadKey();
        }


        static void genererPES()
        {
            StreamWriter streamWriter = null;
            String traceFile = "D:/DEV_PPE/traces/trace-PES.txt";
            String informationsDatabase = ConfigurationManager.AppSettings["databaseConnexion"];

            Action<Exception, String> eh = (ex, str) => {
                Console.WriteLine(ex.GetType().Name + " while trying to use trace file: " + traceFile + ". Complementary message: " + str);
                throw ex;
            };

            try {
                streamWriter = new StreamWriter(traceFile);
            } catch (IOException e) { eh(e, "Mauvaise syntaxe de nom de fichier"); } catch (UnauthorizedAccessException e) { eh(e, "Droits d'accès à corriger"); } catch (System.Security.SecurityException e) { eh(e, "Droits d'accès à corriger"); }


            String accordVersement = "CG56_ACCORD_PES_TEST";
            String baseURI = "http://test";

            StringCollection errors;

            SedaSummaryGenerator.SedaSummaryGenerator ssg = new SedaSummaryRngGenerator();
            ssg.setTracesWriter(streamWriter);

            ssg.prepareInformationsWithDatabase(informationsDatabase, baseURI, accordVersement);

            ssg.prepareArchiveDocumentsWithFile(@"\\cg56.fr\dfs2\BW\DEVT\SAE_PES\DEPOT", @"\\cg56.fr\dfs2\BW\DEVT\SAE_PES\DATA\liste-fichiers-pesv2.txt");

            ssg.generateSummaryFile(@"\\cg56.fr\dfs2\BW\DEVT\SAE_PES\WORK\bordereau-PESV2_MANUEL.xml");

            ssg.close();
            streamWriter.Close();

            errors = ssg.getErrorsList();

            if (errors != null && errors.Count != 0) {
                Console.WriteLine("Il y a eu des erreurs.");
                foreach (String str in errors) {
                    Console.WriteLine(str);
                }
            }
            Console.WriteLine("Fin de la liste des erreurs du programme de génération du bordereau");
            Console.WriteLine("Tapez une touche pour arrêter");
            Console.ReadKey();
        }

        
        static void genererESCO() {
            StreamWriter streamWriter = null;
            String traceFile = "D:/DEV_PPE/devel/RNG/trace.txt";
            String informationsDatabase = ConfigurationManager.AppSettings["databaseConnexion"];

            Action<Exception, String> eh = (ex, str) => {
                Console.WriteLine(ex.GetType().Name + " while trying to use trace file: " + traceFile + ". Complementary message: " + str);
                throw ex;
            };

            try {
                streamWriter = new StreamWriter(traceFile);
            } catch (IOException e) { eh(e, "Mauvaise syntaxe de nom de fichier"); } catch (UnauthorizedAccessException e) { eh(e, "Droits d'accès à corriger"); } catch (System.Security.SecurityException e) { eh(e, "Droits d'accès à corriger"); }


            String accordVersement = "ACCORD_TEST_ESCOAD";
            String baseURI = "http://test";
            ConvertLstDocEspaceCo2LstDocSAE converter = new ConvertLstDocEspaceCo2LstDocSAE("Documents de l'espace collaboratif des archives départementales de septembre 2014");
            converter.setTracesWriter(streamWriter);
            // converter.prepareInformationsWithDatabase(informationsDatabase, accordVersement);


            StringCollection errors = converter.convert("D:/DEV_PPE/devel/RNG/esco-ad/fichiers", "D:/DEV_PPE/devel/RNG/esco-ad/liste-fichiers-archive-escoad-02.txt", "preprodarchives.cg56.fr");

            if (errors != null && errors.Count != 0) {
                Console.WriteLine("Il y a eu des erreurs lors de la conversion.");
                foreach (String str in errors) {
                    Console.WriteLine(str);
                }
            } else {
                Console.WriteLine("Conversion achevée avec succès");
                SedaSummaryGenerator.SedaSummaryGenerator ssg = new SedaSummaryRngGenerator();
                ssg.setTracesWriter(streamWriter);

                //ssg.prepareInformationsWithDatabase(informationsDatabase, "ACCORD_TEST_ENRSON");
                ssg.prepareInformationsWithDatabase(informationsDatabase, baseURI, accordVersement);

                //ssg.prepareArchiveDocumentsWithFile("D:/DEV_PPE/devel/RNG/liste-fichiers-archive-enrson-01.txt");
                ssg.prepareArchiveDocumentsWithFile(@"D:\DEV_PPE\devel\RNG\esco-ad\fichiers", "D:/DEV_PPE/devel/RNG/esco-ad/liste-fichiers-archive-escoad-02.txt");

                //ssg.generateSummaryFile("D:/DEV_PPE/devel/RNG/bordereau-ENRSONASS.xml");
                ssg.generateSummaryFile("D:/DEV_PPE/devel/RNG/esco-ad/bordereau-ESCOAD.xml");

                /*
                ssg.prepareProfileWithFile("D:/DEV_PPE/devel/RNG/ASS-DEP_ENREG-SONORE-PROFIL-001_schema.rng");
                ssg.prepareArchiveDocumentsWithFile("D:/DEV_PPE/devel/RNG/liste-fichiers-archive-enrson-01.txt");
                try {
                    ssg.prepareInformationsWithFile("");
                }
                catch (NotImplementedException e) { streamWriter.WriteLine("TODO: write prepareInformationsWithFile ans set a real file ==> " + e.Message); }

                ssg.generateSummaryFile("D:/DEV_PPE/devel/RNG/bordereau-ENREG-SONORE.xml");
                */

                ssg.close();
                streamWriter.Close();

                errors = ssg.getErrorsList();

                if (errors != null && errors.Count != 0) {
                    Console.WriteLine("Il y a eu des erreurs.");
                    foreach (String str in errors) {
                        Console.WriteLine(str);
                    }
                }
                Console.WriteLine("Fin de la liste des erreurs du programme de génération du bordereau");
            }
            Console.WriteLine("Tapez une touche pour arrêter");
            Console.ReadKey();
        }
    }
}
