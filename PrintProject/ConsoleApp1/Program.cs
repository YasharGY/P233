using PrintProject.Core.Models;

Print print = new();
Pdf pdf = new();
Excell excell= new();

print.Write();
excell.Write();
pdf.Write();
object[] arr = { print, excell, pdf};
