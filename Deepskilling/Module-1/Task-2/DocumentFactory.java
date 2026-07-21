public abstract class DocumentFactory {
    public abstract Document createDocument();

    public Document openNewDocument() {
        Document document = createDocument();
        document.open();
        return document;
    }
}
