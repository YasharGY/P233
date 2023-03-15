namespace PrintProject.Core.Models
{
    public class Pdf:Print
    {
        public override void Write()
        {
            Console.WriteLine("Pdf is created");
        }
    }
}
