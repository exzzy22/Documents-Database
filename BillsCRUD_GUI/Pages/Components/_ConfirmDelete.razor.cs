namespace BillsCRUD_GUI.Pages.Components
{
    public partial class _ConfirmDelete
    {
        [CascadingParameter]
        private BlazoredModalInstance ModalInstance { get; set; }
        private async Task Result(string result)
        {
            if (result == "Cancel")
                await ModalInstance.CancelAsync();
            else
                await ModalInstance.CloseAsync();
        }
    }
}
