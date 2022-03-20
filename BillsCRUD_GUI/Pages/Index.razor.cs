namespace BillsCRUD_GUI.Pages
{
    public partial class Index
    {
        [CascadingParameter]
        private IModalService Modal { get; set; }
        private IEnumerable<DocumentDTO> Documents { get; set; }
        private IEnumerable<string?> Tags { get; set; }
        private string Search { get; set; } = string.Empty;
        private bool SearchSpinner { get; set; } = false;

        protected async override Task OnInitializedAsync()
        {
            Documents = await _documentService.GetAll();
            Tags = Documents.GetTags();
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
            parameters.Add(nameof(_PopUpEdit.Tags), Tags);
            var messageForm = Modal.Show<_PopUpEdit>("Edit Document", parameters);
            var result = await messageForm.Result;

            //if (!result.Cancelled)
            Documents = await _documentService.GetAll();
        }
        /// <summary>
        /// Opens _PopUpAdd component
        /// </summary>
        /// <returns></returns>
        private async Task ShowAddDocument()
        {
            var parameters = new ModalParameters();
            parameters.Add(nameof(_PopUpAdd.Tags), Tags);
            var messageForm = Modal.Show<_PopUpAdd>("Add Document", parameters);
            var result = await messageForm.Result;

            if (!result.Cancelled)
                Documents = await _documentService.GetAll();
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
               await _documentService.Delete(doc);

            Documents = await _documentService.GetAll();
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
        private void Filter()
        {
            SearchSpinner = true;
            Documents = Documents.Where(d => d.Company.Contains(Search, StringComparison.OrdinalIgnoreCase)
            || d.ItemsInString.GetString().Contains(Search, StringComparison.OrdinalIgnoreCase) || (d.Company.Contains(Search, StringComparison.OrdinalIgnoreCase)
            && d.ItemsInString.GetString().Contains(Search, StringComparison.OrdinalIgnoreCase)));
            SearchSpinner = false;
        }
    }
}
