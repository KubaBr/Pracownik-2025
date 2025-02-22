namespace Pracownik.Tests

{
    public class Tests
    {

        [Test]
        public void WhenAddGrade_ShouldSumResultMin()
        {

            // arrange
            var mietek = new Employee("Mierczas", "Miroslawski");
            
            mietek.NowaOcena(5);
            mietek.NowaOcena(7);
            var statystyki = mietek.GetStatystyki();

            //act
            var result = statystyki.Min;

            //assert

            Assert.AreEqual(5, result);
        }

        [Test]
        public void WhenAddGrade_ShouldSumResultMax()
        {

            // arrange
            var czeslaw = new Employee("Czeslaw", "Czechowski");
            czeslaw.NowaOcena(5);
            czeslaw.NowaOcena(7);
            var statystyki = czeslaw.GetStatystyki();

            //act
            var result = statystyki.Max;

            //assert
            Assert.AreEqual(7, result);
        }
        [Test]
        public void WhenAddGrade_ShouldSumResultAvarage()
        {

            // arrange
            var wlodziu = new Employee("Wladzek", "Wladkowski");
            wlodziu.NowaOcena(5);
            wlodziu.NowaOcena(7);

            var stastystyki = wlodziu.GetStatystyki();


            //act
            var result = stastystyki.Srednia;

            //assert
            Assert.AreEqual(6,result); 
        }
    }
}