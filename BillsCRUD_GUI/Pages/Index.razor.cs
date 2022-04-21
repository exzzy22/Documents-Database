namespace BillsCRUD_GUI.Pages;

public partial class Index
{
    [Parameter]
    public string? Category { get; set; }
    [CascadingParameter]
    private IModalService Modal { get; set; }
    private IEnumerable<DocumentDTO> Documents { get; set; }
    private IEnumerable<DocumentDTO> DocumentsNonFiltered { get; set; }
    private IEnumerable<string?> Categories { get; set; }
    private string Search { get; set; } = string.Empty;
    private bool SearchSpinner { get; set; } = false;

    protected async override Task OnInitializedAsync()
    {
        Documents = await _documentService.GetAll();
        DocumentsNonFiltered = Documents;
        Categories = Documents.GetCategories();
    }
    protected override async Task OnParametersSetAsync()
    {
        Documents = await _documentService.GetAll();
        if (Category == null)
        {
            DocumentsNonFiltered = Documents;
        }
        else
        {
            Documents = Documents.Where(d => d.Category == Category);
            DocumentsNonFiltered = Documents;
        }
        Categories = Documents.GetCategories();
    }
    /// <summary>
    /// Opens _PopUpEdit component
    /// </summary>
    /// <param name="doc"></param>
    /// <returns></returns>
    private async Task ShowEditDocument(DocumentDTO doc)
    {
        var parameters = new ModalParameters();
        parameters.Add(nameof(_PopUpEdit.DocumentModel), doc);
        parameters.Add(nameof(_PopUpEdit.Categories), Categories);
        var messageForm = Modal.Show<_PopUpEdit>("Edit Document", parameters);
        var result = await messageForm.Result;
        
        if (!result.Cancelled)
        {
            Documents = await _documentService.GetAll();
            DocumentsNonFiltered = Documents;
        }

    }
    /// <summary>
    /// Opens _PopUpAdd component
    /// </summary>
    /// <returns></returns>
    private async Task ShowAddDocument()
    {
        var parameters = new ModalParameters();
        parameters.Add(nameof(_PopUpAdd.Categories), Categories);
        var messageForm = Modal.Show<_PopUpAdd>("Add Document", parameters);
        var result = await messageForm.Result;

        if (!result.Cancelled)
        {
            Documents = await _documentService.GetAll();
            DocumentsNonFiltered = Documents;
        }
    }
    /// <summary>
    /// Delete document from DB
    /// </summary>
    /// <param name="doc"></param>
    /// <returns></returns>
    private async Task RemoveDocument(DocumentDTO doc)
    {
        var messageForm = Modal.Show<_ConfirmDelete>("Delete Document");
        var result = await messageForm.Result;

        if (!result.Cancelled)
        {
            await _documentService.Delete(doc);
            Documents = await _documentService.GetAll();
            DocumentsNonFiltered = Documents;
        }
    }
    /// <summary>
    /// Convert document from binary to file and download
    /// </summary>
    /// <param name="doc"></param>
    /// <returns></returns>
    private async Task DownloadDocument(DocumentDTO doc)
    {
        var fileStream = new MemoryStream(doc.DOC);
        var fileName = Guid.NewGuid().ToString() + doc.FileExt;

        using var streamRef = new DotNetStreamReference(stream: fileStream);

        await JS.InvokeVoidAsync("downloadFileFromStream", fileName, streamRef);
    }
    /// <summary>
    /// Filters documents
    /// </summary>
    private async Task Filter()
    {
        string [] wordsArray = Search.ToLower().Split(" ");
        SearchSpinner = true;
        Documents = DocumentsNonFiltered;
        Documents = await GetFilteredList(Documents, wordsArray);
        SearchSpinner = false;
    }
    /// <summary>
    /// Returns list of documents that contains filterWord in Company name, Items name or Tag
    /// </summary>
    /// <param name="list"></param>
    /// <param name="wordsArray"></param>
    /// <returns></returns>
    private async Task<IEnumerable<DocumentDTO>> GetFilteredList(IEnumerable<DocumentDTO> list, string[] wordsArray)
    {
        List<DocumentDTO> filteredList = new();

        foreach (var doc in list)
        {
            if (wordsArray.Any(doc.Company.ToLower().Contains) || wordsArray.Any(doc.Tag.ToLower().Contains) || wordsArray.Any(doc.Items.Select(i => i.Name).Contains))
            {
                filteredList.Add(doc);
            } 
        }

        return filteredList;
    }
}
