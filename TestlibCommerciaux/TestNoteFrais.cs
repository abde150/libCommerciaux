using libCommerciaux;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TestlibCommerciaux
{
    [TestClass]
    public class TestNoteFrais
    {
        private Type GetNoteFraislType()
        {
            // Act
            var result = UtilsHelper.GetClassType(typeof(Commercial).Assembly, "NoteFrais");
            // Assert
            Assert.IsNotNull(result, "La classe NoteFrais n'existe pas");
            return result;
        }

        [TestMethod]
        public void TestClassExists()
        {
            // Assert
            Assert.IsTrue(UtilsHelper.ClassExists(typeof(Commercial).Assembly, "NoteFrais"), "La classe n'existe pas");

        }

        [TestMethod]
        public void TestConstructeurAvecParametres()
        {
            // Arrange
            Type type = GetNoteFraislType();
            Type commercialType = Type.GetType("Commercial");
            DateTime date = new DateTime(2023, 1, 1);


            // Act
            //NoteFrais noteFrais = new NoteFrais(date, commercial);
            ConstructorInfo constructor = type.GetConstructor(new Type[] { typeof(DateTime), typeof(Commercial) });
            Assert.IsNotNull(constructor, "Le constructeur avec paramètres n'existe pas dans la classe Commercial.");
            // Assert
            ConstructorInfo commercialConstructor = commercialType.GetConstructor(new Type[] { typeof(string), typeof(string), typeof(int), typeof(char) });
            if (commercialConstructor != null)
            {
                var commercial = commercialConstructor.Invoke(new object[] { "Dupont", "Jean", 5, 'A' });
                // Act : invoquer le constructeur avec les paramètres
                object[] parameters = new object[] { date, commercial };
                var notefraisInstance = constructor.Invoke(parameters);

                // Vérifier que l'instance a bien été créée
                Assert.IsNotNull(notefraisInstance, "L'instance de la classe Notefrais ne doit pas être null.");

                // Vérifier dateNoteFrais
                FieldInfo dateField = type.GetField("dateNoteFrais", BindingFlags.NonPublic | BindingFlags.Instance);
                Assert.IsNotNull(dateField, "Le champ 'date' n'existe pas.");


                // Vérifier leCommercial
                FieldInfo commercialField = type.GetField("leCommercial", BindingFlags.NonPublic | BindingFlags.Instance);
                Assert.AreSame(commercial, commercialField.GetValue(notefraisInstance), "l'objet Commercial n'existe pas");

                // Vérifier estRembourse
                FieldInfo rembourseField = type.GetField("estRembourse", BindingFlags.NonPublic | BindingFlags.Instance);
                Assert.IsFalse((bool)rembourseField.GetValue(notefraisInstance), "le champs remboursé n'est pas à False");

                // Vérifier numero
                FieldInfo numeroField = type.GetField("numero", BindingFlags.NonPublic | BindingFlags.Instance);
                Assert.AreEqual(0, (int)numeroField.GetValue(notefraisInstance), "le numéro n'est pas 0");
            }

            //// Vérifier que la note de frais a été ajoutée au commercial
            //MethodInfo getMesNoteFraisMethod = commercial.GetType().GetMethod("getMesNoteFrais");
            //var mesNoteFrais = getMesNoteFraisMethod.Invoke(commercial, null) as System.Collections.IEnumerable;
            //Assert.IsTrue(mesNoteFrais.Cast<object>().Contains(notefraisInstance), "la méthode getMesNoteFrais n'est pas créée");
        }
        [TestMethod]
        public void TestgetMontantARembourser()
        {
            // Arrange
            var type = GetNoteFraislType();
            //Agir
            var methodInfo = type.GetMethod("getMontantARembourser");
            //
            Assert.IsNotNull(methodInfo, "Propriété 'getMontantARembourser' non trouvée sur la classe NoteFrais");
            Assert.AreEqual(typeof(double), methodInfo.ReturnType, "Le retour doit être de type double");

        }
        [TestMethod]
        public void TestgetLeCommercial()
        {
            // Arrange
            var type = GetNoteFraislType();
            //Agir
            var methodInfo = type.GetMethod("getLeCommercial");
            //
            Assert.IsNotNull(methodInfo, "Propriété 'getLeCommercial' non trouvée sur la classe NoteFrais");
            Assert.AreEqual(typeof(Commercial), methodInfo.ReturnType, "Le retour doit être de type Commercial");

        }
        [TestMethod]
        public void TestsetRembourse()
        {
            // Arrange
            var type = GetNoteFraislType();
            //Agir
            var methodInfo = type.GetMethod("setRembourse");
            //
            Assert.IsNotNull(methodInfo, "Propriété 'setRembourse' non trouvée sur la classe NoteFrais");
            Assert.AreEqual(typeof(void), methodInfo.ReturnType, "Le retour doit être de type void");

        }
        [TestMethod]
        public void TestsetMontantARembourser()
        {
            // Arrange
            var type = GetNoteFraislType();
            //Agir
            var methodInfo = type.GetMethod("setMontantARembourser");
            //
            Assert.IsNotNull(methodInfo, "Propriété 'setMontantARembourser' non trouvée sur la classe NoteFrais");
            Assert.AreEqual(typeof(void), methodInfo.ReturnType, "Le retour doit être de type void");

        }
        [TestMethod]
        public void TestcalculMontantARembourser()
        {
            // Arrange
            var type = GetNoteFraislType();
            //Agir
            var methodInfo = type.GetMethod("calculMontantARembourser");
            //
            Assert.IsNotNull(methodInfo, "Propriété 'calculMontantARembourser' non trouvée sur la classe NoteFrais");
            Assert.AreEqual(typeof(double), methodInfo.ReturnType, "Le retour doit être de type double");

        }
        [TestMethod]
        public void ToStringTest()
        {
            // Arrange
            Type commercialType = Type.GetType("Commercial");
            Type type = GetNoteFraislType();
            DateTime date = new DateTime(2023, 1, 1);
            // Rechercher le constructeur avec les paramètres appropriés via réflexion
            ConstructorInfo constructor = type.GetConstructor(new Type[] { typeof(DateTime), typeof(Commercial) });
            Assert.IsNotNull(constructor, "Le constructeur avec paramètres n'existe pas dans la classe Commercial.");

            // Assert
            ConstructorInfo commercialConstructor = commercialType.GetConstructor(new Type[] { typeof(string), typeof(string), typeof(int), typeof(char) });
            if (commercialConstructor != null)
            {

                var commercial = commercialConstructor.Invoke(new object[] { "Dupont", "Jean", 5, 'A' });

                // Act : invoquer le constructeur avec les paramètres
                object[] parameters = new object[] { date, commercial };
                var notefraisInstance = constructor.Invoke(parameters);

                // Attendu
                string attendu = "Numéro : 0 - Date : 01/01/2023 00:00:00 - Montant à rembourser: 0 euros - Non remboursé";

                // Act : appeler la méthode ToString via réflexion
                MethodInfo toStringMethod = type.GetMethod("ToString");
                Assert.IsNotNull(toStringMethod, "La méthode ToString n'existe pas dans la classe Commercial.");
                string resultat = (string)toStringMethod.Invoke(notefraisInstance, null);

                // Assert : comparer les résultats
                Assert.AreEqual(attendu, resultat, "La méthode ToString ne retourne pas le résultat attendu.");
            }
        }
        [TestMethod]
        public void TestgetEstRembourse()
        {
            // Arrange
            var type = GetNoteFraislType();
            //Agir
            var methodInfo = type.GetMethod("getEstRembourse");
            //
            Assert.IsNotNull(methodInfo, "Propriété 'getEstRembourse ' non trouvée sur la classe NoteFrais");
            Assert.AreEqual(typeof(bool), methodInfo.ReturnType, "Le retour doit être de type void");
        }
    }
}

