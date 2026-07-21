public class DocumentFactoryTest {
    public static void main(String[] args) {
        DocumentFactory[] factories = {
            new WordDocumentFactory(), new PdfDocumentFactory(), new ExcelDocumentFactory()
        };
        Class<?>[] expected = { WordDocument.class, PdfDocument.class, ExcelDocument.class };

        for (int i = 0; i < factories.length; i++) {
            Document document = factories[i].openNewDocument();
            assert document.getClass() == expected[i] : "Factory " + i + " produced wrong type";
        }

        System.out.println("Factory Method check passed.");
    }
}
