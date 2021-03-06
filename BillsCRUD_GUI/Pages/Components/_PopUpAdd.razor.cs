namespace BillsCRUD_GUI.Pages.Components
{
    public partial class _PopUpAdd
    {
        [Parameter]
        public DocumentDTO DocumentModel { get; set; }
        [Parameter]
        public IEnumerable<string?> Categories { get; set; }
        [CascadingParameter]
        private IModalService Modal { get; set; }
        [CascadingParameter]
        private BlazoredModalInstance ModalInstance { get; set; }
        private string AddText { get; set; }
        private bool UploadSpinner { get; set; } = false;
        private bool AddButtonSpinner { get; set; } = false;

        protected override async Task OnInitializedAsync()
        {
            DocumentModel = new();
            DocumentModel.Items = new List<Item>();
        }
        /// <summary>
        /// Triggers after a file is selected, reads its extension and saves it in DB, converts the file to binary and saves it to DB
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        private async Task OnInputFileChange(InputFileChangeEventArgs e)
        {
            UploadSpinner = true;
            DocumentModel.FileExt = "." + e.File.ContentType.Split("/")[1];
            MemoryStream ms = new();
            await e.File.OpenReadStream().CopyToAsync(ms);
            var bytes = ms.ToArray();
            DocumentModel.DOC = bytes;
            DocumentModel.FileExist = true;
            UploadSpinner = false;
        }
        /// <summary>
        /// Adds item to document class
        /// </summary>
        private void AddItem()
        {
            Item item = new Item(AddText, DocumentModel.PkDocumentId);
            DocumentModel.Items.Add(item);
            AddText = String.Empty;
        }
        /// <summary>
        /// Removes item from document class
        /// </summary>
        private async Task RemoveItem(Item item)
        {
            var messageForm = Modal.Show<_ConfirmDelete>("Delete Item");
            var result = await messageForm.Result;

            if (!result.Cancelled)
                DocumentModel.Items.Remove(item);
        }
        /// <summary>
        /// Adds document to database
        /// </summary>
        /// <returns></returns>
        private async Task Add()
        {
            AddButtonSpinner = true;
            DocumentModel.Tag = DocumentModel.Tag.FirstCharToUpper();
            DocumentModel.Category = DocumentModel.Category.FirstCharToUpper();
            await _documentService.Create(DocumentModel);
            await ModalInstance.CloseAsync();
            AddButtonSpinner = false;
        }
    }
}
