using Domain.Entities;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Application.Common.Reports
{
    internal class Reports
    {
        private const string SPACING = "                ";
        public static String BuildContract(CheckIn rent)
        {
            var doc = new Document(PageSize.LETTER, 10, 10, 42, 35);
            var mem = new MemoryStream();

            PdfWriter wri = PdfWriter.GetInstance(doc, mem);

            doc.Open();

            var label = FontFactory.GetFont("Times New Roman", 9, Font.BOLD, new BaseColor(0, 0, 0));
            var title = FontFactory.GetFont("Times New Roman", 14, Font.BOLD, new BaseColor(0, 0, 0));
            var title2 = FontFactory.GetFont("Times New Roman", 12, Font.BOLD, new BaseColor(0, 0, 0));

            Paragraph paragraph = new Paragraph("Contrato de locação de veículo", title);
            paragraph.Alignment = Element.ALIGN_CENTER;
            paragraph.SpacingAfter = 40;

            var paragraphSpacing = new Paragraph("");
            paragraphSpacing.SpacingAfter = 10;

            doc.Add(paragraph);
            doc.Add(new Phrase("Locatário:  ", label));
            doc.Add(new Chunk(rent.Customer.FullName));
            doc.Add(new Chunk(SPACING));
            doc.Add(new Phrase("Nascido(a):  ", label));
            doc.Add(new Chunk(rent.Customer.BirthDate.ToString()));
            doc.Add(paragraphSpacing);

            doc.Add(new Phrase("Endereço:  ", label));
            doc.Add(new Chunk(String.Format("{0} Nº {1}, {2} - {3}, {4}", rent.Customer.PublicPlace, rent.Customer.Number, rent.Customer.City, rent.Customer.State, rent.Customer.ZipCode)));
            doc.Add(new Chunk(SPACING));
            doc.Add(paragraphSpacing);

            doc.Add(new Phrase("Carro:  ", label));
            doc.Add(new Chunk(String.Format("{0} {1} {2}", rent.Car.Model.Brand.Name, rent.Car.Model.Name, rent.Car.YearManufacture)));
            doc.Add(new Chunk(SPACING));
            doc.Add(new Phrase("Cor:  ", label));
            doc.Add(new Chunk(rent.Car.Color));
            doc.Add(new Chunk(SPACING));
            doc.Add(new Phrase("Placa:  ", label));
            doc.Add(new Chunk(rent.Car.LicensePlate));
            doc.Add(paragraphSpacing);
            doc.Add(paragraphSpacing);
            doc.Add(paragraphSpacing);
            doc.Add(new Paragraph("As partes acima identificadas têm, entre si, justo e acertado o presente Contrato de Locação de Automóvel por Prazo Determinado, que se regerá pelas cláusulas seguintes e pelas condições descritas no presente."));
            doc.Add(paragraphSpacing);
            doc.Add(new Paragraph("DO PRAZO:", title2));
            var prazo = "A presente locação terá o lapso temporal de validade de 90 dias, podendo ser renovado por vontade das partes, iniciando no dia {0} e terminando no dia {1}, data na qual o automóvel deverá ser devolvido no estado em que foi locado, sem avarias.";
            doc.Add(new Paragraph(String.Format(prazo, rent.Start, rent.End)));
            doc.Add(new Paragraph("DO PAGAMENTO:", title2));
            var pagamento = "O valor total de pagamento será de R$ {0}. Considerando um custo adicional de 30% do valor da locação em cada ocorrência considerando os itens: CARRO LIMPO, TANQUE CHEIO, AMASSADOS e ARRANHÕES.";
            doc.Add(new Paragraph(String.Format(pagamento, rent.ContractValue)));

            var newparagraphSpacing = paragraphSpacing;
            newparagraphSpacing.SpacingAfter = 300;
            var now = DateTime.Now;
            doc.Add(newparagraphSpacing);
            doc.Add(new Phrase(String.Format("{0}-{1}, {2} de {3} de {4}", rent.Customer.City, rent.Customer.State, now.Day, now.ToString("MMMM"), now.Year), label));
            var t = new Paragraph("");
            t.SpacingAfter = 10;
            doc.Add(t);
            doc.Add(new Phrase("___________________________________"));
            doc.Add(new Phrase("                                     "));
            doc.Add(new Phrase("___________________________________"));
            doc.Add(new Paragraph(""));
            doc.Add(new Phrase("                             Locador             "));
            doc.Add(new Phrase("                                     "));
            doc.Add(new Phrase("                                               Locatário            "));
            doc.Close();

            var pdf = mem.ToArray();

            return Convert.ToBase64String(pdf);
        }
    }
}
